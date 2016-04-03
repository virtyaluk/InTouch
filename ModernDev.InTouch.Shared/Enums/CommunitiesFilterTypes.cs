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
    /// Types of communities to filter on.
    /// </summary>
    [DebuggerDisplay("CommunitiesFielterTypes")]
    public enum CommunitiesFilterTypes
    {
        [EnumMember(Value = "admin")]
        Admin,

        [EnumMember(Value = "editor")]
        Editor,

        [EnumMember(Value = "moder")]
        Moderator,

        [EnumMember(Value = "groups")]
        Groups,

        [EnumMember(Value = "publics")]
        Publics,

        [EnumMember(Value = "events")]
        Events
    }
}