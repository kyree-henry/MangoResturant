namespace Mango.UI.Contracts.ProductContract
{
    public record UpdateProductModel : CreateProductModel
    {
        public Guid ProductId { get; set; }
    }
}
