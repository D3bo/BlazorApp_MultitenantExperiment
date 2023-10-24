using BlazorApp2.Data;
using BlazorApp2.Shared.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Services
{
    public class ProductServices : IProductServices
    {
        private readonly SingleDbContext _context;
        private readonly ITenantService _tenantService;

        public ProductServices(SingleDbContext dbContext, ITenantService tenantService)
        {
            _context = dbContext;
            _tenantService = tenantService;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> AddProduct(Product product)
        {
            product.TenantId = _tenantService.GetTenantId();
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
