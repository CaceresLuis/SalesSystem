using SalesSystem.Api.Middlerware;
using Microsoft.AspNetCore.Identity;

namespace SalesSystem.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddTransient<GlobalExceptionHandlingMiddelware>();

            //services.Configure<IdentityOptions>(options =>
            //{
            //    // Default Lockout settings.
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //    options.Lockout.MaxFailedAccessAttempts = 5;
            //    options.Lockout.AllowedForNewUsers = true;
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequiredLength = 6;
            //    options.Password.RequiredUniqueChars = 0;

            //});

            return services;
        }
    }
}
