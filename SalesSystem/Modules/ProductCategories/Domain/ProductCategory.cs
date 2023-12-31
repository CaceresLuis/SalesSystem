﻿using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.Products.Domain;

namespace SalesSystem.Modules.ProductCategories.Domain
{
    public sealed class ProductCategory : AggregrateRoot
    {
        private ProductCategory() { }

        public int Id { get; set; }
        public CategoryId? CategoryId { get; private set; }
        public ProductId? ProductId { get; private set; }
        public Category? Category { get; set; }
        public Product? Product { get; set; }

        public ProductCategory(int id, CategoryId categoryId, ProductId productId)
        {
            Id = id;
            CategoryId = categoryId;
            ProductId = productId;
        }
    }
}
