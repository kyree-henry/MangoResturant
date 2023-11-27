namespace Mango.Services.Identity.Register
{
	public interface IWebApplicationRegister : IRegisters
	{
		void RegisterPiplineComponent(WebApplication app);
	}
}
