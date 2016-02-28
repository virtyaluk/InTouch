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
    /// Relationship types.
    /// </summary>
    [DebuggerDisplay("RelativeType")]
    public enum RelativeTypes
    {
        [EnumMember(Value = "sibling")]
        Sibling,
        [EnumMember(Value = "parent")]
        Parent,
        [EnumMember(Value = "child")]
        Child,
        [EnumMember(Value = "grandparent")]
        Grandparent,
        [EnumMember(Value = "grandchild")]
        Grandchild
    }
}