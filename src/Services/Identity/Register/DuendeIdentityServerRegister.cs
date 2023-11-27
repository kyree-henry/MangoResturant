
using Mango.Services.Identity.Data.Core;
using Mango.Services.Identity.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Mango.Services.Identity.Register
{
	public class DuendeIdentityServerRegister : IWebApplicationBuilderRegister
	{
		public void RegisterServices(WebApplicationBuilder builder)
		{
            IdentityServerBuilder(builder).AddDeveloperSigningCredential();
        }

		private static IIdentityServerBuilder IdentityServerBuilder(WebApplicationBuilder builder)
		{
			return builder.Services.AddIdentityServer(option =>
            {
                option.Events.RaiseErrorEvents = true;
                option.Events.RaiseInformationEvents = true;
                option.Events.RaiseFailureEvents = true;
                option.Events.RaiseSuccessEvents = true;
                option.EmitStaticAudienceClaim = true;

            }).AddInMemoryIdentityResources(SetupData.IdentityResources)
            .AddInMemoryApiScopes(SetupData.ApiScopes)
            .AddInMemoryClients(SetupData.Clients)
            .AddAspNetIdentity<ApplicationUser>();
        }
		 
	}
}
