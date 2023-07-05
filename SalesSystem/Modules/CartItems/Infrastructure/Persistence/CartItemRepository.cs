using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Products.Domain;

namespace SalesSystem.Modules.CartItems.Infrastructure.Persistence
{
    internal class CartItemRepository : ICartItemRepository
    {
        public void Add(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> CartItemExistAsync(CartId cartId, ProductId productId)
        {
            throw new NotImplementedException();
        }

        public void Delete(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartItem>> GetAllAsync(CartId cartId)
        {
            throw new NotImplementedException();
        }

        public Task<CartItem?> GetByIdAsync(CartItemId id)
        {
            throw new NotImplementedException();
        }
    }
}
