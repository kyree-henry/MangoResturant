using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers.V1
{
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductRepository _productRepository;
		protected ServiceResponse _response;
		public ProductController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
			_response = new ServiceResponse();
		}

		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			try
			{
				IEnumerable<ProductModel> productList = await _productRepository.GetProducts();
				_response.Result = productList;
				_response.IsSuccess = true;

				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages.Add(ex.ToString());
			}

			return BadRequest(_response);
		}


		[HttpGet]
		[Route("{productId}")]
		public async Task<IActionResult> GetAsync([FromQuery] Guid productId)
		{
			try
			{
				ProductModel product = await _productRepository.GetProductById(productId);
				_response.Result = product;

				if (product == null)
				{
					_response.IsSuccess = false;
					return NotFound(_response);
				}

				_response.IsSuccess = true;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages.Add(ex.ToString());
			}

			return BadRequest(_response);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> PostAsync([FromBody] CreateProductModel data)
		{
			try
			{
				CreateProductModel createProduct = await _productRepository.CreateProduct(data);
				if (createProduct != null)
				{
					_response.Result = createProduct;
					_response.IsSuccess = true;

					return Ok(_response);
				}

				_response.IsSuccess = false;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages.Add(ex.ToString());
			}

			return BadRequest(_response);
		}

		[HttpPut]
		[Authorize]
		public async Task<IActionResult> PutAysnc([FromBody] UpdateProductModel data)
		{
			try
			{
				UpdateProductModel updateProduct = await _productRepository.UpdateProduct(data);
				if (updateProduct != null)
				{
					_response.Result = updateProduct;
					_response.IsSuccess = true;

					return Ok(_response);
				}

				_response.IsSuccess = false;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages.Add(ex.ToString());
			}

			return BadRequest(_response);
		}

		[Authorize]
		[HttpDelete]
		[Route("{productId}")]
		public async Task<IActionResult> DeleteAsync([FromQuery] Guid productId)
		{
			try
			{
				bool result = await _productRepository.DeleteProduct(productId);
				_response.IsSuccess = result;
				
				return result ? Ok(_response) : BadRequest(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages.Add(ex.ToString());
			}

			return BadRequest(_response);
		}

	}
}
