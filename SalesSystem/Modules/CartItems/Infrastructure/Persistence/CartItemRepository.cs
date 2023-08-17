using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Shared.Infrastructure;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Modules.CartItems.Domain;

namespace SalesSystem.Modules.CartItems.Infrastructure.Persistence
{
    internal class CartItemRepository : ICartItemRepository
    {
        private readonly ApplicationDbContext _context;

        public CartItemRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(CartItem cartItem) => _context.CartItems.Add(cartItem);

        public void Update(CartItem cartItem) => _context.CartItems.Update(cartItem);

        public void Delete(CartItem cartItem) => _context.CartItems.Remove(cartItem);

        public async Task<CartItem?> GetByIdAsync(CartItemId id) => await _context.CartItems.AsNoTracking()
            .Include(ci => ci.Product)!.ThenInclude(p => p!.ProductCategories)!.ThenInclude(pc => pc.Category).SingleOrDefaultAsync(ci => ci.Id == id);

        public async Task<IEnumerable<CartItem>> GetAllAsync(CartId cartId) => await _context.CartItems.AsNoTracking().Where(ci => ci.CartId == cartId)
            .Include(ci => ci.Product)!.ThenInclude(p => p!.ProductCategories)!.ThenInclude(pc => pc.Category).ToListAsync();

        public async Task<CartItem?> CartItemExistAsync(CartId cartId, ProductId productId) => await _context.CartItems.AsNoTracking().SingleOrDefaultAsync(ci => ci.CartId == cartId && ci.ProductId == productId);



        public void AddTempCartItem(TempCartItem tempCart) => _context.TempCartItems.Add(tempCart);

        public void UpdateTempCartItem(TempCartItem tempCart) => _context.TempCartItems.Update(tempCart);

        public async Task<TempCartItem?> GetTempCartByIdAsync(Guid id) => await _context.TempCartItems.AsNoTracking()
            .Include(ci => ci.Product)!.ThenInclude(p => p!.ProductCategories)!.ThenInclude(pc => pc.Category).SingleOrDefaultAsync(tp => tp.Id == id);

        public async Task<IEnumerable<TempCartItem>> GetAllTempCartAsync(Guid cartId) => await _context.TempCartItems.AsNoTracking().Where(ci => ci.Id == cartId)
            .Include(ci => ci.Product)!.ThenInclude(p => p!.ProductCategories)!.ThenInclude(pc => pc.Category).ToListAsync();
    }
}
