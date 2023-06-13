using AgroStore.Shared;
using AgroStore.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AgroStore.Shared.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbcontext _dbContext;
        public ProductService(AppDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> AddProduct(Product product)
        {
            if (product != null)
            {
                await _dbContext.product.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return product;
            }
            else
            {
                throw new ArgumentNullException(nameof(product), "El objeto product no puede ser nulo.");
            }
        }
        public void DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }
        public List<Product> GetAllProducts()
        {
            return _dbContext.product?.ToList() ?? new List<Product>();
        }

        public async Task<Product> GetProductById(int productId)
        {
            var product = await _dbContext.FindAsync<Product>(productId);
            return product;
        }



        public void UpdatProduct(Product product)
        {
            throw new NotImplementedException();
        }

    }

}