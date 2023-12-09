using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Mango.Services.ProductAPI.Register
{
	public class MvcWebAppRegister : IWebApplicationRegister
	{
		public void RegisterPiplineComponent(WebApplication app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

				foreach (var description in provider.ApiVersionDescriptions)
				{
					options.SwaggerEndpoint($"/swagger/{description!.GroupName}/swagger.json", description!.GroupName.ToUpperInvariant());
				}
			});

			app.UseHttpsRedirection();
			app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("OpenCorsPolicy");

			app.MapControllers();
		}

	}
}
