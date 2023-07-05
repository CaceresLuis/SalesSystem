using SalesSystem.Categories.Domain;
using SalesSystem.Products.Domain;

namespace SalesSystem.ProductCategories.Domain
{
    public interface IProductCategoryRepository
    {
        void Add(ProductCategory productCategory);
        void Delete(ProductCategory productCategory);
        Task<IEnumerable<ProductCategory>> GetAllAsync();
        Task<ProductCategory?> ProductCategoryExistAsync(ProductId productId, CategoryId categoryId);
        Task<bool> ProductCategoryRelationExistAsync(ProductId productId, CategoryId categoryId);
    }
}
