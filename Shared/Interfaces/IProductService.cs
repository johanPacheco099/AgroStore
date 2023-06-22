using AgroStore.Shared;

namespace AgroStore.Shared.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductById(int id_product);
        Task<Product> AddProduct(Product product);
        void UpdatProduct(Product product);
        void DeleteProduct(int id_product);
        List<Product>GetAllProducts();
    }
}
