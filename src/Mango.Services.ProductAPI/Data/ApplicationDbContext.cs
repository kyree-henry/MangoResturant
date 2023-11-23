using Mango.Services.ProductAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
