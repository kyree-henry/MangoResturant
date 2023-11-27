using Mango.Services.Identity.Data;
using Mango.Services.Identity.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.Identity.Register
{
    public class DbRegister : IWebApplicationBuilderRegister
	{
		public void RegisterServices(WebApplicationBuilder builder)
		{
			builder.Services.AddControllers();

			builder.Services.AddDbContext<ApplicationDbContext>(option =>
			{
				option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

			builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                   .AddEntityFrameworkStores<ApplicationDbContext>()
                   .AddDefaultTokenProviders();
        }
	}
}
