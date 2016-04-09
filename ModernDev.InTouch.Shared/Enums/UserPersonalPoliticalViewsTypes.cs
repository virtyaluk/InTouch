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
    /// Political views.
    /// </summary>
    [DebuggerDisplay("UserPersonalPoliticalViewsTypes")]
    public enum UserPersonalPoliticalViewsTypes
    {
        [EnumMember(Value = "Communist")]
        Communist = 1,
        [EnumMember(Value = "Socialist")]
        Socialist = 2,
        [EnumMember(Value = "Moderate")]
        Moderate = 3,
        [EnumMember(Value = "Liberal")]
        Liberal = 4,
        [EnumMember(Value = "Conservative")]
        Conservative = 5,
        [EnumMember(Value = "Monarchist")]
        Monarchist = 6,
        [EnumMember(Value = "Ultraconservative")]
        Ultraconservative = 7,
        [EnumMember(Value = "Apathetic")]
        Apathetic = 8,
        [EnumMember(Value = "Libertian")]
        Libertian = 9
    }
}