using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Buys.Domain;
using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Images.Domain;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.Users.Infrastructure;
using SalesSystem.Modules.TempCartItems.Domain;
using SalesSystem.Modules.Users.Domain.Entities;
using SalesSystem.Modules.ProductCategories.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SalesSystem.Shared.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private readonly IPublisher _publisher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher) : base(options)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        public DbSet<Buy> Buys { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<UserCard> UserCards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserAddres> UserAddres { get; set; }
        public DbSet<TempCartItem> TempCartItems { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            IEnumerable<DomainEvent> domainEvents = ChangeTracker.Entries<AggregrateRoot>().Select(e => e.Entity)
                .Where(e => e.GetDomainEvents().Any()).SelectMany(e => e.GetDomainEvents());

            int result = await base.SaveChangesAsync(cancellationToken);

            foreach (DomainEvent? domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            return result;
        }
    }
}
