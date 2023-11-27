using Mango.Services.Identity.Data.Extensions;
using Mango.Services.Identity.Register;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
builder.RegisterServices(typeof(Program));

WebApplication? app = builder.Build();
app.RegisterPiplineComponents(typeof(Program));

app.InitializeDatabase().Run();