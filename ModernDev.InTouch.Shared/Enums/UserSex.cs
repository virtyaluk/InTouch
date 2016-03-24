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

namespace ModernDev.InTouch
{
    /// <summary>
    /// User sex
    /// </summary>
    [DebuggerDisplay("UserSex")]
    public enum UserSex
    {
        Female = 1,
        Male = 2,
        NotSpecified = 0
    }
}