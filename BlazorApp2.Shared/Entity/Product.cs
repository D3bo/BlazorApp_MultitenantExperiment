namespace BlazorApp2.Shared.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
