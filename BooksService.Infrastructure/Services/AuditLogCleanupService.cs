using BooksService.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BooksService.Infrastructure.Services
{
    internal class AuditLogCleanupService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private Timer? _timer;

        public AuditLogCleanupService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(Cleanup, null, TimeSpan.Zero, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public void Dispose() => _timer?.Dispose();

        private async void Cleanup(object? state)
        {
            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var cutoff = DateTime.UtcNow.AddDays(-20);

            var oldLogs = db.AuditLogs.Where(x => x.Timestamp < cutoff);
            db.AuditLogs.RemoveRange(oldLogs);
            await db.SaveChangesAsync();
        }
    }
}
