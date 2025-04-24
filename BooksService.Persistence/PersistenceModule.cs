using BooksService.Application.Interfaces;
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

            return services;
        }
    }
}
