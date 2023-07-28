using SalesSystem.Modules.Buys.Domain;
using SalesSystem.Modules.Users.Domain;
using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.ProductCategories.Domain;

namespace SalesSystem.Shared.Domain.Primitives
{
    public interface IUnitOfWork : IDisposable
    {
        public IBuyRepository BuyRepository { get; }
        public ICartRepository CartRepository { get; }
        public IUserRepository UserRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IUserCardRepository UserCardRepository{ get; }
        public ICategoryRepository CategoryRepository { get; }
        public ICartItemRepository CartItemRepository { get; }
        public IUserAddressRepository UserAddressRepository { get; }
        public IProductCategoryRepository ProductCategoryRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
