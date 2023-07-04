using Microsoft.EntityFrameworkCore;
using SalesSystem.Shared.Aplication.Data;
using SalesSystem.ProductCategories.Domain;

namespace SalesSystem.ProductCategories.Infrastructure.Persistence
{
    internal class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly IApplicationDbContext _context;

        public ProductCategoryRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(ProductCategory productCategory) => _context.ProductCategories.Add(productCategory);

        public async Task<IEnumerable<ProductCategory>> GetAllAsync() => await _context.ProductCategories.ToListAsync();

        public void Update(ProductCategory productCategory) => _context.ProductCategories.Update(productCategory);

        public void Delete(ProductCategory productCategory) => _context.ProductCategories.Remove(productCategory);
    }
}
