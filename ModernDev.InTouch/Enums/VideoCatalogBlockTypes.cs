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
    /// Video catalog block types.
    /// </summary>
    [DebuggerDisplay("VideoCatalogBlockTypes")]
    public enum VideoCatalogBlockTypes
    {
        /// <summary>
        /// Video collections.
        /// </summary>
        [EnumMember(Value = "category")]
        Category,

        /// <summary>
        /// Community's videos.
        /// </summary>
        [EnumMember(Value = "channel")]
        Channel
    }
}