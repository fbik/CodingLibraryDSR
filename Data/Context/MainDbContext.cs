using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CodingLibraryDSR.Data.Context;

using Microsoft.EntityFrameworkCore;

public class MainDbContext : DbContext
{
    private readonly IConfiguration _configuration;

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
    }
}