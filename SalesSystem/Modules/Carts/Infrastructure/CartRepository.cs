using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Shared.Infrastructure;

namespace SalesSystem.Modules.Carts.Infrastructure
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Cart cart) => _context.Carts.Add(cart);

        public void Delete(Cart cart) => _context.Carts.Remove(cart);

        public async Task<IEnumerable<Cart>> GetAllAsync() => await _context.Carts.AsNoTracking().ToListAsync();

        public async Task<Cart?> GetByIdAsync(CartId id) => await _context.Carts.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }
}
