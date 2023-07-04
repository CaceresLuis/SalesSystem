namespace SalesSystem.ProductCategories.Domain
{
    public interface IProductCategoryRepository
    {
        void Add(ProductCategory productCategory);
        void Update(ProductCategory productCategory);
        void Delete(ProductCategory productCategory);
        Task<IEnumerable<ProductCategory>> GetAllAsync();
    }
}
