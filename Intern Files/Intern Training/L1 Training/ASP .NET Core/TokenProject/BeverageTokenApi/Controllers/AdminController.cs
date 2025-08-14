using BeverageTokenApi.Services;
using BeverageTokenApi.Data;
using BeverageTokenApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeverageTokenApi.Controllers;

[Authorize(Roles = "admin")]
[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly ReportService _reportService;
    private readonly AppDbContext _context;

    public AdminController(ReportService reportService, AppDbContext context)
    {
        _reportService = reportService;
        _context = context;
    }

    [HttpGet("report")]
    public async Task<IActionResult> GetReport([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var report = await _reportService.GenerateReport(startDate, endDate);
        return Ok(report);
    }

    [HttpPost("workingdays")]
    public async Task<IActionResult> AddWorkingDays([FromBody] List<DateTime> days)
    {
        foreach (var day in days)
        {
            if (!await _context.WorkingDays.AnyAsync(w => w.Date.Date == day.Date))
            {
                _context.WorkingDays.Add(new WorkingDay { Date = day.Date });
            }
        }

        await _context.SaveChangesAsync();
        return Ok("Working days updated successfully.");
    }

    [HttpGet("workingdays")]
    public async Task<IActionResult> GetWorkingDays()
    {
        var days = await _context.WorkingDays
            .OrderBy(w => w.Date)
            .Select(w => w.Date)
            .ToListAsync();

        return Ok(days);
    }

    [HttpDelete("workingdays")]
    public async Task<IActionResult> RemoveWorkingDay([FromQuery] DateTime date)
    {
        var workingDay = await _context.WorkingDays.FirstOrDefaultAsync(w => w.Date.Date == date.Date);
        if (workingDay == null) return NotFound("Date not found in working days.");

        _context.WorkingDays.Remove(workingDay);
        await _context.SaveChangesAsync();
        return Ok("Working day removed.");
    }

    [HttpGet("tokens")]
    public async Task<IActionResult> GetAllTokens([FromQuery] DateTime? date = null)
    {
        var query = _context.TokenRequests.Include(tr => tr.User).AsQueryable();

        if (date.HasValue)
            query = query.Where(tr => tr.RequestTime.Date == date.Value.Date);

        var tokens = await query
            .OrderBy(tr => tr.RequestTime)
            .Select(tr => new
            {
                tr.Id,
                UserEmail = tr.User.Email,
                Role = tr.User.Role,
                tr.BeverageType,
                tr.RequestTime,
                tr.IsClaimed
            }).ToListAsync();

        return Ok(tokens);
    }
    [HttpGet("users")]
    public async Task<IActionResult> GetRegisteredUsers()
    {
        var users = await _context.Users
            .OrderBy(u => u.Email)
            .Select(u => new
            {
                u.Id,
                u.Email,
                u.Role
            }).ToListAsync();

        return Ok(users);
    }

[HttpGet("daily-report")]
public async Task<IActionResult> GetDailySessionReport([FromQuery] DateTime? date)
{
    var istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    var nowIST = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, istZone);

    var targetDate = date?.Date ?? nowIST.Date;

    // Only allow access after 5:00 PM IST
    if (nowIST.Date == targetDate && nowIST.TimeOfDay < new TimeSpan(17, 0, 0))
        return BadRequest("Report is available only after 5:00 PM IST for the selected day.");

    var users = await _context.Users.ToListAsync();
    var tokens = await _context.TokenRequests
        .Where(tr => tr.RequestTime.Date == targetDate)
        .ToListAsync();

    var sessions = new[] {
        new { Label = "Morning", Start = new TimeSpan(11, 0, 0), End = new TimeSpan(11, 30, 0) },
        new { Label = "Evening", Start = new TimeSpan(16, 0, 0), End = new TimeSpan(16, 30, 0) }
    };

    var report = new List<object>();

    foreach (var user in users)
    {
        var userSessions = sessions.Select(session =>
        {
            var hasEntry = tokens.Any(tr =>
                tr.UserId == user.Id &&
                tr.RequestTime.TimeOfDay >= session.Start &&
                tr.RequestTime.TimeOfDay <= session.End);

            var claimed = tokens.Any(tr =>
                tr.UserId == user.Id &&
                tr.RequestTime.TimeOfDay >= session.Start &&
                tr.RequestTime.TimeOfDay <= session.End &&
                tr.IsClaimed);

            return new
            {
                Session = session.Label,
                Claimed = hasEntry ? claimed : false
            };
        });

        report.Add(new
        {
            Email = user.Email,
            Role = user.Role,
            Sessions = userSessions
        });
    }

    return Ok(report);
}
[HttpGet("tokens-csv")]
public async Task<IActionResult> ViewTokenRequests([FromQuery] bool exportCsv = false)
{
    var tokens = await _context.TokenRequests
        .Include(t => t.User)
        .OrderByDescending(t => t.RequestTime)
        .ToListAsync();

    var report = tokens.Select(t => new
    {
        Name = t.User.Email,
        Claimed = t.IsClaimed ? "Yes" : "No",
        Date = t.RequestTime.Date.ToShortDateString()
    }).ToList();

    // Generate overall claim count per user
    var claimSummary = report
        .GroupBy(r => r.Name)
        .Select(g => new
        {
            Name = g.Key,
            TotalClaimedDays = g.Count(r => r.Claimed == "Yes")
        }).ToList();

    if (!exportCsv)
        return Ok(new { Records = report, Summary = claimSummary });

    // ✅ CSV Export
    var csvLines = new List<string> { "Name,Claimed,Date" };
    csvLines.AddRange(report.Select(r => $"{r.Name},{r.Claimed},{r.Date}"));

    csvLines.Add(""); // spacer
    csvLines.Add("Name,TotalClaimedDays");
    csvLines.AddRange(claimSummary.Select(s => $"{s.Name},{s.TotalClaimedDays}"));

    var csv = string.Join("\n", csvLines);
    var bytes = System.Text.Encoding.UTF8.GetBytes(csv);

    return File(bytes, "text/csv", $"TokenReport_{DateTime.Now:yyyyMMdd}.csv");
}

}
