using SalesSystem.Products.Domain;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Categories.Domain;
using Microsoft.Extensions.Configuration;
using SalesSystem.Shared.Aplication.Data;
using SalesSystem.Shared.Domain.Primitives;
using Microsoft.Extensions.DependencyInjection;
using SalesSystem.Products.Infrastructure.Persistence;
using SalesSystem.Categories.Infrastructure.Persistence;

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

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
