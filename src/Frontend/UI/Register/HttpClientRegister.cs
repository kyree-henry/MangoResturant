using Mango.UI.Services;
using Polly;
using Polly.Extensions.Http;

namespace Mango.UI.Register
{
    public class HttpClientRegister : IWebApplicationBuilderRegister
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient(ApiServices.HTTP_CLIENT_KEY, client =>
            {
                client.Timeout = TimeSpan.FromSeconds(30);

            }).SetHandlerLifetime(TimeSpan.FromMinutes(15))
            .AddPolicyHandler(GetRetryPolicy())
            .AddPolicyHandler(GetCircuitBreakerPolicy())
            .AddHttpMessageHandler<HttpClientLoggingHandler>();
        }

        /// <summary>
        /// Returns a retry policy, using Polly.
        /// </summary>
        /// <returns></returns>
        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return Policy
                .Handle<HttpRequestException>()
                .OrTransientHttpError()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .WithPolicyKey("RetryPolicy"); // Log policy key for identification.
        }

        /// <summary>
        /// Return a circuit breaker policy, using Polly.
        /// </summary>
        /// <returns></returns>
        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            // Implement and 
            // Example:
            return Policy
                .Handle<HttpRequestException>()
                .OrTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30))
                .WithPolicyKey("CircuitBreakerPolicy"); // Log policy key for identification.
        }
    }

    public class HttpClientLoggingHandler : DelegatingHandler
    {
        private readonly ILogger<HttpClientLoggingHandler> _logger;

        public HttpClientLoggingHandler(ILogger<HttpClientLoggingHandler> logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // Log request details before sending.
            _logger.LogInformation($"Sending request: {request.Method} {request.RequestUri}");

            // Continue with the request.
            var response = await base.SendAsync(request, cancellationToken);

            // Log response details after receiving.
            _logger.LogInformation($"Received response: {response.StatusCode}");

            return response;
        }
    }
}
