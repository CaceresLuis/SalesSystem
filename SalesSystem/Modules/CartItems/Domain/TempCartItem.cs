using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.Modules.CartItems.Domain
{
    public sealed class TempCartItem : AggregrateRoot
    {
        private TempCartItem() { }

        public Guid? Id { get; private set; }
        public ProductId? ProductId { get; private set; }
        public Product? Product { get; set; }
        public Guid TempUser { get; private set; }
        public int Qty { get; private set; }


        public TempCartItem(Guid? id, ProductId? productId, Guid tempUser, int qty)
        {
            Id = id;
            ProductId = productId;
            TempUser = tempUser;
            Qty = qty;
        }
    }
}
