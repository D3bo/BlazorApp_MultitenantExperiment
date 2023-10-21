using BlazorApp2.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorApp2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Tenant> Tenants { get; set; }




    }
        
        

    public class SingleDbContext : DbContext
    {

        private readonly string _tenantId = string.Empty;

        public SingleDbContext(DbContextOptions<SingleDbContext> options, ITenantService tenantService) : base(options)
        {
            _tenantId = tenantService.GetTenantId();

        }

       
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {         
            builder.Entity<Product>()
                .HasQueryFilter(p => p.TenantId == _tenantId);

            base.OnModelCreating(builder);
        }
    }

}
