namespace Mango.Services.Identity.Register
{
	public static class RegistrarExtensions
	{
		public static void RegisterServices(this WebApplicationBuilder builder, Type scanningType)
		{
			var registrars = GetRegistrars<IWebApplicationBuilderRegister>(scanningType);

			foreach (var registrar in registrars)
			{
				registrar.RegisterServices(builder);
			}
		}

		public static void RegisterPiplineComponents(this WebApplication app, Type scanningType)
		{
			var registrars = GetRegistrars<IWebApplicationRegister>(scanningType);

			foreach (var registrar in registrars)
			{
				registrar.RegisterPiplineComponent(app);
			}
		}

		private static IEnumerable<T> GetRegistrars<T>(Type scanningType) where T : IRegisters
		{
			var registrars = scanningType.Assembly.GetTypes()
				.Where(t => t.IsAssignableTo(typeof(T)) && !t.IsAbstract && !t.IsInterface)
				.Select(Activator.CreateInstance).Cast<T>();

			return registrars;
		}
	}
}
