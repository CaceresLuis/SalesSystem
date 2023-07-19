using SalesSystem.Modules.Users.Domain;
using SalesSystem.Shared.Infrastructure;
using SalesSystem.Modules.Users.Domain.Entities;

namespace SalesSystem.Modules.Users.Infrastructure.Persistence
{
    public class UserAddressRepository : IUserAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public UserAddressRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(UserAddres userAddres) => _context.UserAddres.Add(userAddres);

        public void Update(UserAddres userAddres) => _context.UserAddres.Update(userAddres);

        public void Delete(UserAddres userAddres) => _context.UserAddres.Remove(userAddres);
    }
}
