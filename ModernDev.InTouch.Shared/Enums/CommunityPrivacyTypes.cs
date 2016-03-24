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
    /// Community privacy types.
    /// </summary>
    [DebuggerDisplay("CommunityPrivacyTypes")]
    public enum CommunityPrivacyTypes
    {
        /// <summary>
        /// Anyone can join an open community.
        /// </summary>
        [EnumMember(Value = "open")]
        Open,

        /// <summary>
        /// Users can join a closed community if they receive an invitation or send a request.
        /// </summary>
        [EnumMember(Value = "closed")]
        Closed,

        /// <summary>
        /// Private communities are only seen by those, who have been invited by the management.
        /// </summary>
        [EnumMember(Value = "private")]
        Private
    }
}