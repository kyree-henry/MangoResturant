namespace Mango_Web.Services
{
	public static partial class ApiRoutes
	{
		public static class Product
		{
			public const string GetAllProducts = "/Product";
			public const string GetProductById = "/Product/{productId}";
			public const string CreateProduct = "/Product";
			public const string UpdateProduct = "/Product";
			public const string DeleteProduct = "/Product/{ProductId}";
		}

	}
}
