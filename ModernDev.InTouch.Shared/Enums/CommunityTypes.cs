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
    /// Community types.
    /// </summary>
    [DebuggerDisplay("GroupTypes")]
    public enum CommunityTypes
    {
        [EnumMember(Value = "group")]
        Group,
        [EnumMember(Value = "public")]
        Public,
        [EnumMember(Value = "event")]
        Event
    }
}