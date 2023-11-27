using Microsoft.AspNetCore.Identity;

namespace Mango.Services.Identity.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Photo { get; set; }
        public string? PhotoBase64 { get; set; }

        public string FullNames => $"{FirstName} {LastName}";
    }
}
