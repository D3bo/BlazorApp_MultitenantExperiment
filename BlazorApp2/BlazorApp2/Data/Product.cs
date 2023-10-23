namespace BlazorApp2.Data
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
