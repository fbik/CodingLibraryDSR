using Database.Data.Context;
using Identity.Properties.Configuration;

var builder = WebApplication.CreateBuilder(args);

//builder.AddAppLogger();

var services = builder.Services;

services.AddAppCors();

services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextFactory<MainDbContext>();

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