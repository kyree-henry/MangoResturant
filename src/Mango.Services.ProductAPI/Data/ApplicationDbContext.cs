using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Data
{
	public class ApplicationDbContext : DbContext, IDataProtectionKeyContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

		// Migration output folder path: -OutputDir Data\Migrations
		public DbSet<Product> Products => Set<Product>();
		public DbSet<DataProtectionKey> DataProtectionKeys => Set<DataProtectionKey>();
	}
}
