using SalesSystem.Modules.Products.Domain;

namespace SalesSystem.Modules.Images.Domain
{
    public class Image
    {
        public Guid Id { get; set; }
        public ProductId? ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
