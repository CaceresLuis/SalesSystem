namespace SalesSystem.Modules.Users.Domain
{
    public interface IUserRepository
    {
        Task AddAsync(User user, string password);
        Task UpdateAsync(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetByEmail(string email);
    }
}
