using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp.Common.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns as a list of enums
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToList<T>(this Type enumType)
        {
            if (!enumType.IsEnum)
                throw new InvalidCastException("Must be an enumerated type");
            return System.Enum.GetValues(typeof(T)).Cast<T>();
        }

        /// <summary>
        /// Converts list of string to list of Enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="strList"></param>
        /// <returns></returns>
        public static IEnumerable<TEnum> ToEnumList<TEnum>(this IEnumerable<string> strList) where TEnum : struct
        {
            var result = new List<TEnum>();
            var list = strList.ToList();
            if (list.Any())
            {
                foreach (var str in list)
                {
                    TEnum r;
                    if (System.Enum.TryParse<TEnum>(str, out r))
                        result.Add(r);
                }
            }
            return result;
        }

        public static T GetAttribute<T>(this System.Enum value) where T : Attribute
        {
            var type = value.GetType();
            var name = System.Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<T>()
                .SingleOrDefault();
        }
    }
}
