﻿using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.Products.Domain
{
    public sealed class Product : AggregrateRoot
    {
        private Product() { }

        public ProductId Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public DateTime CreateAt { get; set; }
        public bool IsUpdated { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeleteAt { get; set; }


        public Product(ProductId id, string name, string description, decimal price, int stock, DateTime createAt, DateTime upDateAt, DateTime deleteAt, bool isUpdated, bool isDeleted)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            CreateAt = createAt;
            UpdateAt = upDateAt;
            DeleteAt = deleteAt;
            IsUpdated = isUpdated;
            IsDeleted = isDeleted;
        }

        public static Product UpdateProduct(Guid id, string name, string description, decimal price, int stock, DateTime createAt, DateTime upDateAt, DateTime deleteAt, bool isUpdated, bool isDeleted)
        {
            return new Product(new ProductId(id), name, description, price, stock, createAt, upDateAt, deleteAt, isUpdated, isDeleted);
        }

        public static Product DeleteProduct(Guid id, string name, string description, decimal price, int stock, DateTime createAt, DateTime upDateAt, DateTime deleteAt, bool isUpdated, bool isDeleted)
        {
            return new Product(new ProductId(id), name, description, price, stock, createAt, upDateAt, deleteAt, isUpdated, isDeleted);
        }
    }
}
