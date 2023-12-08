using FormHelper;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Mango.Services.Identity.Register
{
	public class MvcWebAppRegister : IWebApplicationRegister
	{
		public void RegisterPiplineComponent(WebApplication app)
		{
			app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
			app.UseIdentityServer();
			app.UseAuthorization();
			app.UseFormHelper();

			app.UseCors("OpenCorsPolicy");
            app.MapRazorPages();
        }

    }
}
