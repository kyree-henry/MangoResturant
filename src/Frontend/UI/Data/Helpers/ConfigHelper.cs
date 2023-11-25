using Mango.UI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mango.UI.Data.Helpers
{
    public class ConfigHelper
    {
        private ApplicationDbContext _context;
        public ConfigHelper(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<Configuration?> Data() => await _context.Configurations.FirstOrDefaultAsync(a => a.IsActive);
        public async Task<string?> ApplicationName() => (await Data())?.Name;
    }
}
