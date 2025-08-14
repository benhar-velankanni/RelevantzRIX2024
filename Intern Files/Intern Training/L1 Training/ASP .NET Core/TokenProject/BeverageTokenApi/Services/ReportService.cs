using BeverageTokenApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BeverageTokenApi.Services;

public class ReportService
{
    private readonly AppDbContext _context;

    public ReportService(AppDbContext context) => _context = context;

    public async Task<object> GenerateReport(DateTime start, DateTime end)
    {
        var tokens = await _context.TokenRequests
            .Where(t => t.RequestTime.Date >= start.Date && t.RequestTime.Date <= end.Date)
            .GroupBy(t => t.BeverageType)
            .Select(g => new
            {
                Beverage = g.Key,
                Count = g.Count()
            })
            .ToListAsync();

        return tokens;
    }
}
