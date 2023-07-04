using SalesSystem.Products.Domain;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Categories.Domain;
using SalesSystem.Shared.Aplication.Data;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.ProductCategories.Domain;

namespace SalesSystem.Shared.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher) : base(options)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
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
