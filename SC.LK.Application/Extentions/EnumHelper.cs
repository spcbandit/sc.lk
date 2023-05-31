using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace SC.LK.Application.Extentions;

public static class EnumHelper
{
    /// <summary>
    /// GetEnumMemberAttributeValue
    /// </summary>
    /// <param name="enumValue"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    [CanBeNull]
    public static string GetEnumMemberAttributeValue<T>(this T enumValue) where T : struct
    {
        var type = typeof(T);
        if (!type.IsEnum)
            throw new ArgumentException("Has to be of enum type!", nameof(enumValue));

        return GetFieldCustomAttribute<T, EnumMemberAttribute>(enumValue.ToString())?.Value;
    }

    /// <summary>
    /// GetFieldCustomAttribute
    /// </summary>
    /// <param name="name"></param>
    /// <typeparam name="TObject"></typeparam>
    /// <typeparam name="TAttribute"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    [CanBeNull]
    public static TAttribute GetFieldCustomAttribute<TObject, TAttribute>([NotNull] string name)
        where TAttribute : class =>
        (typeof(TObject).GetField(name)
         ?? throw new ArgumentException($"There is no such field as {name} in {typeof(TObject).FullName}!",
             nameof(name)))
        .GetCustomAttributes(false)
        .OfType<TAttribute>()
        .FirstOrDefault();

    ///<summary>
    /// Расширение для всех enum проекта. Перевод из строки в enumType. Если не существует вернет DefaultEnumType
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="str"></param>
    /// <returns></returns>
    public static T ToEnum<T>(this string str)
    {
        var enumType = typeof(T);
        foreach (var name in Enum.GetNames(enumType))
        {
            var enumMemberAttribute = ((EnumMemberAttribute[]) enumType
                    .GetField(name)
                    .GetCustomAttributes(typeof(EnumMemberAttribute), true))
                .Single();
            if (enumMemberAttribute.Value == str)
            {
                return (T) Enum.Parse(enumType, name);
            }
        }

        return default(T);
    }

    ///<summary>
    /// Расширение для всех enum проекта. Перевод из строки в enumType. Если не существует вернет DefaultEnumType
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IReadOnlyList<T> ToListEnum<T>(this IReadOnlyList<string> strList)
    {
        List<T> result = new List<T>();
        bool assept = false;
        foreach (var str in strList)
        {
            var enumType = typeof(T);
            foreach (var name in Enum.GetNames(enumType))
            {
                var enumMemberAttribute = ((EnumMemberAttribute[]) enumType
                        .GetField(name)
                        .GetCustomAttributes(typeof(EnumMemberAttribute), true))
                    .Single();
                if (enumMemberAttribute.Value == str)
                {
                    result.Add((T) Enum.Parse(enumType, name));
                    assept = true;
                }
            }

            if (!assept)
                result.Add(default(T));
            assept = false;
        }

        return result;
    }
}
