using IdentityModel;
using Mango.Services.Identity.Data;
using Mango.Services.Identity.Data.Core;
using Mango.Services.Identity.Data.Entities;
using Mango.Services.Identity.Services.Abstracts;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Mango.Services.Identity.Services
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public DbInitializer(ApplicationDbContext context,
                               UserManager<ApplicationUser> userManager,
                               RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initialize()
        {
            if (_roleManager.FindByNameAsync(SetupData.Admin).Result == null)
            {
                _roleManager.CreateAsync(new ApplicationRole(SetupData.Admin, "Admin: Controls and maintains app functionality.")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new ApplicationRole(SetupData.Customer, "Customer: Utilizes app features for personalized experiences.")).GetAwaiter().GetResult();
            }
            else return;

            ApplicationUser adminUser = await RegisterUserAsync("Doe", "Admin", "resturantadmin@gmail.com", "00000000000", SetupData.Admin, "Adin124*");
            IdentityResult identityResult1 =  await AddClaimAsync(adminUser, SetupData.Admin);

            ApplicationUser customerUser = await RegisterUserAsync("John", "Doe", "johndoe@gmail.com", "00000000000", SetupData.Customer, "Customer125*");
            IdentityResult identityResult2 = await AddClaimAsync(customerUser, SetupData.Customer);
        }

        private async Task<ApplicationUser> RegisterUserAsync(string firstName, string lastName, string email, string phoneNumber, string roleName, string password)
        {
            ApplicationUser newUser = new()
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                LastName = lastName
            };

            await _userManager.CreateAsync(newUser, password);
            await _userManager.AddToRoleAsync(newUser, roleName);

            return newUser;
        }

        private async Task<IdentityResult> AddClaimAsync(ApplicationUser applicationUser, string roleName)
        {
            return await _userManager.AddClaimsAsync(applicationUser, new Claim[]
            {
                new(JwtClaimTypes.Name, applicationUser.UserName!),
                new(JwtClaimTypes.GivenName, applicationUser.FirstName!),
                new(JwtClaimTypes.FamilyName, applicationUser.LastName!),
                new(JwtClaimTypes.Role, roleName)
            });
        }
    }
}
