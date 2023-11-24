namespace Mango.Services.ProductAPI.Register
{
	public interface IWebApplicationBuilderRegister : IRegisters
	{
		void RegisterServices(WebApplicationBuilder builder);
	}
}
