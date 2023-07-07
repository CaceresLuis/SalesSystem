namespace SalesSystem.Modules.Carts.Domain
{
    public interface ICartRepository
    {
        void Add(Cart cart);
        void Delete(Cart cart);
        Task<Cart?> GetByIdAsync(Guid id);
        Task<IEnumerable<Cart>> GetAllAsync();
    }
}
