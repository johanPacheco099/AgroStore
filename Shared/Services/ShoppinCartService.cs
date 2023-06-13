using AgroStore.Shared;
using AgroStore.Shared;
using AgroStore.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AgroStore.Shared.Services
{
    public class ShoppingCartService : IShoppingcCart
    {
        private readonly AppDbcontext _dbContext;
        public ShoppingCartService(AppDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddShoppingCart(ShoppingCart shoppingCart)
        {
            _dbContext.shoppingCart.Add(shoppingCart);
            await _dbContext.SaveChangesAsync();
        }

        Task IShoppingcCart.DeleteShoppingCartAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ShoppingCart> IShoppingcCart.GetShoppingCartByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<ShoppingCart>> IShoppingcCart.GetShoppingCartsAsync()
        {
            throw new NotImplementedException();
        }

        Task IShoppingcCart.UpdateShoppingCartAsync(ShoppingCart shoppingCart)
        {
            throw new NotImplementedException();
        }
    }

    


}