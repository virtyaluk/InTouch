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
    /// Relationship statuses.
    /// </summary>
    [DebuggerDisplay("RelationTypes")]
    public enum RelationTypes
    {
        [EnumMember(Value = "1")]
        Single = 1,
        [EnumMember(Value = "in a relationship")]
        InARelationship = 2,
        [EnumMember(Value = "engaged")]
        Engaged = 3,
        [EnumMember(Value = "married")]
        Married = 4,
        [EnumMember(Value = "it's complicated")]
        ItsCompicated = 5,
        [EnumMember(Value = "actively searching")]
        ActivelySearching = 6,
        [EnumMember(Value = "in love")]
        InLove = 7

    }
}