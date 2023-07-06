using Microsoft.AspNetCore.Identity;

namespace SalesSystem.Modules.Users.Domain
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public Guid Id { get; set; }
        public User? User { get; set; }
        public Role? Role { get; set; }
    }
}
