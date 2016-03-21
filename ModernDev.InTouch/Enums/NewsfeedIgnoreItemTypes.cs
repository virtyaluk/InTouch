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
    /// Item types that can be ignored on newsfeed.
    /// </summary>
    [DebuggerDisplay("NewsfeedIgnoreItemTypes")]
    public enum NewsfeedIgnoreItemTypes
    {
        /// <summary>
        /// Post on the wall.
        /// </summary>
        [EnumMember(Value = "wall")]
        Wall,

        /// <summary>
        /// Tag on photo.
        /// </summary>
        [EnumMember(Value = "tag")]
        Tag,

        /// <summary>
        /// Profile photo.
        /// </summary>
        [EnumMember(Value = "profilephoto")]
        ProfilePhoto,

        /// <summary>
        /// Video.
        /// </summary>
        [EnumMember(Value = "video")]
        Video,

        /// <summary>
        /// Photo.
        /// </summary>
        [EnumMember(Value = "photo")]
        Photo,

        /// <summary>
        /// Audio.
        /// </summary>
        [EnumMember(Value = "audio")]
        Audio
    }
}