using SalesSystem.Modules.Buys.Domain;
using SalesSystem.Modules.Roles.Domain;
using SalesSystem.Modules.Users.Domain;
using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Images.Domain;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.TempCartItems.Domain;
using SalesSystem.Modules.ProductCategories.Domain;

namespace SalesSystem.Shared.Domain.Primitives
{
    public interface IUnitOfWork : IDisposable
    {
        public IBuyRepository BuyRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public ICartRepository CartRepository { get; }
        public IUserRepository UserRepository { get; }
        public IImagenRepository ImagenRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IUserCardRepository UserCardRepository{ get; }
        public ICategoryRepository CategoryRepository { get; }
        public ICartItemRepository CartItemRepository { get; }
        public IUserAddressRepository UserAddressRepository { get; }
        public ITempCartItempRepository TempCartItempRepository { get; }
        public IProductCategoryRepository ProductCategoryRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
