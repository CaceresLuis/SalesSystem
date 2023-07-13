﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SalesSystem.Modules.Users.Domain;
using SalesSystem.Modules.Carts.Domain;
using Microsoft.Extensions.Configuration;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.Carts.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SalesSystem.Modules.ProductCategories.Domain;
using SalesSystem.Modules.Users.Infrastructure;
using SalesSystem.Modules.Users.Infrastructure.Persistence;
using SalesSystem.Modules.Products.Infrastructure.Persistence;
using SalesSystem.Modules.CartItems.Infrastructure.Persistence;
using SalesSystem.Modules.Categories.Infrastructure.Persistence;
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

            //services.AddIdentity<User, Role>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddScoped<IGenerateToken, GenerateToken>();

            return services;
        }
    }
}