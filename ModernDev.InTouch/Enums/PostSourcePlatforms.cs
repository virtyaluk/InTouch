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

using System.Runtime.Serialization;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Platform names.
    /// </summary>
    public enum PostSourcePlatforms
    {
        [EnumMember(Value = "android")]
        Android,

        [EnumMember(Value = "iphone")]
        // ReSharper disable once InconsistentNaming
        IPhone,

        [EnumMember(Value = "wphone")]
        WindowsPhone
    }
}