using BooksService.Application.Interfaces.Services;
using BooksService.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BooksService.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {
            services.AddScoped<IAuditService, AuditService>();

            services.AddHostedService<AuditLogCleanupService>();

            return services;
        }
    }
}
