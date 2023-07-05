using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.Modules.Carts.Domain
{
    public sealed class Cart : AggregrateRoot
    {
        private Cart() { }

        public CartId? Id { get; private set; }
        //TODO: Id y relacion real con el usuario
        public Guid? UserId { get; private set; }
        public ICollection<CartItem>? CartItems { get; set; }

        public Cart(CartId? id, Guid? userId)
        {
            Id = id;
            UserId = userId;
        }
    }
}
