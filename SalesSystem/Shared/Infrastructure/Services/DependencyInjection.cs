using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesSystem.Shared.Aplication.Data;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using Microsoft.Extensions.DependencyInjection;
using SalesSystem.Modules.ProductCategories.Domain;
using SalesSystem.Modules.Products.Infrastructure.Persistence;
using SalesSystem.Modules.Categories.Infrastructure.Persistence;
using SalesSystem.Modules.ProductCategories.Infrastructure.Persistence;
using SalesSystem.Modules.Users.Domain;
using Microsoft.AspNetCore.Identity;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Modules.CartItems.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SalesSystem.Shared.Infrastructure.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistece(configuration);
            return services;
        }

        public static IServiceCollection AddPersistece(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("name=ConnectionStrings:PostgresConnection"));
            //services.AddDbContext<SalesContext>(options => options.UseNpgsql(configuration.GetConnectionString("")));

            services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
            //services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

            return services;
        }
    }
}



////Get SecretKey of userManager Secrets, also apply in JwtGenerator
//string keySecret = "YOURSECRETKEYssds494sa984a98s984";
////Config para manejo de usuarios, login, etc
//IdentityBuilder builder = services.AddIdentityCore<User>();
//IdentityBuilder identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
//identityBuilder.AddRoles<IdentityRole>();
//identityBuilder.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<User, IdentityRole>>();
//identityBuilder.AddEntityFrameworkStores<ApplicationDbContext>();
//identityBuilder.AddSignInManager<SignInManager<User>>();
//services.TryAddSingleton<ISystemClock, SystemClock>();
////Configuracion autenticacion                       //Secret key
//SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(keySecret));
//services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
//{
//    opt.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = key,
//        ValidateAudience = false,
//        ValidateIssuer = false
//    };
//});