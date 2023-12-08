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
			});


			builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
			{
				options.Authority = builder.Configuration.GetSection("AuthSettings")["Authority"];
				options.TokenValidationParameters = new()
				{
					ValidateAudience = false
                };
			});

            // Add Authorization Policy => ApiScope
            builder.Services.AddAuthorization(options =>
			{
				options.AddPolicy("ApiScope", policy =>
				{
					policy.RequireAuthenticatedUser();
					policy.RequireClaim("Scope", "mango");
				});
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
