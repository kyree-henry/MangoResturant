namespace Mango.Services.Identity.Register
{
	public interface IWebApplicationBuilderRegister : IRegisters
	{
		void RegisterServices(WebApplicationBuilder builder);
	}
}
