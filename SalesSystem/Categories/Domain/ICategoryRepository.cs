namespace SalesSystem.Categories.Domain
{
    public interface ICategoryRepository
    {
        //Task<Category?> GetAsync(int id);
        Task Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Category>> GetAllDeletedAsync();
    }
}
