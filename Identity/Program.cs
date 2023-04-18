using Database.Data.Context;
using Identity.Properties.Configuration;
using static Microsoft.AspNetCore.Builder.WebApplication;

var builder = CreateBuilder(args);

//builder.AddAppLogger();

//var mainSettings = Settings.Load<MainSettings>("Main");
//var swaggerSettings = Settings.Load<Bootstrapper.SwaggerSettings>("Swagger");
//var identitySettings = Settings.Load<IdentitySettings>("Identity");


var services = builder.Services;

services.AddAppCors();

services.AddHttpContextAccessor();
builder.Services.AddIs4();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextFactory<MainDbContext>();
builder.Services.AddIdentitySettings();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddMainSettings();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddAppCors();
builder.Services.AddAppHealthChecks();

builder.Services.AddDbContext<MainDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapGet("/", () => "Hello World!");
app.UseAppHealthChecks();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

app.UseIs4();

app.Run();
