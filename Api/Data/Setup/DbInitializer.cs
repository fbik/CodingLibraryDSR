namespace CodingLibraryDSR.Data.Setup;

using CodingLibraryDSR.Data.Context;
using Microsoft.EntityFrameworkCore;

static class DbInitializer
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