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

using System.Runtime.Serialization;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Likes list filter types.
    /// </summary>
    public enum LikesListFilterTypes
    {
        /// <summary>
        /// Returns information about all users who liked the object.
        /// </summary>
        [EnumMember(Value = "likes")]
        Likes,

        /// <summary>
        /// Returns information only about users who told their friends about the object.
        /// </summary>
        [EnumMember(Value = "copies")]
        Copies
    }
}