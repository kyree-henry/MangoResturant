using Mango.UI.Data.Contracts.ProductContract;
using Mango_Web.Services;
using Refit;

namespace Mango.UI.Services.Abstracts
{
    [Headers("Authorization: Bearer")]
    public interface IProduct
    {
        [Get(ApiRoutes.Product.GetAllProducts)]
        Task<ServiceResponse<List<ProductModel>>> GetAllProductsAsync();

        [Get(ApiRoutes.Product.GetProductById)]
        Task<ServiceResponse<ProductModel>> GetProductByIdAsync(Guid productId);

        [Post(ApiRoutes.Product.CreateProduct)]
        Task<ServiceResponse<ProductModel>> CreateProductAsync(CreateProductModel data);

        [Put(ApiRoutes.Product.UpdateProduct)]
        Task<ServiceResponse<ProductModel>> UpdateProductAsync(CreateProductModel data);

        [Delete(ApiRoutes.Product.DeleteProduct)]
        Task<ServiceResponse<bool>> DeleteProductAysnc(Guid productId);
    }
}
