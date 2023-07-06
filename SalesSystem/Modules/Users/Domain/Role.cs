using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesSystem.Modules.Users.Domain
{
    public class Role : IdentityRole
    {
        public virtual ICollection<UserRole>? UserRoles { get; set; }
    }
}
