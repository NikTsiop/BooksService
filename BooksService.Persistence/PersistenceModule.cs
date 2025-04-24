using BooksService.Application.Interfaces.DecorateInterfaces;
using BooksService.Application.Interfaces.Repositories;
using BooksService.Application.Interfaces.Services;
using BooksService.Domain.Entities;
using BooksService.Persistence.Decorators;
using BooksService.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BooksService.Persistence
{
    public static class PersistenceModule
    {
        public static IServiceCollection AddPersistenceModule(this IServiceCollection services) 
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            // Add
            services.AddScoped<IAddRepository<User>>(provider =>
            {
                var baseRepo = provider.GetRequiredService<IUserRepository>();
                var audit = provider.GetRequiredService<IAuditService>();
                return new AuditAddDecorator<User>(baseRepo, audit);
            });

            // Update
            services.AddScoped<IUpdateRepository<User>>(provider =>
            {
                var baseRepo = provider.GetRequiredService<IUserRepository>();
                var audit = provider.GetRequiredService<IAuditService>();
                return new AuditUpdateDecorator<User>(baseRepo, audit);
            });

            // Delete
            services.AddScoped<IDeleteRepository<Category>>(provider =>
            {
                var baseRepo = provider.GetRequiredService<ICategoryRepository>();
                var audit = provider.GetRequiredService<IAuditService>();
                return new AuditDeleteDecorator<Category>(baseRepo, audit);
            });

            return services;
        }
    }
}
