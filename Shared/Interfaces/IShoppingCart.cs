using AgroStore.Shared;

namespace AgroStore.Shared.Interfaces
{
    public interface IShoppingcCart
    {
        Task<List<ShoppingCart>> GetShoppingCartsAsync();
        Task<ShoppingCart> GetShoppingCartByIdAsync(int id);
        Task AddShoppingCart(ShoppingCart shoppingCart);
        Task UpdateShoppingCartAsync(ShoppingCart shoppingCart);
        Task DeleteShoppingCartAsync(int id);
    }
}
