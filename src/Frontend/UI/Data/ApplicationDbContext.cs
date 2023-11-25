using Mango.UI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mango.UI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Configuration>()
                .HasMany(c => c.Emails) 
                .WithOne()
                .HasForeignKey(e => e.Id);

            builder.Entity<Configuration>()
                .HasMany(c => c.PhoneNumbers)
                .WithOne()
                .HasForeignKey(p => p.Id);

            builder.Entity<Address>()
                .HasMany(c => c.PhoneNumbers)
                .WithOne()
                .HasForeignKey(p => p.Id);
        }

        // Migration output folder path: -OutputDir Data\Migrations
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<EmailAddress> EmailAddresses => Set<EmailAddress>();
        public DbSet<Configuration> Configurations => Set<Configuration>();
    }

}
