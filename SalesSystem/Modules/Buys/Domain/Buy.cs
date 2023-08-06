using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Users.Domain.Entities;

namespace SalesSystem.Modules.Buys.Domain
{
    public sealed class Buy : AggregrateRoot
    {
        private Buy() { }

        public BuyId? Id { get; private set; }
        public ProductId? ProductId { get; private set; }
        public Product? Product { get; set; }
        public string? UserId { get; private set; }
        public User? User { get; private set; }
        public int Qty { get; private set; }
        public DateTime DateBuy { get; private set; }

        public Buy(BuyId? id, ProductId? productId, string userId, int qty, DateTime dateBuy)
        {
            Id = id;
            ProductId = productId;
            UserId = userId;
            Qty = qty;
            DateBuy = dateBuy;
        }
    }
}
