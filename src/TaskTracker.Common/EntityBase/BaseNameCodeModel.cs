namespace TaskTracker.Common.EntityBase;

/// <summary>
/// Базовая модель с кодом.
/// </summary>
public abstract class BaseNameCodeModel : BaseModel
{
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Код.
    /// </summary>
    public string Code { get; set; } = string.Empty;
}

