using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Mango.Services.Identity.Register
{
	public class MvcWebAppRegister : IWebApplicationRegister
	{
		public void RegisterPiplineComponent(WebApplication app)
		{
			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseIdentityServer();
			app.UseAuthorization();

			app.UseCors("OpenCorsPolicy");
            app.MapRazorPages();
        }

    }
}
