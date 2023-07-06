using SalesSystem.Shared.Domain.Primitives;

namespace SalesSystem.Modules.Users.Domain
{
    public sealed class UserAddres : AggregrateRoot
    {
        private UserAddres() { }

        public Guid Id { get; set; }
        public User? User { get; set; }
        public string? UserId { get; private set; }
        public string? City { get; private set; }
        public string? Department { get; private set; }
        public string? AddressSpecific { get; private set; }

        public UserAddres(Guid id, string userId, string? department, string? city, string? addressSpecific)
        {
            Id = id;
            City = city;
            UserId = userId;
            Department = department;
            AddressSpecific = addressSpecific;
        }
    }
}