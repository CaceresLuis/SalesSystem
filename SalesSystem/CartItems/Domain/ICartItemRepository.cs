using SalesSystem.Carts.Domain;
using SalesSystem.Products.Domain;

namespace SalesSystem.CartItems.Domain
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
