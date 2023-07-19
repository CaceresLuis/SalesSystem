using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.ProductCategories.Domain;
using SalesSystem.Modules.Users.Domain.Entities;

namespace SalesSystem.Shared.Aplication.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<UserCard> UserCards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserAddres> UserAddres { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
