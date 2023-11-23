﻿namespace Mango.Services.ProductAPI.Data.Repository
{
	public interface IProductRepository
	{
		Task<IEnumerable<ProductModel>> GetProducts();
		Task<ProductModel> GetProductById(Guid productId);

		Task<CreateProductModel> CreateProduct(CreateProductModel data);
		Task<UpdateProductModel> UpdateProduct(UpdateProductModel data);

		/// <summary>
		/// Delete Product from database
		/// </summary>
		/// <param name="productId"></param>
		/// <returns></returns>
		Task<bool> DeleteProduct(Guid productId);

	}
}
