using Microsoft.EntityFrameworkCore;
using SalesSystem.Shared.Infrastructure;
using SalesSystem.Modules.TempCartItems.Domain;
using SalesSystem.Modules.Products.Domain;

namespace SalesSystem.Modules.TempCartItems.Infrastructure.Persistence
{
    public class TempCartItempRepository : ITempCartItempRepository
    {
        private readonly ApplicationDbContext _context;

        public TempCartItempRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddTempCartItem(TempCartItem tempCart) => _context.TempCartItems.Add(tempCart);

        public void UpdateTempCartItem(TempCartItem tempCart) => _context.TempCartItems.Update(tempCart);

        public void DeleteTempCartItem(TempCartItem tempCart) => _context.TempCartItems?.Remove(tempCart);

        public async Task<bool> TempUserExist(Guid tempUser) => await _context.TempCartItems.AnyAsync(tp => tp.TempUser == tempUser);

        public async Task<TempCartItem?> GetSimpleTempCartByIdAsync(Guid id) => await _context.TempCartItems.SingleOrDefaultAsync(tp => tp.Id == id);

        public async Task<TempCartItem?> GetTempCartByIdAsync(Guid id) => await _context.TempCartItems.AsNoTracking()
            .Include(ci => ci.Product)!.ThenInclude(p => p!.ProductCategories)!.ThenInclude(pc => pc.Category).SingleOrDefaultAsync(tp => tp.Id == id);

        public async Task<TempCartItem?> ExistTempCartItem(Guid tempUser, ProductId productId) => await _context.TempCartItems.AsNoTracking().SingleOrDefaultAsync(tp => tp.TempUser == tempUser && tp.ProductId == productId);

        public async Task<IEnumerable<TempCartItem>> GetAllTempCartAsync(Guid tempUser) => await _context.TempCartItems.AsNoTracking().Where(ci => ci.TempUser == tempUser)
            .Include(ci => ci.Product)!.ThenInclude(p => p!.ProductCategories)!.ThenInclude(pc => pc.Category).ToListAsync();
    }
}
