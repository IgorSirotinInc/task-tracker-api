using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using TaskTracker.Common.EntityBase;

namespace TaskTracker.Storage.Extensions;

/// <summary>
/// Методы расширения для <see cref="EntityTypeBuilder"/>
/// </summary>
public static partial class EntityTypeBuilderExtension
{
    /// <summary>
    /// Конфигурирует базовые колонки сущности:
    /// <list type="bullet">
    /// <item><description>Id → {entity}_id</description></item>
    /// <item><description>Guid → {entity}_guid</description></item>
    /// </list>
    /// Имя сущности берётся из типа <typeparamref name="TEntity"/> с удалением
    /// стандартных суффиксов (<c>Entity</c>, <c>Model</c>) и преобразуется в snake_case.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности, наследуемый от <see cref="BaseModel"/>.</typeparam>
    /// <param name="builder">Построитель конфигурации сущности.</param>
    /// <returns>Текущий экземпляр <see cref="EntityTypeBuilder{TEntity}"/> для цепочки вызовов.</returns>
    public static EntityTypeBuilder<TEntity> ConfigureBaseColumns<TEntity>(
        this EntityTypeBuilder<TEntity> builder)
        where TEntity : BaseModel
    {
        var prefix = GetEntityPrefix<TEntity>();

        builder.HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .HasColumnName($"{prefix}_id")
            .HasColumnOrder(0);

        builder.Property(x => x.Guid)
            .HasColumnName($"{prefix}_guid")
            .HasColumnOrder(1);

        return builder;
    }

    /// <summary>
    /// Конфигурирует свойство сущности и задаёт имя колонки.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности, для которой выполняется конфигурация.</typeparam>
    /// <typeparam name="TProperty">Тип настраиваемого свойства.</typeparam>
    /// <param name="builder">Построитель конфигурации сущности.</param>
    /// <param name="expression">Лямбда-выражение, указывающее на свойство сущности.</param>
    /// <returns>Экземпляр <see cref="PropertyBuilder{TProperty}"/> для дальнейшей конфигурации.</returns>
    /// <remarks>Метод извлекает имя свойства из выражения и преобразует его в snake_case, например:
    /// <list type="bullet">
    /// <item><description><c>Title</c> → <c>title</c></description></item>
    /// <item><description><c>CreatedAt</c> → <c>created_at</c></description></item>
    /// </list>
    /// </remarks>
    public static PropertyBuilder<TProperty> HasProperty<TEntity, TProperty>(
        this EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, TProperty>> expression,
        string propertyName)
        where TEntity : class
    {
        return builder.Property(expression)
            .HasColumnName(propertyName);
    }

    /// <summary>
    /// Получает префикс сущности для формирования имён колонок.
    /// Удаляет суффикс <c>Entity</c>, затем преобразует имя в snake_case.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <returns>Префикс в формате snake_case (например, <c>task</c>).</returns>
    private static string GetEntityPrefix<TEntity>()
    {
        var name = typeof(TEntity).Name;

        if (name.EndsWith("Entity"))
            name = name[..^"Entity".Length];

        return ToSnakeCase(name);
    }

    /// <summary>
    /// Преобразует строку из PascalCase или camelCase в snake_case.
    /// </summary>
    /// <param name="value">Исходная строка.</param>
    /// <returns>Строка в формате snake_case.</returns>
    private static string ToSnakeCase(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return value;

        var result = AcronymToWordBoundaryRegex().Replace(value, "$1_$2");
        result = LowerToUpperBoundaryRegex().Replace(result, "$1_$2");

        return result.ToLowerInvariant();
    }


    /// <summary>
    /// Регулярное выражение для поиска границы между аббревиатурой (несколько заглавных букв)
    /// и обычным словом.
    /// Пример:
    /// HTTPServer → HTTP_Server
    /// </summary>
    [GeneratedRegex(@"([A-Z]+)([A-Z][a-z])")]
    private static partial Regex AcronymToWordBoundaryRegex();


    /// <summary>
    /// Регулярное выражение для поиска границы между строчной буквой (или цифрой)
    /// и следующей заглавной буквой.
    /// Пример:
    /// CreatedAt → Created_At
    /// </summary>
    [GeneratedRegex(@"([a-z0-9])([A-Z])")]
    private static partial Regex LowerToUpperBoundaryRegex();
}