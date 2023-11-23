using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Mango.Services.ProductAPI.Register.Options
{
	public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
	{
		private readonly IApiVersionDescriptionProvider _provider;
		public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
		{
			_provider = provider;
		}

		public void Configure(SwaggerGenOptions options)
		{
			foreach (ApiVersionDescription description in _provider.ApiVersionDescriptions)
			{
				options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
			}
		}

		private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
		{
			OpenApiInfo info = new ()
			{
				Title = $"Product API {description.ApiVersion}",
				Version = description.ApiVersion.ToString(),
				Description = "Mango Resturant Product API",
				Contact = new OpenApiContact() { Name = "Kyree Henry", Email = "ene.henry.eh@gmail.com" }
			};

			if (description.IsDeprecated)
			{
				info.Description += " This API version has been deprecated.";
			}

			return info;
		}
	}
}
