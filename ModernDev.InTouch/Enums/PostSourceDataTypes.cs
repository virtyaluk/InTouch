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
    /// Action types due to which the record was created.
    /// </summary>
    public enum PostSourceDataTypes
    {
        // if type = vk

        /// <summary>
        /// Change of user's status.
        /// </summary>
        [EnumMember(Value = "profile_activity")]
        ProfileActivity,

        /// <summary>
        /// Change of user's photo.
        /// </summary>
        [EnumMember(Value = "profile_photo")]
        ProfilePhoto,

        // if type = widget

        /// <summary>
        /// Comments widget.
        /// </summary>
        [EnumMember(Value = "comments")]
        Comments,

        /// <summary>
        /// Likes widget.
        /// </summary>
        [EnumMember(Value = "like")]
        Like,

        /// <summary>
        /// Poll widget.
        /// </summary>
        [EnumMember(Value = "poll")]
        Poll
    }
}