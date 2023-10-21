using BlazorApp2.Services;
using System.Net.WebSockets;

namespace BlazorApp2.Data
{
    public  class SeedData
    {
        public static void InitializeMultiDb(MultipleDbcontext multipleDbcontext, ITenantService tenantService)
        {
            var tenants = tenantService.GetTenants();

            foreach (var tenantDb in tenants)
            {
                multipleDbcontext.Remove(tenantDb);
            }





            
            multipleDbcontext.SaveChanges();
        }

        public static void InitializeSingleDb(SingleDbContext singleDbContext)
        {
            singleDbContext.Database.EnsureCreated();
        }

       
    }
}
