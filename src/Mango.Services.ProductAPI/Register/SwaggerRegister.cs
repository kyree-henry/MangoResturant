using Mango.Services.ProductAPI.Register.Options;

namespace Mango.Services.ProductAPI.Register
{
	public class SwaggerRegister : IWebApplicationBuilderRegister
	{
		public void RegisterServices(WebApplicationBuilder builder)
		{
			builder.Services.AddSwaggerGen();
			builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
		}
	}
}
