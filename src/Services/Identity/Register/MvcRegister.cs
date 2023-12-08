using Duende.IdentityServer.Services;
using FormHelper;
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

            builder.Services.AddRazorPages().AddJsonOptions(
				options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())).AddFormHelper();
			builder.Services.AddScoped<IDbInitializer, DbInitializer>();
			builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddEndpointsApiExplorer();
		}
	}
}
