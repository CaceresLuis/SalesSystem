using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Products.Domain;

namespace SalesSystem.Modules.CartItems.Domain
{
    public interface ICartItemRepository
    {
        void Add(CartItem cartItem);
        void Delete(CartItem cartItem);
        Task<CartItem?> GetByIdAsync(CartItemId id);
        Task<IEnumerable<CartItem>> GetAllAsync(CartId cartId);
        Task<CartItem> CartItemExistAsync(CartId cartId, ProductId productId);
    }
}
