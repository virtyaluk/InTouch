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
    /// Notifications types.
    /// </summary>
    [DebuggerDisplay("NotificationsTypes")]
    public enum NotificationsTypes
    {
        /// <summary>
        /// Wall posts.
        /// </summary>
        [EnumMember(Value = "wall")]
        Wall,

        /// <summary>
        /// Mentions in wall posts, comments, or topics.
        /// </summary>
        [EnumMember(Value = "mentions")]
        Mentions,

        /// <summary>
        /// Comments to wall posts, photos, and videos.
        /// </summary>
        [EnumMember(Value = "comments")]
        Comments,

        /// <summary>
        /// Likes.
        /// </summary>
        [EnumMember(Value = "likes")]
        Likes,

        /// <summary>
        /// Wall posts that are copied from the current user's wall.
        /// </summary>
        [EnumMember(Value = "reposts")]
        Reposts,

        /// <summary>
        /// New followers.
        /// </summary>
        [EnumMember(Value = "followers")]
        Followers,

        /// <summary>
        /// Accepted friend requests.
        /// </summary>
        [EnumMember(Value = "friends")]
        Friends
    }
}