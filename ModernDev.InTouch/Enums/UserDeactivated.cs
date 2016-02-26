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
    /// User deactivated statuses
    /// </summary>
    [DebuggerDisplay("UserDeactivated")]
    public enum UserDeactivated
    {
        [EnumMember(Value = "deleted")]
        Deleted,
        [EnumMember(Value = "banned")]
        Banned
    }
}