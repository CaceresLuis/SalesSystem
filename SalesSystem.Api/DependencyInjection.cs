using System.Text;
using SalesSystem.Api.Middlerware;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using SalesSystem.Shared.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SalesSystem.Modules.Users.Domain.Entities;

namespace SalesSystem.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen();
            services.AddEndpointsApiExplorer();
            services.AddTransient<GlobalExceptionHandlingMiddelware>();
            services.AddControllers().AddJsonOptions(c => c.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:jwtKey"]!)),
                    ClockSkew = TimeSpan.Zero
                });

            services.AddIdentity<User, Role>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequiredUniqueChars = 0;
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Lockout.AllowedForNewUsers = true;
                config.Lockout.MaxFailedAccessAttempts = 3;
                config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                config.SignIn.RequireConfirmedEmail = false;
                config.SignIn.RequireConfirmedAccount = false;
                config.SignIn.RequireConfirmedPhoneNumber = false;
                config.User.RequireUniqueEmail = true;
                config.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultProvider;

            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
