using TaskTracker.Common.EntityBase;

namespace TaskTracker.Domain;

/// <summary>
/// Задача.
/// </summary>
public class TaskEntity : BaseModel
{
    /// <summary>
    /// Идентификатор проекта.
    /// </summary>
    public int ProjectId { get; set; }

    /// <summary>
    /// Проект.
    /// </summary>
    public ProjectEntity Project { get; set; } = null!;

    /// <summary>
    /// Номер.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Заголовок.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Ключ.
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// Описание.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Статус.
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Приоритет.
    /// </summary>
    public string Priority { get; set; } = string.Empty;

    /// <summary>
    /// Дата время создания.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата время обновления.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
