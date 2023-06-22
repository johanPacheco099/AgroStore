using AgroStore.Shared;
using AgroStore.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AgroStore.Shared.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly AppDbcontext _dbContext;
        public ShoppingCartService(AppDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddToShoppingCart(ShoppingCart shoppingCart)
        {
            if (shoppingCart != null)
            {
                // var product = new Product
                // {
                //     price = shoppingCart.price,
                //     quantity = shoppingCart.quantity
                // };

                //shoppingCart.product = product;

                await _dbContext.shoppingCart.AddAsync(shoppingCart);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(shoppingCart), "El producto a agregar no puede ser nulo.");
            }
        }

        public async Task<List<ShoppingCart>> GetUserItems(int userId)
        {
            return await _dbContext.shoppingCart
                .Where(c => c.id_user == userId)
                .ToListAsync();
        }
        public Task DeleteShoppingCartAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> GetShoppingCartByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ShoppingCart>> GetShoppingCarts()
        {
            return Task.FromResult(_dbContext.shoppingCart?.ToList() ?? new List<ShoppingCart>());
        }


        public Task UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            throw new NotImplementedException();
        }
    }




}