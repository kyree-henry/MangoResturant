WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
builder.RegisterServices(typeof(Program));

WebApplication? app = builder.Build();
app.RegisterPiplineComponents(typeof(Program));

app.Run();