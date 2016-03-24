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
    /// Post filtering types.
    /// </summary>
    [DebuggerDisplay("PostFilterTypes")]
    public enum PostFilterTypes
    {
        /// <summary>
        /// Suggested posts on a community wall.
        /// </summary>
        [EnumMember(Value = "suggests")]
        Suggests,

        /// <summary>
        /// Timed posts (only available for calls with an <see cref="APISession.AccessToken"/>) 
        /// </summary>
        [EnumMember(Value = "postponed")]
        Postponed,

        /// <summary>
        /// Posts by the wall owner.
        /// </summary>
        [EnumMember(Value = "owner")]
        Owner,

        /// <summary>
        /// Posts by someone else.
        /// </summary>
        [EnumMember(Value = "others")]
        Others,

        /// <summary>
        /// Posts by the wall owner and others. 
        /// </summary>
        [EnumMember(Value = "all")]
        All
    }
}