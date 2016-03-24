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
    /// Video search filter types.
    /// </summary>
    [DebuggerDisplay("VideoSearchFilters")]
    public enum VideoSearchFilters
    {
        /// <summary>
        /// Return mp4 videos only.
        /// </summary>
        [EnumMember(Value = "mp4")]
        Mp4,

        /// <summary>
        /// Return YouTube videos only.
        /// </summary>
        [EnumMember(Value = "youtube")]
        Youtube,

        /// <summary>
        /// Return Vimeo videos only.
        /// </summary>
        [EnumMember(Value = "vimeo")]
        Vimeo,

        /// <summary>
        /// Return short videos only.
        /// </summary>
        [EnumMember(Value = "short")]
        Short,

        /// <summary>
        /// Return long videos only.
        /// </summary>
        [EnumMember(Value = "long")]
        Long
    }
}