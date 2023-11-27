using Microsoft.AspNetCore.Identity;

namespace Mango.Services.Identity.Data.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        { }

        public ApplicationRole(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public string Description { get; set; }
    }
}
