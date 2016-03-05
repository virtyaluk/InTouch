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
        /// <param name="dateTime">The <see cref="DateTime"/> object.</param>
        /// <returns></returns>
        public static long DateTimeToUnixTimeStamp(DateTime dateTime)
        {
            return new DateTimeOffset(dateTime).ToUnixTimeSeconds();
        }

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
            var enumType = typeof (T);
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
        {
            return string.Join("&", @this.Select(kvp => $"{kvp.Key}={WebUtility.UrlEncode(kvp.Value.ToString())}"));
        }

        /// <summary>
        /// Parses query string to a <see cref="Dictionary{String, String}"/>.
        /// <remarks>
        /// Was taken from <a href="http://stackoverflow.com/a/26309802/1191959">here</a>.
        /// </remarks>
        /// </summary>
        /// <param name="queryString">Query string.</param>
        /// <returns></returns>
        public static Dictionary<string, string> ParseQueryString(string queryString)
        {
            return queryString.Split('&')
                .Where(query => !string.IsNullOrEmpty(query))
                .ToDictionary(query => query.Split('=')[0], query => query.Split('=')[1]);
        }
    }
}
