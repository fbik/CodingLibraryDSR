using CodingLibraryDSR.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CodingLibraryDSR.Data.Context;

using Microsoft.EntityFrameworkCore;

public class MainDbContext : DbContext
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