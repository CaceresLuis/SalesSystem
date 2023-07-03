namespace SalesSystem.Categories.Domain
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(CategoryId id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<Category>> GetAllDeletedAsync();
        Task<bool> ExistAsync(CategoryId id);
    }
}
