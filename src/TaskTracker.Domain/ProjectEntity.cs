using TaskTracker.Common.EntityBase;

namespace TaskTracker.Domain;

/// <summary>
/// Проект.
/// </summary>
public class ProjectEntity : BaseNameCodeModel
{
    /// <summary>
    /// Ключ.
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// Описание.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Дата время создания.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата время обновления.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Задачи.
    /// </summary>
    public ICollection<TaskEntity> Tasks { get; set; } = [];
}

