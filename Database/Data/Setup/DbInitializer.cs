namespace Database.Data.Setup;

using Database.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


public static class DbInitializer
{
    static public void Initialize(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetService<IServiceProvider>()?.CreateScope();
        ArgumentNullException.ThrowIfNull(scope);

        var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>();
        var context = dbContextFactory.CreateDbContext();
        context.Database.Migrate(); //Миграция
        
    }
}