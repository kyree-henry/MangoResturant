using Mango.UI.Services.Abstracts;
using Microsoft.Extensions.Options;
using Refit;

namespace Mango.UI.Services
{
    public class ApiServices
    {
        public const string HTTP_CLIENT_KEY = "MangoAPI";
        private readonly RefitSettings _settings;
        private readonly HttpClient _client;
        public ApiServices(IHttpClientFactory http, IOptions<ServiceUrls> options)
        {
            _client = http.CreateClient(HTTP_CLIENT_KEY);
            _settings = new RefitSettings(new NewtonsoftJsonContentSerializer())
            {

            };

            ServiceUrls serviceUrls = options.Value;
            Product = RestService.For<IProduct>(serviceUrls.ProductAPI!, _settings);
        }

        public IProduct Product { get; }
    }
}
