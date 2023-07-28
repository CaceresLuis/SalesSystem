using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Buys.Domain;
using SalesSystem.Shared.Infrastructure;

namespace SalesSystem.Modules.Buys.Infrastructure.Persistence
{
    public class BuyRepository : IBuyRepository
    {
        private readonly ApplicationDbContext _context;

        public BuyRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Buy buy) => _context.Buys.Add(buy);

        public void Delete(Buy buy) => _context.Buys.Remove(buy);

        public async Task<Buy?> GetByIdAsync(BuyId id) => await _context.Buys.AsNoTracking().Include(b => b.Product)!.ThenInclude(p => p!.ProductCategories)!.ThenInclude(pc => pc.Category).SingleOrDefaultAsync(b => b.Id == id);

        public async Task<IEnumerable<Buy>> GetAllAsync(Guid userId) => await _context.Buys.AsNoTracking().Where(b => b.UserId == userId).Include(ci => ci.Product)!.ThenInclude(p => p!.ProductCategories)!.ThenInclude(pc => pc.Category).ToListAsync();
    }
}
