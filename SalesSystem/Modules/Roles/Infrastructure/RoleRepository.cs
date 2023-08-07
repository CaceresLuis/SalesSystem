using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Roles.Domain;

namespace SalesSystem.Modules.Roles.Infrastructure
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<IdentityRole>> GetRolesAsync() => await _roleManager.Roles.ToListAsync();

        public async Task<bool> RoleExistAsync(string roleName) => await _roleManager.RoleExistsAsync(roleName);

        public async Task<IdentityResult> AddRoleAsync(string roleName) => await _roleManager.CreateAsync(new IdentityRole { Name = roleName });

        public async Task<IdentityResult> RemoveRoleAsync(string roleName) => await _roleManager.DeleteAsync(new IdentityRole { Name = roleName });

        public async Task<IdentityResult> UpdateRoleAsync(string roleName) => await _roleManager.UpdateAsync(new IdentityRole { Name = roleName });
    }
}
