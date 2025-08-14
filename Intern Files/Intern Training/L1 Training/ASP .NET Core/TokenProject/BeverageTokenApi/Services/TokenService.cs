using BeverageTokenApi.Data;
using BeverageTokenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BeverageTokenApi.Services;

public class TokenService
{
    private readonly AppDbContext _context;
    private readonly TimeZoneInfo _istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

    public TokenService(AppDbContext context) => _context = context;

    private bool IsInSession(DateTime dt)
    {
        var time = dt.TimeOfDay;
        //time for the start and the end to get the token
        return (time >= new TimeSpan(11, 0, 0) && time <= new TimeSpan(11, 30, 0)) ||
               (time >= new TimeSpan(13, 0, 0) && time <= new TimeSpan(16, 30, 0));
    }

    public async Task<string> RequestToken(int userId, string beverage)
    {
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _istZone);

        var isWorkingDay = await _context.WorkingDays.AnyAsync(w => w.Date.Date == now.Date);
        if (!isWorkingDay)
            return "This is not a valid working day.";

        if (!IsInSession(now))
            return "Outside valid time window.";

        var userRequests = await _context.TokenRequests
            .Where(tr => tr.UserId == userId && tr.RequestTime.Date == now.Date)
            .ToListAsync();

        var alreadyClaimed = userRequests.Any(tr => IsInSession(tr.RequestTime));
        if (alreadyClaimed)
            return "Already claimed during this session.";

        var token = new TokenRequest
        {
            UserId = userId,
            BeverageType = beverage,
            RequestTime = now,
            IsClaimed = true
        };

        _context.TokenRequests.Add(token);
        await _context.SaveChangesAsync();

        return $"Token granted for {beverage}.";
    }
}
