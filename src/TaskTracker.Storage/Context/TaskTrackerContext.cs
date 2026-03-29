using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Storage.Context;

/// <summary>
/// Контекст БД task-tracker.
/// </summary>
public class TaskTrackerContext(DbContextOptions<TaskTrackerContext> options) : DbContext(options)
{
    // public DbSet<TaskEntity> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Конфигурации сущностей
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskTrackerContext).Assembly);
    }
}
