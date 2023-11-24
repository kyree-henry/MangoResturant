using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Mango.UI.Register
{
    public class MvcWebAppRegister : IWebApplicationRegister
    {
        public void RegisterPiplineComponent(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();  
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("OpenCorsPolicy");
            app.MapRazorPages();
        }

    }
}
