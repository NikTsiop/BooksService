using BooksService.Application.Handlers.CommandsHandlers;
using BooksService.Application.Handlers.QueriesHandlers;
using BooksService.Application.Validators.CommandValidators;
using BooksService.Application.Validators.QueryValidators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BooksService.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {

            //Validators Registration
            services.AddValidatorsFromAssemblyContaining<CreateUserCommnadValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateUserRoleCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<GetPagedBooksQueryValidator>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateUserCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetPagedBooksQueryHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllBooksQueryHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateUserRoleCommandHandler).Assembly));

            return services;
        }
    }
}
