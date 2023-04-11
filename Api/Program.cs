using Api.Configuration;
using Database.Data.Context;
using Database.Data.Setup;
using Api.Services;
using Api.Services.Models;
using Cache;
using FluentValidation;
using FluentValidation.AspNetCore;
using Identity.Properties.Configuration;
using Notification;
using RabbitMQ.Client;
using UserAccount.Services;

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
builder.Services.AddScoped<CacheService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddUserAccountService();
builder.Services.AddValidatorsFromAssemblyContaining<PostCategoriesModelValidator>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

var rabbitAddress = builder
    .Configuration
    .GetConnectionString("Rabbit") ?? throw new Exception("No rabbit config");
builder.Services.AddSingleton<IConnectionFactory>(f => new ConnectionFactory
{
    HostName = rabbitAddress.Split(':')[0],
    Port = Int32.Parse(rabbitAddress.Split(':')[1])
});

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