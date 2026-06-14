namespace TaskTracker.Common.EntityBase;

/// <summary>
/// Базовая модель для сущностей.
/// </summary>
public abstract class BaseModel<TIdentifier> where TIdentifier : struct
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public TIdentifier Id { get; set; }

    /// <summary>
    /// Глобальный идентификатор.
    /// </summary>
    public Guid Guid { get; set; }
}
