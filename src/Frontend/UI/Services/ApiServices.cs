using Mango.UI.Services.Abstracts;
using Refit;

namespace Mango.UI.Services
{
    public class ApiServices
    {
        public const string HTTP_CLIENT_KEY = "MangoAPI";
        private readonly RefitSettings _settings;
        private readonly HttpClient _client;

        public ApiServices(IHttpClientFactory http)
        {
            _client = http.CreateClient(HTTP_CLIENT_KEY);
            _settings = new RefitSettings(new NewtonsoftJsonContentSerializer())
            {

            };

            Product = RestService.For<IProduct>("", _settings);
        }

        public IProduct Product { get; }
    }
}
