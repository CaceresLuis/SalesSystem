using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Users.Domain;
using SalesSystem.Shared.Infrastructure;
using SalesSystem.Modules.Users.Domain.Entities;

namespace SalesSystem.Modules.Users.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(UserManager<User> userManager, ApplicationDbContext context, SignInManager<User> signInManager)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager;
        }

        public async Task LogoutAsync() => await _signInManager.SignOutAsync();

        public async Task<List<string>> RolesByUserAsync(User user)
        {
            IList<string> data = await _userManager.GetRolesAsync(user);

            List<string> roles = new(data);
            return roles;
        }

        public async Task<IdentityResult> UpdateAsync(User user) => await _userManager.UpdateAsync(user);

        public async Task<IdentityResult> AddAsync(User user, string password) => await _userManager.CreateAsync(user, password);

        public async Task<bool> IsUserInRoleAsync(User user, string roleName) => await _userManager.IsInRoleAsync(user, roleName);

        public async Task<IdentityResult> AddUserToRole(User user, string roleName) => await _userManager.AddToRoleAsync(user, roleName);

        public async Task<IdentityResult> RemoveRoleUserAsync(User user, string roleName) => await _userManager.RemoveFromRoleAsync(user, roleName);

        public async Task<bool> UserExistAsync(string email) => await _context.Users.AsNoTracking().AnyAsync(u => u.NormalizedEmail == email.ToUpper());

        public async Task<SignInResult> LoginAync(string email, string password) => await _signInManager.PasswordSignInAsync(email, password, false, true);

        public async Task<IEnumerable<User>> GetAll() => await _context.Users.AsNoTracking().Where(u => u.Cart != null).Include(u => u.Cart).Include(u => u.UserAddres).ToListAsync();

        public async Task<User?> GetByEmail(string email) => await _context.Users.AsNoTracking().Include(u => u.Cart).Include(u => u.UserAddres).Include(u => u.UserCards).FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper());
    }
}
