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
    /// Community members sort order types.
    /// </summary>
    [DebuggerDisplay("CommunityMembersSortOrder")]
    public enum CommunityMembersSortOrder
    {
        /// <summary>
        /// User Id ascending.
        /// </summary>
        [EnumMember(Value = "id_asc")]
        IdAscending,

        /// <summary>
        /// User Id descending.
        /// </summary>
        [EnumMember(Value = "id_desc")]
        IdDescending,

        /// <summary>
        /// Join date ascending.
        /// </summary>
        [EnumMember(Value = "time_asc")]
        TimeAscending,

        /// <summary>
        /// Join date descending.
        /// </summary>
        [EnumMember(Value = "time_desc")]
        TimeDescending
    }
}