using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace Mango.Services.Identity.Data.Core
{
    public static class SetupData
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
        public const string MangoAPIScope = "mango";

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>()
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Phone(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>() 
        { 
            new (MangoAPIScope, "Mango Server"),
            new ("read", "Read your data."),
            new ("write", "Write your data."),
            new ("delete", "Delete your data.")
        };

        public static IEnumerable<Client> Clients => new List<Client>()
        {
            new()
            {
                ClientId = "client",
                ClientSecrets = { new Secret("c".ToSha256() ) },
                AllowedGrantTypes =  GrantTypes.ClientCredentials,
                AllowedScopes = { "read", "write", "profile" }
            },
            new()
            {
                ClientId = "mango",
                ClientSecrets = { new Secret("qwertySecret".ToSha256() ) },
                AllowedGrantTypes =  GrantTypes.Code,
                RedirectUris = { "https://localhost:44323/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:44323/signout-callback-oidc" },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    MangoAPIScope
                }
            }
        };

    }
}
