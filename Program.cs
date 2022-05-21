using WebApiKalum;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

// Add services to the container.

var app = builder.Build();

startup.Configure(app,app.Environment);

app.Run();
