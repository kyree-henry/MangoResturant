using Microsoft.AspNetCore.DataProtection;

namespace Mango.Services.ProductAPI.Register
{
	public class DbRegister : IWebApplicationBuilderRegister
	{
		public void RegisterServices(WebApplicationBuilder builder)
		{
			builder.Services.AddControllers();
			builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

			builder.Services.AddDbContext<ApplicationDbContext>(option =>
			{
				option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			builder.Services.AddDataProtection().PersistKeysToDbContext<ApplicationDbContext>();
			builder.Services.AddScoped<IProductRepository, ProductRepository>();
		}
	}
}
