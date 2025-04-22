using BooksService.Application.Validators.CommandValidators;
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

            return services;
        }
    }
}
