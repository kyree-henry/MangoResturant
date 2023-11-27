using Mango.Services.Identity.Services.Abstracts;

namespace Mango.Services.Identity.Data.Extensions
{
    public static class HostExtensions
    {
        public static IHost InitializeDatabase(this IHost host)
        {
            ExecuteDbInitializerAsync(host).Wait(); // Wait for the asynchronous operation to complete
            return host;
        }

        private static async Task ExecuteDbInitializerAsync(IHost host)
        {
            using (var serviceScope = host.Services.CreateScope())
            {
                IDbInitializer? service = serviceScope.ServiceProvider.GetService<IDbInitializer>();
                if (service != null)
                {
                    await service.Initialize();
                }
            }
        }
    }

}
