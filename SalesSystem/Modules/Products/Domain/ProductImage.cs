using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.Modules.Products.Domain
{
    public sealed class ProductImage : AggregrateRoot
    {
        public ProductImage(Guid id, string? imageUrl, ProductId? productId)
        {
            Id = id;
            ImageUrl = imageUrl;
            ProductId = productId;
        }

        private ProductImage() { }

        public Guid Id { get; private set; }
        public string? ImageUrl { get; set; }
        public ProductId? ProductId { get; private set; }
        public Product? Product { get; set; }
    }
}
