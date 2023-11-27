using Mango.Services.Identity.Services;
using Mango.Services.Identity.Services.Abstracts;
using System.Text.Json.Serialization;

namespace Mango.Services.Identity.Register
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

            builder.Services.AddRazorPages();
			builder.Services.AddScoped<IDbInitializer, DbInitializer>();

			builder.Services.AddRazorPages().AddJsonOptions(
				options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
                
            builder.Services.AddEndpointsApiExplorer();
		}
	}
}
