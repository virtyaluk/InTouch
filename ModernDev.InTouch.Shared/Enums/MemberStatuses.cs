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
    /// Community membership statuses.
    /// </summary>
    [DebuggerDisplay("MemberStatuses")]
    public enum MemberStatuses
    {
        [EnumMember(Value = "0")]
        NotAMember = 0,
        [EnumMember(Value = "1")]
        IsAMember = 1,
        [EnumMember(Value = "2")]
        NotSure = 2,
        [EnumMember(Value = "3")]
        DeclinedTheInvitation = 3,
        [EnumMember(Value = "4")]
        AppliedToJoin = 4,
        [EnumMember(Value = "5")]
        Invited = 5,
    }
}