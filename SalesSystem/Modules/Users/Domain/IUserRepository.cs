namespace SalesSystem.Modules.Users.Domain
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<List<User>> GetAll();
        Task<User?> GetByEmail(string email);
    }
}
