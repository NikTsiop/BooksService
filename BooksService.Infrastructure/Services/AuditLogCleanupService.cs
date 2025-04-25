using BooksService.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BooksService.Infrastructure.Services
{
    /// <summary>
    /// Background service that periodically cleans up old audit log entries from the database.
    /// </summary>
    internal class AuditLogCleanupService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<AuditLogCleanupService> _logger;
        private Timer? _timer;

        public AuditLogCleanupService(IServiceProvider serviceProvider, ILogger<AuditLogCleanupService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        /// <summary>
        /// Starts the background cleanup task. Runs immediately and then every 24 hours.
        /// </summary>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("AuditLogCleanupService started. Scheduling cleanup task.");
            _timer = new Timer(Cleanup, null, TimeSpan.Zero, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when the host is performing a graceful shutdown.
        /// </summary>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("AuditLogCleanupService is stopping.");
            return Task.CompletedTask;
        }

        /// <summary>
        /// Releases the resources used by the service.
        /// </summary>
        public void Dispose()
        {
            _logger.LogInformation("AuditLogCleanupService is disposing the timer.");
            _timer?.Dispose();
        }

        /// <summary>
        /// Executes the actual cleanup logic: removes audit logs older than 1 minute.
        /// </summary>
        private async void Cleanup(object? state)
        {
            _logger.LogInformation("Starting audit log cleanup task.");

            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Calculate the cutoff time for cleanup
            var cutoff = DateTime.UtcNow.AddDays(-20);

            // Query audit logs that are older than the cutoff time
            var oldLogs = db.AuditLogs.Where(x => x.Timestamp < cutoff);
            var count = oldLogs.Count();

            if (count > 0)
            {
                // Remove and save changes if any logs are eligible for deletion
                db.AuditLogs.RemoveRange(oldLogs);
                await db.SaveChangesAsync();
                _logger.LogInformation("Deleted {Count} audit logs older than {Cutoff}", count, cutoff);
            }
            else
                _logger.LogInformation("No audit logs to clean older than {Cutoff}", cutoff);
        }
    }
}
