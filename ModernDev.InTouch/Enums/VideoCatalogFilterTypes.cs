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
    /// Video catalog filter types.
    /// </summary>
    [DebuggerDisplay("VideoCatalogFilterTypes")]
    public enum VideoCatalogFilterTypes
    {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "my")]
        My,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "feed")]
        Feed,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "ugc")]
        Popular,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "series")]
        Series,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "top")]
        EditorsChoice
    }
}