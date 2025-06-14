using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using ATCT_Backend.Data;
using System;
using System.Linq;

namespace ATCT_Backend.Services
{
    public class SessionNotificationService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<SessionNotificationService> _logger;

        public SessionNotificationService(IServiceProvider serviceProvider, ILogger<SessionNotificationService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var now = DateTime.Now;
                    var upcomingSessions = _context.Sessions
                        .Where(s => s.StartTime > now && s.StartTime <= now.AddMinutes(5))
                        .ToList();

                    foreach (var session in upcomingSessions)
                    {
                        _logger.LogInformation($"📢 Sesija '{session.Title}' počinje uskoro u {session.StartTime:HH:mm}!");
                    }
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
