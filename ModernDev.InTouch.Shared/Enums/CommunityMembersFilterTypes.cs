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
    /// Types of community members.
    /// </summary>
    [DebuggerDisplay("CommunityMembersFilterTypes")]
    public enum CommunityMembersFilterTypes
    {
        /// <summary>
        /// Friends.
        /// </summary>
        [EnumMember(Value = "friends")]
        Friends,

        /// <summary>
        /// Those who pressed 'I may attend'.
        /// </summary>
        [EnumMember(Value = "unsure")]
        Unsure,

        /// <summary>
        /// Community managers.
        /// </summary>
        [EnumMember(Value = "managers")]
        Managers
    }
}