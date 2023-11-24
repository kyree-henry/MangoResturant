using Microsoft.EntityFrameworkCore;

namespace Mango.UI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        // Migration output folder path: -OutputDir Data\Migrations
    }
}
