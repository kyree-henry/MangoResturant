using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using Mango.Services.Identity.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Mango.Services.Identity.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;

        public ProfileService(UserManager<ApplicationUser> userManager, 
                              RoleManager<ApplicationRole> roleManager, 
                              IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string userId = context.Subject.GetSubjectId();
            ApplicationUser? user = await _userManager.FindByIdAsync(userId);
            ClaimsPrincipal userClaims = await _userClaimsPrincipalFactory.CreateAsync(user!);

            List<Claim> claims = userClaims.Claims.ToList();
            claims = claims.Where(claims => context.RequestedClaimTypes.Contains(claims.Type)).ToList();
            claims.Add(new (JwtClaimTypes.FamilyName, user!.LastName!));
            claims.Add(new (JwtClaimTypes.GivenName, user!.FirstName!));

            if (_userManager.SupportsUserRole)
            {
                IList<string> roles = await _userManager.GetRolesAsync(user);
                foreach (var roleName in roles)
                {
                    claims.Add(new Claim(JwtClaimTypes.Role, roleName));
                    if (_roleManager.SupportsRoleClaims)
                    {
                        ApplicationRole? role = await _roleManager.FindByNameAsync(roleName);
                        if (role != null)
                        {
                            claims.AddRange(await _roleManager.GetClaimsAsync(role));
                        }
                    }
                }
            }
        }
         
        public async Task IsActiveAsync(IsActiveContext context)
        {
            string userId = context.Subject.GetSubjectId();
            ApplicationUser? user = await _userManager.FindByIdAsync(userId);
            context.IsActive = user != null;
        }
    }
}
