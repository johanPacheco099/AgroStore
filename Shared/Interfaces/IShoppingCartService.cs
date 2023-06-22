using AgroStore.Shared;

namespace AgroStore.Shared.Interfaces
{
    public interface IShoppingCartService
    {
        Task<List<ShoppingCart>> GetShoppingCarts();
        Task<List<ShoppingCart>> GetUserItems(int userId);
        Task<ShoppingCart> GetShoppingCartByIdAsync(int id);
        Task AddToShoppingCart(ShoppingCart shoppingCart);
        Task UpdateShoppingCart(ShoppingCart shoppingCart);
        Task DeleteShoppingCartAsync(int id);
    }
}
