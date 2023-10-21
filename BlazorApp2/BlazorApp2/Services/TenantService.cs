using BlazorApp2.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Services
{
    public class TenantService : ITenantService
    {

        private List<Tenant> _tenantList = new List<Tenant>()
        {
            new Tenant
            {
                TenantId="Default",
                ConnectionString=""
            },
    new Tenant{
        TenantId="Gio",
                ConnectionString=""
        } };


        private Tenant Tenant { get; set; }


        public string GetTenantId() => Tenant == null ? string.Empty : Tenant.TenantId;


        public void SetTenant(string tenant)
        {
            Tenant = _tenantList.FirstOrDefault(x => x.TenantId == tenant);
        }

        public Tenant GetTenant() => Tenant;


        public string GetTenantConnectionString() => Tenant == null ? string.Empty : Tenant.ConnectionString;
    }


}
