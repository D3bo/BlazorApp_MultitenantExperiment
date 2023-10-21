using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Data
{
    public class Tenant
    {

        public string TenantId { get; set; } = string .Empty;
        public string Name { get; set; } = default!;
        public string ConnectionString { get; set; } =string.Empty;
    }
}
