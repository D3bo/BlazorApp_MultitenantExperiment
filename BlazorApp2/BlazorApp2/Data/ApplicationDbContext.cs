using BlazorApp2.Services;
using BlazorApp2.Shared.Entity;
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

    public class MultipleDbContext : DbContext
    {
        private readonly ITenantService _tenantService;
        private readonly IConfiguration _configuration;
        public MultipleDbContext(DbContextOptions<MultipleDbContext> options, ITenantService tenantService, IConfiguration configuration) : base(options)
        {
            _tenantService = tenantService;
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenant = _tenantService.GetTenant();
            var connectionString = tenant.ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Customer> Customers { get; set; }
        
    }

}
