using BlazorApp2.Data;

namespace BlazorApp2.Services
{
    public interface ITenantService
    {
        Tenant GetTenant();
        string GetTenantConnectionString();
        string GetTenantId();
        Task SetTenant(string tenant);

        Task<List<Tenant>> GetTenants();
    }
}