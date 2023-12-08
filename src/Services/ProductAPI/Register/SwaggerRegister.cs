using Mango.Services.ProductAPI.Register.Options;
using Microsoft.OpenApi.Models;

namespace Mango.Services.ProductAPI.Register
{
    public class SwaggerRegister : IWebApplicationBuilderRegister
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.AddSecurityDefinition("Bearer", new()
                {
                    Description = @"Enter 'Bearer' [Space] and your token",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new ()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new ()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
        }
    }
}
