using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Data
{
    public class Tenant
    {
        public int Id { get; set; } 
        public string Identifier { get; set; } = default!;
        public string ConnectionString { get; set; } =string.Empty;
    }
}
