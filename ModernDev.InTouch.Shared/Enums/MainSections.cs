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
    /// Main sections.
    /// </summary>
    [DebuggerDisplay("MainSections")]
    public enum MainSections
    {
        [EnumMember(Value = "0")]
        NotPresented = 0,
        [EnumMember(Value = "1")]
        Photos = 1,
        [EnumMember(Value = "2")]
        Topics = 2,
        [EnumMember(Value = "3")]
        Audios = 3,
        [EnumMember(Value = "4")]
        Videos = 4,
        [EnumMember(Value = "5")]
        Market = 5
    }
}