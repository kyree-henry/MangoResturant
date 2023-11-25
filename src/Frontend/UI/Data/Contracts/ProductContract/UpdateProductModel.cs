namespace Mango.UI.Data.Contracts.ProductContract
{
    public record UpdateProductModel : CreateProductModel
    {
        public Guid ProductId { get; set; }
    }
}
