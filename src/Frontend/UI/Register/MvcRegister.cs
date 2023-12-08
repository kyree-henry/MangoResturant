using Mango.UI.Services;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Mango.UI.Register
{
    public class MvcRegister : IWebApplicationBuilderRegister
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(policy =>
            {
                policy.AddPolicy("OpenCorsPolicy", opt =>
                 opt.AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod());
            });

            builder.Services.AddScoped<HttpClientLoggingHandler>();
            builder.Services.Configure<ServiceUrls>(builder.Configuration.GetSection("ServiceUrls"));

            builder.Services.AddLogging(policy =>
            {
                policy.AddConsole();
            });

            builder.Services.AddAuthentication(policy =>
            {
                policy.DefaultScheme = "Cookies";
                policy.DefaultChallengeScheme = "oidc";
            }).AddCookie("Cookies", policy =>
            {
                policy.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            }).AddOpenIdConnect("oidc", policy =>
            {
                policy.Authority = builder.Configuration.GetSection("ServiceUrls")["IdentityAPI"];
                policy.GetClaimsFromUserInfoEndpoint = true;
                policy.ClientId = "mango";
                policy.ClientSecret = "qwertySecret";
                policy.ResponseType = "code";

                policy.TokenValidationParameters.NameClaimType = "name";
                policy.TokenValidationParameters.RoleClaimType = "role";
                policy.Scope.Add("mango");
                policy.SaveTokens = true;
            });

            builder.Services.AddRazorPages().AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.Converters.Add(new StringEnumConverter());
            }).AddJsonOptions(
                options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
                .AddRazorRuntimeCompilation();

            builder.Services.AddScoped<ApiServices>();
        }
    }
}
