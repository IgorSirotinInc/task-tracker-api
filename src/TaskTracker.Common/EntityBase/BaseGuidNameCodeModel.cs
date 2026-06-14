namespace TaskTracker.Common.EntityBase;

/// <summary>
/// Базовая модель с кодом и наименованием.
/// </summary>
public abstract class BaseGuidNameCodeModel<TIdentifier> :
    BaseGuidNameModel<TIdentifier> where TIdentifier : struct
{
    /// <summary>
    /// Код.
    /// </summary>
    public string Code { get; set; } = string.Empty;
}

