using Mango.UI.Services.Abstracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Refit;
using System.Net.Http.Headers;

namespace Mango.UI.Services
{
    public class ApiServices
    {
        public const string HTTP_CLIENT_KEY = "MangoAPI";
        private readonly RefitSettings _settings;
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _context;

        public ApiServices(IHttpClientFactory http,
                           IOptions<ServiceUrls> options,
                           IHttpContextAccessor context)
        {
            _client = http.CreateClient(HTTP_CLIENT_KEY);

            _settings = new RefitSettings(new NewtonsoftJsonContentSerializer())
            {
                AuthorizationHeaderValueGetter = (request, cancellationToken) =>
                {
                    string? token = Task.Run(async () =>
                    {
                        return await _context!.HttpContext!.GetTokenAsync("access_token") ?? string.Empty;
                    }).GetAwaiter().GetResult();

                    return Task.FromResult(token!);
                }
            };

            ServiceUrls serviceUrls = options.Value;
            Product = RestService.For<IProduct>(serviceUrls.ProductAPI!, _settings);
            _context = context;
        }

        public IProduct Product { get; }
    }
}
