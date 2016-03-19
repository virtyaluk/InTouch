/**
 * This file\code is part of InTouch project.
 *
 * InTouch - is a .NET wrapper for the vk.com API.
 * https://github.com/virtyaluk/InTouch
 *
 * Copyright (c) 2016 Bohdan Shtepan
 * http://modern-dev.com/
 *
 * Licensed under the GPLv3 license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;

namespace ModernDev.InTouch.Helpers
{
    public static class Utils
    {
        /// <summary>
        /// Converts <c>Unix time-stamp</c> to <see cref="DateTime"/> object.
        /// </summary>
        /// <param name="unixTimeStamp">Unix time-stamp.</param>
        /// <returns></returns>
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            dt = dt.AddSeconds(unixTimeStamp).ToLocalTime();

            return dt;
        }

        /// <summary>
        /// Converts a <see cref="DateTime"/> object to <c>Unix time-stamp</c>.
        /// </summary>
        /// <returns></returns>
        public static long ToUnixTimeStamp(this DateTime dateTime)
            => new DateTimeOffset(dateTime).ToUnixTimeSeconds();

        /// <summary>
        /// 
        /// <remarks>
        /// Was taken from <a href="http://stackoverflow.com/a/10418943/1191959">here</a>.
        /// </remarks>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ToEnumString<T>(T type)
        {
            //var enumType = typeof (T);
            var enumType = type.GetType();
            var name = Enum.GetName(enumType, type);
            var enumMemberAttribute = ((EnumMemberAttribute[]) enumType.GetField(name)
                .GetCustomAttributes(typeof (EnumMemberAttribute), true)).Single();

            return enumMemberAttribute.Value;
        }

        /// <summary>
        /// Transforms <see cref="Dictionary{String, Object}"/> to a query string.
        /// <remarks>
        /// Was taken from <a href="http://stackoverflow.com/a/33429118/1191959">here</a>.
        /// </remarks>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string GetQueryString(this Dictionary<string, object> @this)
            => string.Join("&", @this.Select(kvp => $"{kvp.Key}={WebUtility.UrlEncode(kvp.Value.ToString())}"));

        /// <summary>
        /// Parses query string to a <see cref="Dictionary{String, String}"/>.
        /// <remarks>
        /// Was taken from <a href="http://stackoverflow.com/a/26309802/1191959">here</a>.
        /// </remarks>
        /// </summary>
        /// <param name="queryString">Query string.</param>
        /// <returns></returns>
        public static Dictionary<string, string> ParseQueryString(string queryString)
            => queryString.Split('&').Where(query => !string.IsNullOrEmpty(query))
                .ToDictionary(query => query.Split('=')[0], query => query.Split('=')[1]);

        /// <summary>
        /// Determines whether the given object is a generic list.
        /// <remarks>
        /// Was taken from <a href="http://stackoverflow.com/a/794257/1191959">here</a>.
        /// </remarks>
        /// </summary>
        /// <param name="o">An object to check.</param>
        /// <returns>True, if the given object is a generic list; False, otherwise.</returns>
        public static bool IsGenericList(this object o)
        {
            var isGenericList = false;

            var oType = o.GetType();

            if (oType.GetTypeInfo().IsGenericType && (oType.GetGenericTypeDefinition() == typeof(List<>)))
                isGenericList = true;

            return isGenericList;
        }
        
        /// <summary>
        /// Generates random string.
        /// <remarks>
        /// Was taken from <a href="http://stackoverflow.com/a/1344242/1191959">here</a>.
        /// </remarks>
        /// </summary>
        /// <param name="length">The length of a new random string.</param>
        /// <returns></returns>
        public static string RandomString(int length)
            => new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());

        /// <summary>
        /// Checks whether the item is in the set.
        /// <remarks>
        /// Was taken from <a href="http://stackoverflow.com/a/8228973/1191959">here</a>.
        /// </remarks>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">An item to check.</param>
        /// <param name="list">A set of items.</param>
        /// <returns></returns>
        public static bool IsInSet<T>(this T @this, params T[] list) => list.Contains(@this);
    }
}
