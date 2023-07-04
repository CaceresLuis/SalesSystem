using SalesSystem.Products.Domain;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Categories.Domain;
using SalesSystem.ProductCategories.Domain;

namespace SalesSystem.Shared.Aplication.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
