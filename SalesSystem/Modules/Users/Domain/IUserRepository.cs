using Microsoft.AspNetCore.Identity;
using SalesSystem.Modules.Users.Domain.Entities;

namespace SalesSystem.Modules.Users.Domain
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetByEmail(string email);
        Task<bool> UserExistAsync(string email);
        Task<IdentityResult> UpdateAsync(User user);
        Task<List<string>> RolesByUserAsync(User user);
        Task<bool> IsUserInRoleAsync(User user, string roleName);
        Task<IdentityResult> AddAsync(User user, string password);
        Task<SignInResult> LoginAync(string email, string password);
        Task<IdentityResult> AddUserToRole(User user, string roleName);
        Task<IdentityResult> RemoveRoleUserAsync(User user, string roleName);
    }
}
