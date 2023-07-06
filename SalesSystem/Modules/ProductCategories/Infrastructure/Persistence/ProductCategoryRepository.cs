using Microsoft.EntityFrameworkCore;
using SalesSystem.Shared.Aplication.Data;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.ProductCategories.Domain;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Shared.Infrastructure;

namespace SalesSystem.Modules.ProductCategories.Infrastructure.Persistence
{
    internal class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(ProductCategory productCategory) => _context.ProductCategories.Add(productCategory);

        public async Task<bool> ProductCategoryRelationExistAsync(ProductId productId, CategoryId categoryId) => await _context.ProductCategories.AnyAsync(pc => pc.ProductId == productId && pc.CategoryId == categoryId);

        public async Task<ProductCategory?> ProductCategoryExistAsync(ProductId productId, CategoryId categoryId) => await _context.ProductCategories.SingleOrDefaultAsync(pc => pc.ProductId == productId && pc.CategoryId == categoryId);

        public void Delete(ProductCategory productCategory) => _context.ProductCategories.Remove(productCategory);

        public async Task<IEnumerable<ProductCategory>> GetAllAsync() => await _context.ProductCategories.ToListAsync();
    }
}
