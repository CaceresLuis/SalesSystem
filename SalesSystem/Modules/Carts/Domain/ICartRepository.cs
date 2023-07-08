namespace SalesSystem.Modules.Carts.Domain
{
    public interface ICartRepository
    {
        void Add(Cart cart);
        void Delete(Cart cart);
        Task<Cart?> GetByIdAsync(CartId id);
        Task<IEnumerable<Cart>> GetAllAsync();
    }
}
