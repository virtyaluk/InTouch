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

using System.Diagnostics;
using System.Runtime.Serialization;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Link statuses.
    /// </summary>
    [DebuggerDisplay("LinkStatuses")]
    public enum LinkStatuses
    {
        /// <summary>
        /// Link is not blocked.
        /// </summary>
        [EnumMember(Value = "not_banned")]
        NotBanned,

        /// <summary>
        /// Link is blocked.
        /// </summary>
        [EnumMember(Value = "banned")]
        Banned,

        /// <summary>
        /// Link is being checked; retry after several seconds.
        /// </summary>
        [EnumMember(Value = "processing")]
        Processing
    }
}