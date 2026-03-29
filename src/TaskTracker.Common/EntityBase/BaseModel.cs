namespace TaskTracker.Common.EntityBase;

/// <summary>
/// Базовая модель для сущностей.
/// </summary>
public abstract class BaseModel
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Глобальный идентификатор.
    /// </summary>
    public Guid Guid { get; set; }
}
