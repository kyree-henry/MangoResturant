namespace Mango.UI.Register
{
    public interface IWebApplicationBuilderRegister : IRegisters
    {
        void RegisterServices(WebApplicationBuilder builder);
    }
}
