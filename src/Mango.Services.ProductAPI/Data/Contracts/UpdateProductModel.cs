namespace Mango.Services.ProductAPI.Data.Contracts
{
	public record UpdateProductModel : CreateProductModel
	{
        public Guid ProductId { get; set; }
    }
}
