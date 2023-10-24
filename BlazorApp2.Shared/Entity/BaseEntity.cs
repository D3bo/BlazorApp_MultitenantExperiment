namespace BlazorApp2.Shared.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string TenantId { get; set; } = null!;
    }
}
