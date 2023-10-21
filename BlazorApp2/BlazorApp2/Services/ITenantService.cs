using BlazorApp2.Data;

namespace BlazorApp2.Services
{
    public interface ITenantService
    {
        Tenant GetTenant();
        string GetTenantConnectionString();
        string GetTenantId();
        void SetTenant(string tenant);
    }
}