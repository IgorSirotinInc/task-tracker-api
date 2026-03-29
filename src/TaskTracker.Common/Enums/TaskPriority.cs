using TaskTracker.Common.EntityBase;

namespace TaskTracker.Common.Enums;

/// <summary>
/// Перечеисление приоритетов для Task.
/// </summary>
public class TaskPriority : BaseModel
{
    /// <summary>
    /// Низкий.
    /// </summary>
    public static string Low => "Low";

    /// <summary>
    /// Средний.
    /// </summary>
    public static string Medium => "Medium";

    /// <summary>
    /// Высокий.
    /// </summary>
    public static string High => "High";

    /// <summary>
    /// Блокер.
    /// </summary>
    public static string Blocker => "Blocker";
}
