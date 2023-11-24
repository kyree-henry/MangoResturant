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

            builder.Services.AddRazorPages().AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.Converters.Add(new StringEnumConverter());
                //option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });;

            builder.Services.AddRazorPages().AddJsonOptions(
                options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
                .AddRazorRuntimeCompilation();

            builder.Services.AddScoped<ApiServices>();
        }
    }
}
