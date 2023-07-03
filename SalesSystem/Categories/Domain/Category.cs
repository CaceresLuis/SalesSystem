using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.Categories.Domain
{
    public sealed class Category : AggregrateRoot
    {
        private Category() { }

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

        public CategoryId Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public bool IsUpdated { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeleteAt { get; set; }

        public static Category UpdateCategory(Guid id, string name, DateTime createAt, DateTime upDateAt, DateTime deleteAt, bool isUpdate, bool isDeleted)
        {
            return new Category(new CategoryId(id), name, createAt, upDateAt, deleteAt, isUpdate, isDeleted);
        }

        public static Category DeleteCategory(Guid id, string name, DateTime createAt, DateTime upDateAt, DateTime deleteAt, bool isUpdate, bool isDeleted)
        {
            return new Category(new CategoryId(id), name, createAt, upDateAt, deleteAt, isUpdate, isDeleted);
        }
    }
}
