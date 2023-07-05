using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.Modules.CartItems.Domain
{
    public sealed class CartItem : AggregrateRoot
    {
        private CartItem() { }

        public CartItemId? Id { get; private set; }
        public ProductId? ProductId { get; private set; }
        public Product? Product { get; set; }
        public CartId? CartId { get; private set; }
        public Cart? Cart { get; private set; }
        public int Qty { get; private set; }

        public CartItem(CartItemId? id, ProductId? productId, CartId? cartId, int qty)
        {
            Id = id;
            ProductId = productId;
            CartId = cartId;
            Qty = qty;
        }
    }
}
