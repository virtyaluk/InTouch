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
    /// Types of hint sections.
    /// </summary>
    [DebuggerDisplay("HintsSectionTypes")]
    public enum HintsSectionTypes
    {
        [EnumMember(Value = "groups")]
        Groups,

        [EnumMember(Value = "events")]
        Events,

        [EnumMember(Value = "publics")]
        Publics,

        [EnumMember(Value = "correspondents")]
        Correspondents,

        [EnumMember(Value = "people")]
        People,

        [EnumMember(Value = "friends")]
        Friends,

        [EnumMember(Value = "mutual_friends")]
        MutualFriends
    }
}