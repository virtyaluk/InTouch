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

namespace ModernDev.InTouch.Helpers
{
    public static class Utils
    {
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            dt = dt.AddSeconds(unixTimeStamp).ToLocalTime();

            return dt;
        }

        public static long DateTimeToUnixTimeStamp(DateTime dateTime)
        {
            return new DateTimeOffset(dateTime).ToUnixTimeSeconds();
        }
    }
}
