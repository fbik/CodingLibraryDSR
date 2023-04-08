using Identity.Properties.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

var services = builder.Services;

services.AddAppCors();

services.AddHttpContextAccessor();

//services.AddAppDbContext(builder.Configuration);

services.AddAppHealthChecks();

//services.RegisterAppServices();

services.AddIs4();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseAppHealthChecks();

app.UseIs4();

app.Run();