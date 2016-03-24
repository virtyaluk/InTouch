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
    /// Video catalog item types.
    /// </summary>
    [DebuggerDisplay("VideoCatalogItemTypes")]
    public enum VideoCatalogItemTypes
    {
        /// <summary>
        /// Video
        /// </summary>
        [EnumMember(Value = "video")]
        Video,

        /// <summary>
        /// Video album.
        /// </summary>
        [EnumMember(Value = "album")]
        Album
    }
}