using Database.Data.Context;
using Identity.Properties.Configuration;

var builder = WebApplication.CreateBuilder(args);

//builder.AddAppLogger();

var mainSettings = Settings.Load<MainSettings>("Main");
var swaggerSettings = Settings.Load<Bootstrapper.SwaggerSettings>("Swagger");
var identitySettings = Settings.Load<IdentitySettings>("Identity");


var services = builder.Services;

services.AddAppCors();

services.AddHttpContextAccessor();
builder.Services.AddIs4();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextFactory<MainDbContext>();
builder.Services.AddIdentitySettings();
builder.Services.AddMainSettings();
builder.Services.AddMainSettings();

//services.AddAppDbContext(builder.Configuration);

services.AddAppHealthChecks();

//services.RegisterAppServices();

services.AddIs4();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapGet("/", () => "Hello World!");
app.UseAppHealthChecks();

app.UseIs4();

app.Run();
