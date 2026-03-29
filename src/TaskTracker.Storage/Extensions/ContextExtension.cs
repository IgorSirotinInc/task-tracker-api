using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskTracker.Storage.Context;

namespace TaskTracker.Storage.Extensions;

/// <summary>
/// Методы расширения для <see cref="DbContext"/>.
/// </summary>
public static class ContextExtension
{
    /// <summary>
    /// Зарегистрировать контекст БД.
    /// </summary>
    /// <param name="services">Контейнер DI.</param>
    /// <param name="connectionString">Строка подключения.</param>
    /// <returns>Контейнер DI для дальнейшего цепочечного вызова.</returns>
    public static IServiceCollection AddDbContext(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<TaskTrackerContext>(options =>
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("TaskTracker.Migrations")));

        return services;
    }
}
