using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.Products.Domain;

namespace SalesSystem.Modules.ProductCategories.Domain
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
