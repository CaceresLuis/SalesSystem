using Microsoft.AspNetCore.Identity;

namespace SalesSystem.Modules.Users.Domain
{
    public interface IUserRepository
    {
        Task<User?> GetById(Guid id);
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetByEmail(string email);
        Task<bool> UserExistAsync(string email);
        Task<IdentityResult> UpdateAsync(User user);
        Task<SignInResult> LoginAync(string email, string password);
        Task<IdentityResult> AddAsync(User user, string password);
        Task<IdentityResult> AddUserToRole(User user, string roleName);
    }
}
