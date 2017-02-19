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
    [DebuggerDisplay("AudioGenres")]
    public enum AudioGenres
    {
        [EnumMember(Value = "1")]
        Rock = 1,
        [EnumMember(Value = "2")]
        Pop = 2,
        [EnumMember(Value = "3")]
        RapAndHipHop = 3,
        [EnumMember(Value = "4")]
        EasyListening = 4,
        [EnumMember(Value = "5")]
        DanceAndHouse = 5,
        [EnumMember(Value = "6")]
        Instrumental = 6,
        [EnumMember(Value = "7")]
        Metal = 7,
        [EnumMember(Value = "21")]
        Alternative = 21,
        [EnumMember(Value = "8")]
        Dubstep = 8,
        [EnumMember(Value = "1001")]
        JazzAndBlues = 1001,
        [EnumMember(Value = "10")]
        DrumAndBass = 10,
        [EnumMember(Value = "11")]
        Trance = 11,
        [EnumMember(Value = "12")]
        Chanson = 12,
        [EnumMember(Value = "13")]
        Ethnic = 13,
        [EnumMember(Value = "14")]
        AcousticAndVocal = 14,
        [EnumMember(Value = "15")]
        Reggae = 15,
        [EnumMember(Value = "16")]
        Classical = 16,
        [EnumMember(Value = "17")]
        IndiePop = 17,
        [EnumMember(Value = "19")]
        Speech = 19,
        [EnumMember(Value = "22")]
        ElectropopAndDisco = 22,
        [EnumMember(Value = "18")]
        Other = 18
    }
}
