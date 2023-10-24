using BlazorApp2.Data;
using BlazorApp2.Shared.Entity;

namespace BlazorApp2.Services
{
    public interface IProductServices
    {
        Task<Product> AddProduct(Product product);
        Task<List<Product>> GetProductsAsync();
    }
}