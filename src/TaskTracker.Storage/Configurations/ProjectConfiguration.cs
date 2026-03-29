using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskTracker.Domain;
using TaskTracker.Storage.Extensions;

namespace TaskTracker.Storage.Configurations;

/// <summary>
/// Конфигурация для <see cref="ProjectEntity"/>
/// </summary>
internal class ProjectConfiguration : IEntityTypeConfiguration<ProjectEntity>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.ToTable("project");

        builder.ConfigureBaseColumns();

        builder.HasProperty(x => x.Code, "code").IsRequired(true);
        builder.HasProperty(x => x.Name, "name").IsRequired(true);
        builder.HasProperty(x => x.Key, "key").IsRequired(true);
        builder.HasProperty(x => x.Description, "description").IsRequired(false);

        builder.HasProperty(x => x.CreatedAt, "created_at")
            .HasColumnType("timestamp without time zone")
            .IsRequired(true);
        builder.HasProperty(x => x.UpdatedAt, "updated_at")
            .HasColumnType("timestamp without time zone")
            .IsRequired(false);
    }
}
