namespace TaskTracker.Common.Enums;

/// <summary>
/// Перечисление статусов для Task.
/// </summary>
public static class TaskStatus
{
    /// <summary>
    /// Открыта.
    /// </summary>
    public static string Opened => "Opened";

    /// <summary>
    /// В процессе.
    /// </summary>
    public static string InProgress => "InProgress";

    /// <summary>
    /// В ревью.
    /// </summary>
    public static string InReview => "InReview";

    /// <summary>
    /// Решена.
    /// </summary>
    public static string Done => "Done";

    /// <summary>
    /// Закрыта.
    /// </summary>
    public static string Closed => "Closed";
}
