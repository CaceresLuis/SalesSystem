using Microsoft.AspNetCore.Identity;
using SalesSystem.Modules.Carts.Domain;

namespace SalesSystem.Modules.Users.Domain
{
    public class User : IdentityUser
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public ICollection<UserCard>? UserCards { get; set; }
        public ICollection<UserAddres>? UserAddres { get; set; }
        public string? FullName => $"{FirstName} {LastName}";
        public Cart? Cart { get; set; }
        public virtual ICollection<UserRole>? UserRoles { get; set; }

        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; private set; }
        public DateTime DeleteAt { get; private set; }
        public bool IsUpdated { get; private set; }
        public bool IsDeleted { get; private set; }
    }
}