using SalesSystem.Modules.Buys.Domain;
using SalesSystem.Modules.Roles.Domain;
using SalesSystem.Modules.Users.Domain;
using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.ProductCategories.Domain;
using SalesSystem.Modules.TempCartItems.Domain;
using SalesSystem.Modules.Images.Domain;

namespace SalesSystem.Shared.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBuyRepository BuyRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public ICartRepository CartRepository { get; }
        public IUserRepository UserRepository { get; }
        public IImagenRepository ImagenRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IUserCardRepository UserCardRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ICartItemRepository CartItemRepository { get; }
        public IUserAddressRepository UserAddressRepository { get; }
        public ITempCartItempRepository TempCartItempRepository { get; }
        public IProductCategoryRepository ProductCategoryRepository { get; }


        public UnitOfWork(ApplicationDbContext context, ICategoryRepository categoryRepository, IProductRepository productRepository, ICartRepository cartRepository, IUserRepository userRepository, ICartItemRepository cartItemRepository, IProductCategoryRepository productCategoryRepository, IUserAddressRepository userAddressRepository, IUserCardRepository userCardRepository, IBuyRepository buyRepository, IRoleRepository roleRepository, ITempCartItempRepository tempCartItempRepository, IImagenRepository imagenRepository)
        {
            _context = context;
            BuyRepository = buyRepository;
            RoleRepository = roleRepository;
            UserRepository = userRepository;
            CartRepository = cartRepository;
            ImagenRepository = imagenRepository;
            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
            CartItemRepository = cartItemRepository;
            UserCardRepository = userCardRepository;
            UserAddressRepository = userAddressRepository;
            ProductCategoryRepository = productCategoryRepository;
            TempCartItempRepository = tempCartItempRepository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await _context.SaveChangesAsync(cancellationToken);

        public void Dispose() => _context.Dispose();
    }
}
