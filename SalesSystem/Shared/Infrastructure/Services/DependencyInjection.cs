using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Buys.Domain;
using SalesSystem.Modules.Users.Domain;
using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Roles.Domain;
using SalesSystem.Modules.Images.Domain;
using Microsoft.Extensions.Configuration;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.Carts.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SalesSystem.Modules.Users.Infrastructure;
using SalesSystem.Modules.Roles.Infrastructure;
using SalesSystem.Modules.TempCartItems.Domain;
using SalesSystem.Modules.Images.Infrastructure;
using SalesSystem.Modules.ProductCategories.Domain;
using SalesSystem.Modules.Buys.Infrastructure.Persistence;
using SalesSystem.Modules.Users.Infrastructure.Persistence;
using SalesSystem.Modules.Products.Infrastructure.Persistence;
using SalesSystem.Modules.CartItems.Infrastructure.Persistence;
using SalesSystem.Modules.Categories.Infrastructure.Persistence;
using SalesSystem.Modules.TempCartItems.Infrastructure.Persistence;
using SalesSystem.Modules.ProductCategories.Infrastructure.Persistence;

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

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBuyRepository, BuyRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IImagenRepository, ImagenRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserCardRepository, UserCardRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<IUserAddressRepository, UserAddressRepository>();
            services.AddScoped<ITempCartItempRepository, TempCartItempRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddScoped<IGenerateToken, GenerateToken>();

            return services;
        }
    }
}