using CodingLibraryDSR.Data.Context;
using CodingLibraryDSR.Data.Setup;
using Services.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextFactory<MainDbContext>();
builder.Services.AddScoped<LanguagesService>();
builder.Services.AddScoped<CategoriesService>();
builder.Services.AddScoped<CommentsService>();
builder.Services.AddScoped<ProblemsService>();
builder.Services.AddScoped<SubscritionsService>();
builder.Services.AddScoped<UsersService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
DbInitializer.Initialize(app.Services);

app.Run();                      