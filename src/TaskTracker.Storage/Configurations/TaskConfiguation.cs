using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskTracker.Domain;
using TaskTracker.Storage.Extensions;

namespace TaskTracker.Storage.Configurations;

/// <summary>
/// Конфигурация для <see cref="TaskEntity"/>
/// </summary>
internal class TaskConfiguation : IEntityTypeConfiguration<TaskEntity>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.ToTable("task");

        builder.ConfigureBaseColumns();

        builder.HasProperty(x => x.Number, "number").IsRequired(true);
        builder.HasProperty(x => x.Title, "title").IsRequired(true);
        builder.HasProperty(x => x.Key, "key").IsRequired(true);
        builder.HasProperty(x => x.Description, "description").IsRequired(false);
        builder.HasProperty(x => x.Status, "status").IsRequired(true);
        builder.HasProperty(x => x.Priority, "priority").IsRequired(true);

        builder.HasProperty(x => x.CreatedAt, "created_at")
            .HasColumnType("timestamp without time zone")
            .IsRequired(true);
        builder.HasProperty(x => x.UpdatedAt, "updated_at")
            .HasColumnType("timestamp without time zone")
            .IsRequired(false);

        builder.HasProperty(x => x.ProjectId, "project_id").IsRequired(true);
        builder
            .HasOne(x => x.Project)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

