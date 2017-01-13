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
    /// Counter filter types.
    /// </summary>
    [DebuggerDisplay("CounterFilterTypes")]
    public enum CountersFilterTypes
    {
        [EnumMember(Value = "friends")]
        Friends,

        [EnumMember(Value = "friends_suggestions")]
        FriendsSuggestions,

        [EnumMember(Value = "messages")]
        Messages,

        [EnumMember(Value = "photos")]
        Photos,

        [EnumMember(Value = "videos")]
        Videos,

        [EnumMember(Value = "notes")]
        Notes,

        [EnumMember(Value = "gifts")]
        Gifts,

        [EnumMember(Value = "events")]
        Events,

        [EnumMember(Value = "groups")]
        Groups,

        [EnumMember(Value = "notifications")]
        Notifications,

        [EnumMember(Value = "sdk")]
        SDK,

        [EnumMember(Value = "app_requests")]
        AppRequests
    }
}