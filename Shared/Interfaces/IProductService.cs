using AgroStore.Shared;

namespace AgroStore.Shared.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductById(int productId);
        Task<Product> AddProduct(Product product);
        void UpdatProduct(Product product);
        void DeleteProduct(int productId);
        List<Product>GetAllProducts();
    }
}
