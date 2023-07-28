namespace SalesSystem.Modules.Buys.Domain
{
    public interface IBuyRepository
    {
        void Add(Buy buy);
        void Delete(Buy buy);
        Task<Buy?> GetByIdAsync(BuyId id);
        Task<IEnumerable<Buy>> GetAllAsync(Guid userId);
    }
}
