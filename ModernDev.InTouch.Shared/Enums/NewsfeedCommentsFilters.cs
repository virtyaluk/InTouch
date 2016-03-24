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
    /// Newsfeed comments filters.
    /// </summary>
    [DebuggerDisplay("NewsfeedCommentsFilters")]
    public enum NewsfeedCommentsFilters
    {
        /// <summary>
        /// New comments on wall posts.
        /// </summary>
        [EnumMember(Value = "post")]
        Post,

        /// <summary>
        /// New comments of photos.
        /// </summary>
        [EnumMember(Value = "photo")]
        Photo,

        /// <summary>
        /// New comments on videos.
        /// </summary>
        [EnumMember(Value = "video")]
        Video,

        /// <summary>
        /// New comments on notes.
        /// </summary>
        [EnumMember(Value = "note")]
        Note,

        /// <summary>
        /// New comments on topics.
        /// </summary>
        [EnumMember(Value = "topic")]
        Topic,

        /// <summary>
        /// New comments on market items.
        /// </summary>
        [EnumMember(Value = "market")]
        Market
    }
}