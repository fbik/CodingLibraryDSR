using Api.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Api.Data.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class MainDbContext : IdentityDbContext<Users, IdentityRole<Guid>, Guid>
{
    private readonly IConfiguration _configuration;
    public DbSet<Problems> Problems { get; set; }
    public DbSet<Languages> Languages { get; set; }
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<Comments> Comments { get; set; }
    public DbSet<Subscriptions> Subscriptions { get; set; }

    public MainDbContext(
        IConfiguration configuration,
        DbContextOptions<MainDbContext> options
    ) : base(options)
    {
        _configuration = configuration;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Postgres"));
        optionsBuilder.UseSnakeCaseNamingConvention();
    }
}