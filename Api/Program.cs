using Api.CodingLibraryDSR.Data.Context;
using Api.CodingLibraryDSR.Data.Setup;
using Api.Services;
using Api.Services.Models;
using FluentValidation;
using FluentValidation.AspNetCore;

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
builder.Services.AddScoped<SubscriptionsService>();
builder.Services.AddScoped<UsersService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<PostCategoriesModelValidator>();

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