using SalesSystem.Categories.Domain;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Shared.Infrastructure;

namespace SalesSystem.Categories.Infrastructure.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Category category) => _context.Categories.Add(category);

        public async Task<bool> ExistAsync(CategoryId id) => await _context.Categories.AnyAsync(c => c.Id == id && !c.IsDeleted);

        public async Task<IEnumerable<Category>> GetAllAsync() => await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();

        public async Task<IEnumerable<Category>> GetAllDeletedAsync() => await _context.Categories.Where(c => c.IsDeleted).ToListAsync();

        public async Task<Category?> GetByIdAsync(CategoryId id) => await _context.Categories.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

        public void Update(Category category) => _context.Categories.Update(category);

        public void Delete(Category category) => _context.Categories.Remove(category);
    }
}
