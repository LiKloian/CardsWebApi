using Microsoft.EntityFrameworkCore;

namespace CardsWebApi.Data.Extensions;

public static class DbExtensions
{
    public static IApplicationBuilder UseDatabaseMigration<TDbContext>(this IApplicationBuilder builder) where TDbContext : DbContext
    {
        using var serviceScope = builder.ApplicationServices.CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetService<TDbContext>();
        //var logger = serviceScope.ServiceProvider.GetService<ILoggerFactory>()?.CreateLogger("MigrateDatabase");

        if (dbContext == null)
        {
            //logger?.LogError("Migrate database for {DbContext} failed, please add database context to service collection", typeof(TDbContext).Name);
            throw new InvalidOperationException($"Migrate database for {typeof(TDbContext).Name} failed, please add database context to service collection");
        }

        dbContext.Database.Migrate();

        return builder;
    }
}