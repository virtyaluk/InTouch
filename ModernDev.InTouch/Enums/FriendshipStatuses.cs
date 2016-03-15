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

namespace ModernDev.InTouch
{
    /// <summary>
    /// Friendship statuses.
    /// </summary>
    [DebuggerDisplay("FriendshipStatuses")]
    public enum FriendshipStatuses
    {
        /// <summary>
        /// Not a friend.
        /// </summary>
        NotFriend = 0,

        /// <summary>
        /// Friend request sent.
        /// </summary>
        RequestSent = 1,

        /// <summary>
        /// Incoming friend request.
        /// </summary>
        IncomingRequest = 2,

        /// <summary>
        /// Is a friend.
        /// </summary>
        Friend = 3
    }
}