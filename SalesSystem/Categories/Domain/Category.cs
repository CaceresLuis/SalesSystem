using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.Categories.Domain
{
    public sealed class Category : AggregrateRoot
    {
        private Category() { }

        public Category(CategoryId id, string name, DateTime createAt, DateTime upDateAt, bool isUpdated, DateTime deleteAt, bool isDeleted)
        {
            Id = id;
            Name = name;
            CreateAt = createAt;
            UpdateAt = upDateAt;
            DeleteAt = deleteAt;
            IsUpdated = isUpdated;
            IsDeleted = isDeleted;

        }

        public CategoryId Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public bool IsUpdated { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeleteAt { get; set; }
    }
}
