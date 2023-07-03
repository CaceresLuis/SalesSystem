﻿using SalesSystem.Products.Domain;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Shared.Infrastructure;

namespace SalesSystem.Products.Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Product product) => _context.Products.Add(product);

        public async Task<bool> ExistAsync(ProductId id) => await _context.Products.AnyAsync(p => p.Id == id);

        public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.Where(p => !p.IsDeleted).ToListAsync();

        public async Task<IEnumerable<Product>> GetAllDeletedAsync() => await _context.Products.Where(p => p.IsDeleted).ToListAsync();

        public async Task<Product?> GetByIdAsync(ProductId id) => await _context.Products.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

        public void Update(Product product) => _context.Products.Update(product);

        public void Delete(Product product) => _context.Products.Remove(product);
    }
}
