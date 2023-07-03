using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SalesSystem.Shared.Aplication.Behavior;

namespace SalesSystem.Shared.Aplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviors<,>));
            services.AddMediatR(config => { config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>(); });

            return services;
        }
    }
}
