using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ProductAPI.Data.Entities
{
	public class Product
	{
		[Key]
        public Guid ProductId { get; set; }

		public string Name { get; set; } = default!;

		[Range(1, 1000)]
        public double Price { get; set; }

		public string? Description { get; set; }

        public string? CategoryName { get; set; }

        public string? ImageUrl { get; set; }
    }
}
