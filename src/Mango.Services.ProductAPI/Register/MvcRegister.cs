using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Newtonsoft.Json.Converters;

namespace Mango.Services.ProductAPI.Register
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

			builder.Services.AddControllers().AddNewtonsoftJson(option =>
			{
				option.SerializerSettings.Converters.Add(new StringEnumConverter());
				//option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
			});

			builder.Services.AddApiVersioning(options =>
			{
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.DefaultApiVersion = new ApiVersion(1, 0);
				options.ReportApiVersions = true;
				options.ApiVersionReader = new UrlSegmentApiVersionReader();
			});

			builder.Services.AddVersionedApiExplorer(options =>
			{
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
			});

			builder.Services.AddEndpointsApiExplorer();
		}
	}
}
