using BlazorApp2.Data;

namespace BlazorApp2.Services
{
    public interface IProductServices
    {
        Task<Product> AddProduct(Product product);
        Task<List<Product>> GetProductsAsync();
    }
}