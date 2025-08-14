using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeaTokenManagement.Data;
using TeaTokenManagement.Models;

public class ReportsModel : PageModel
{
    private readonly AppDbContext _context;

    public ReportsModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty(SupportsGet = true)]
    public DateTime ReportDate { get; set; } = DateTime.Today;

    [BindProperty(SupportsGet = true)]
    public string Session { get; set; } = "Morning";

    public List<TeaTokenLog> Consumed { get; set; } = new();
    public List<Employee> NotConsumed { get; set; } = new();
    public bool ReportGenerated { get; set; } = false;

    public async Task OnGetAsync()
    {
        var allEmployees = await _context.Employees.ToListAsync();

        Consumed = await _context.TeaTokenLogs
            .Include(t => t.Employee)
            .Where(t => t.Date == ReportDate.Date && t.Session == Session)
            .ToListAsync();

        var consumedIds = Consumed.Select(t => t.EmployeeId).ToList();
        NotConsumed = allEmployees.Where(e => !consumedIds.Contains(e.EmployeeId)).ToList();

        ReportGenerated = true;
    }
}
