using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Api.Extensions;

/// <summary>
/// Методы расширения для миграции БД.
/// </summary>
public static class MigrateExtension
{
    public static WebApplication Migrate<TContext>(this WebApplication app) where TContext : DbContext
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TContext>();
        dbContext.Database.Migrate();
        return app;
    }
}

