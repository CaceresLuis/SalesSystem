using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Users.Domain;

namespace SalesSystem.Modules.Users.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<IEnumerable<User>> GetAll() => await _userManager.Users.ToListAsync();

        public async Task UpdateAsync(User user) => await _userManager.UpdateAsync(user);

        public async Task<User?> GetByEmail(string email) => await _userManager.FindByEmailAsync(email);

        public async Task AddAsync(User user, string password) => await _userManager.CreateAsync(user, password);
    }
}
