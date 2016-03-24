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
    /// News feed post types.
    /// </summary>
    [DebuggerDisplay("FeedTypes")]
    public enum FeedTypes
    {
        /// <summary>
        /// New wall posts.
        /// </summary>
        [EnumMember(Value = "post")]
        Post,

        /// <summary>
        /// New photos.
        /// </summary>
        [EnumMember(Value = "photo")]
        Photo,

        /// <summary>
        /// New photo tags.
        /// </summary>
        [EnumMember(Value = "wall_tag")]
        PhotoTag,

        /// <summary>
        /// New wall photos.
        /// </summary>
        [EnumMember(Value = "wall_photo")]
        WallPhoto,

        /// <summary>
        /// New friends.
        /// </summary>
        [EnumMember(Value = "friend")]
        Friend,

        /// <summary>
        /// New notes.
        /// </summary>
        [EnumMember(Value = "note")]
        Note,

        /// <summary>
        /// New audio.
        /// </summary>
        [EnumMember(Value = "audio")]
        Audio,

        /// <summary>
        /// New video.
        /// </summary>
        [EnumMember(Value = "video")]
        Video
    }
}