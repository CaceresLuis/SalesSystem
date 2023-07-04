using SalesSystem.Products.Domain;
using SalesSystem.Categories.Domain;
using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.ProductCategories.Domain
{
    public sealed class ProductCategory : AggregrateRoot
    {
        private ProductCategory() { }

        public int Id { get; set; }
        public CategoryId CategoryId { get; private set; }
        public ProductId ProductId { get; private set; }
        public Category Category { get; set; }
        public Product Product { get; set; }

        public ProductCategory(int id, CategoryId categoryId, ProductId productId)
        {
            Id = id;
            CategoryId = categoryId;
            ProductId = productId;
        }

        public static ProductCategory UpdateProductCategory(int id, CategoryId categoryId, ProductId productId)
        {
            return new ProductCategory(id, categoryId, productId);
        }
    }
}
