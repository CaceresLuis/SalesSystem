using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Modules.Users.Domain.Entities;
using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.Modules.Carts.Domain
{
    public sealed class Cart : AggregrateRoot
    {
        private Cart() { }

        public CartId? Id { get; private set; }
        public User? User { get; private set; }
        public string? UserId { get; private set; }
        public ICollection<CartItem>? CartItems { get; set; }

        public Cart(CartId? id, string userId)
        {
            Id = id;
            UserId = userId;
        }
    }
}
