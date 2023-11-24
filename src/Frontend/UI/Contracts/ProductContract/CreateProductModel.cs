namespace Mango.UI.Contracts.ProductContract
{
    public record CreateProductModel
    {
        public string Name { get; set; } = default!;
        public double Price { get; set; } = default!;

        public string? Description { get; set; }
        public string? CategoryName { get; set; }
    }
}
