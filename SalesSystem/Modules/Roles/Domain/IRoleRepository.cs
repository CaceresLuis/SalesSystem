using Microsoft.AspNetCore.Identity;

namespace SalesSystem.Modules.Roles.Domain
{
    public interface IRoleRepository
    {
        Task<IdentityResult> AddRoleAsync(string roleName);
        Task<List<IdentityRole>> GetRolesAsync();
        Task<IdentityResult> RemoveRoleAsync(string roleName);
        Task<bool> RoleExistAsync(string roleName);
        Task<IdentityResult> UpdateRoleAsync(string roleName);
    }
}
