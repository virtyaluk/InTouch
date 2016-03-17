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
    /// Services to lookup contacts.
    /// </summary>
    [DebuggerDisplay("Services")]
    public enum Services
    {
        [EnumMember(Value = "email")]
        Email,

        [EnumMember(Value = "phone")]
        Phone,

        [EnumMember(Value = "twitter")]
        Twitter,

        [EnumMember(Value = "facebook")]
        Facebook,

        [EnumMember(Value = "odnoklassniki")]
        Ok,

        [EnumMember(Value = "instagram")]
        Instagram,

        [EnumMember(Value = "google")]
        Google
    }
}