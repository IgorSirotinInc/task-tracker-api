namespace TaskTracker.Common.EntityBase;

/// <summary>
/// Базовая модель для сущностей с наименованием.
/// </summary>
public class BaseGuidNameModel<TIdentifier> : BaseModel<TIdentifier> where TIdentifier : struct
{
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
