namespace SalesSystem.Products.Domain
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(ProductId id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetAllDeletedAsync();
        Task<bool> ExistAsync(ProductId id);
    }
}
