using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Products.Domain;

namespace SalesSystem.Modules.CartItems.Domain
{
    public interface ICartItemRepository
    {
        void Add(CartItem cartItem);
        void Delete(CartItem cartItem);
        void Update(CartItem cartItem);
        Task<CartItem?> GetByIdAsync(CartItemId id);
        Task<IEnumerable<CartItem>>? GetAllAsync(CartId cartId);
        Task<CartItem?> CartItemExistAsync(CartId cartId, ProductId productId);
        void AddTempCartItem(TempCartItem tempUser);
        Task<TempCartItem?> GetTempCartByIdAsync(Guid id);
        void UpdateTempCartItem(TempCartItem tempCart);
        Task<IEnumerable<TempCartItem>> GetAllTempCartAsync(Guid cartId);
    }
}
