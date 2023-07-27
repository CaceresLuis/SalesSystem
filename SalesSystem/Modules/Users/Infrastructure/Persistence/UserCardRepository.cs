using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Users.Domain;
using SalesSystem.Shared.Infrastructure;
using SalesSystem.Modules.Users.Domain.Entities;

namespace SalesSystem.Modules.Users.Infrastructure.Persistence
{
    public class UserCardRepository : IUserCardRepository
    {
        private readonly ApplicationDbContext _context;

        public UserCardRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(UserCard userCard) => _context.UserCards.Add(userCard);

        public void Delete(UserCard userCard) => _context.UserCards.Remove(userCard);

        public async Task<UserCard?> Get(Guid id, Guid userId) => await _context.UserCards.AsNoTracking().FirstOrDefaultAsync(uc => uc.Id == id && uc.UserId == userId);
    }
}
