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
    /// Community access types.
    /// </summary>
    [DebuggerDisplay("CommunityAccessTypes")]
    public enum CommunityAccessTypes
    {
        [EnumMember(Value = "0")]
        ManagersOnly = 0,
        [EnumMember(Value = "1")]
        MembersOnly = 1,
        [EnumMember(Value = "2")]
        Everyone = 2
    }
}