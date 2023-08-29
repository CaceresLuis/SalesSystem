using SalesSystem.Modules.Products.Domain;

namespace SalesSystem.Modules.TempCartItems.Domain
{
    public interface ITempCartItempRepository
    {
        void AddTempCartItem(TempCartItem tempCart);
        void DeleteTempCartItem(TempCartItem tempCart);
        Task<TempCartItem?> ExistTempCartItem(Guid tempUser, ProductId productId);
        Task<IEnumerable<TempCartItem>> GetAllTempCartAsync(Guid tempUser);
        Task<TempCartItem?> GetSimpleTempCartByIdAsync(Guid id);
        Task<TempCartItem?> GetTempCartByIdAsync(Guid id);
        Task<bool> TempUserExist(Guid tempUser);
        void UpdateTempCartItem(TempCartItem tempCart);
    }
}
