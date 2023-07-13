using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Users.Domain;
using SalesSystem.Shared.Infrastructure;

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

        public async Task<IdentityResult> UpdateAsync(User user) => await _userManager.UpdateAsync(user);

        public async Task<IdentityResult> AddAsync(User user, string password) => await _userManager.CreateAsync(user, password);

        public async Task<User?> GetById(Guid id) => await _context.Users.Include(u => u.Cart).FirstOrDefaultAsync(u => u.Id == id);

        public async Task<IdentityResult> AddUserToRole(User user, string roleName) => await _userManager.AddToRoleAsync(user, roleName);

        public async Task<bool> UserExistAsync(string email) => await _context.Users.AsNoTracking().AnyAsync(u => u.NormalizedEmail == email.ToUpper());

        public async Task<SignInResult> LoginAync(string email, string password) => await _signInManager.PasswordSignInAsync(email, password, false, true);

        public async Task<IEnumerable<User>> GetAll() => await _userManager.Users.AsNoTracking().Where(u => u.Cart != null).Include(u => u.Cart).ToListAsync();

        public async Task<User?> GetByEmail(string email) => await _context.Users.Include(u => u.Cart).FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper());

    }
}
