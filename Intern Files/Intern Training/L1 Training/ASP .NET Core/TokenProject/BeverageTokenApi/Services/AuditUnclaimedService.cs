using BeverageTokenApi.Data;
using BeverageTokenApi.Models;
using Microsoft.EntityFrameworkCore;

public class AuditUnclaimedService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly TimeZoneInfo _istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

    public AuditUnclaimedService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        DateTime? lastRunDate = null;

        while (!stoppingToken.IsCancellationRequested)
        {
            var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _istZone);
            var today = now.Date;
            var targetTime = new TimeSpan(17, 0, 0); // 5:00 PM IST

            if (now.TimeOfDay >= targetTime && lastRunDate != today)
            {
                using var scope = _scopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                bool isWorkingDay = await db.WorkingDays.AnyAsync(d => d.Date.Date == today);
                if (!isWorkingDay)
                {
                    lastRunDate = today;
                    continue;
                }

                var users = await db.Users.ToListAsync();
                var existing = await db.TokenRequests.Where(tr => tr.RequestTime.Date == today).ToListAsync();
                var sessions = new[] { new TimeSpan(11, 0, 0), new TimeSpan(16, 0, 0) };

                foreach (var session in sessions)
                {
                    foreach (var user in users)
                    {
                        bool claimed = existing.Any(tr =>
                            tr.UserId == user.Id &&
                            tr.RequestTime.TimeOfDay >= session &&
                            tr.RequestTime.TimeOfDay <= session.Add(TimeSpan.FromMinutes(30)));

                        if (!claimed)
                        {
                            db.TokenRequests.Add(new TokenRequest
                            {
                                UserId = user.Id,
                                BeverageType = "none",
                                RequestTime = today + session,
                                IsClaimed = false
                            });
                        }
                    }
                }

                await db.SaveChangesAsync();
                lastRunDate = today;
            }

            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }
    }
}
