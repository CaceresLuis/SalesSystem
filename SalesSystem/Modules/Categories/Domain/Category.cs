using SalesSystem.Modules.ProductCategories.Domain;
using SalesSystem.Shared.Domain.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesSystem.Modules.Categories.Domain
{
    public sealed class Category : AggregrateRoot
    {
        private Category() { }

        public CategoryId? Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public bool IsUpdated { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeleteAt { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }

        public Category(CategoryId id, string name, DateTime createAt, DateTime upDateAt, DateTime deleteAt, bool isUpdated, bool isDeleted)
        {
            Id = id;
            Name = name;
            CreateAt = createAt;
            UpdateAt = upDateAt;
            DeleteAt = deleteAt;
            IsUpdated = isUpdated;
            IsDeleted = isDeleted;
        }

        public Category(CategoryId id, string name, DateTime upDateAt, bool isUpdated)
        {
            Id = id;
            Name = name;
            UpdateAt = upDateAt;
            IsUpdated = isUpdated;
        }

        public Category(CategoryId id, DateTime deletedAt, bool isDeleted)
        {
            Id = id;
            DeleteAt = deletedAt;
            IsDeleted = isDeleted;
        }

        public static Category UpdateCategory(Guid id, string name, DateTime createAt, DateTime upDateAt, DateTime deleteAt, bool isUpdate, bool isDeleted)
        {
            return new Category(new CategoryId(id), name, createAt, upDateAt, deleteAt, isUpdate, isDeleted);
        }
    }
}
