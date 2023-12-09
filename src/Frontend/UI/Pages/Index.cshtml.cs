using Mango.UI.Data.Contracts.ProductContract;
using Mango.UI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;

namespace Mango.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApiServices _apiServices;
        public IndexModel(ILogger<IndexModel> logger, ApiServices apiServices)
        {
            _apiServices = apiServices;
            _logger = logger;
        }

        public List<ProductModel>? Products { get; set; } = new();
        public async void OnGet()
        {
            try
            {
                ServiceResponse<List<ProductModel>> request = await _apiServices.Product.GetAllProductsAsync();
                if (request.IsSuccess)
                {
                    Products = request.Result;
                }
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, ex.Message);
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            
        }
    }
}
