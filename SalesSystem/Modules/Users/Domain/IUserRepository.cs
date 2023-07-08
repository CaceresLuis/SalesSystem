using Microsoft.AspNetCore.Identity;

namespace SalesSystem.Modules.Users.Domain
{
    public interface IUserRepository
    {
        Task<IdentityResult> AddAsync(User user, string password);
        Task<IdentityResult> UpdateAsync(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetByEmail(string email);
        Task<bool> UserExistAsync(string email);
        Task<IdentityResult> AddUserToRole(User user, string roleName);
        Task<User?> GetById(Guid id);
    }
}
