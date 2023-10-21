using BlazorApp2.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Services
{
    public class TenantService : ITenantService
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public TenantService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        private Tenant Tenant { get; set; }


        public string GetTenantId() => Tenant == null ? string.Empty : Tenant.Identifier;


        public async Task SetTenant(string tenant)
        {
            Tenant = await _applicationDbContext.Tenants.FirstOrDefaultAsync(t => t.Identifier == tenant);
        }

        public Tenant GetTenant() => Tenant;


        public string GetTenantConnectionString() => Tenant == null ? string.Empty : Tenant.ConnectionString;
    }


}
