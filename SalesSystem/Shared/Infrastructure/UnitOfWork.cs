using SalesSystem.Modules.Users.Domain;
using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.ProductCategories.Domain;

namespace SalesSystem.Shared.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICartRepository CartRepository { get; }
        public IUserRepository UserRepository { get; }
        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ICartItemRepository CartItemRepository { get; }
        public IProductCategoryRepository ProductCategoryRepository { get; }

        public UnitOfWork(ApplicationDbContext context, ICategoryRepository categoryRepository, IProductRepository productRepository, ICartRepository cartRepository, IUserRepository userRepository, ICartItemRepository cartItemRepository, IProductCategoryRepository productCategoryRepository)
        {
            _context = context;
            UserRepository = userRepository;
            CartRepository = cartRepository;
            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
            CartItemRepository = cartItemRepository;
            ProductCategoryRepository = productCategoryRepository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await _context.SaveChangesAsync(cancellationToken);

        public void Dispose() => _context.Dispose();
    }
}
