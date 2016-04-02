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
    /// Ban reason types.
    /// </summary>
    [DebuggerDisplay("BanTypes")]
    public enum BanTypes
    {
        Other = 0,
        Spam = 1,
        VerbalAbuse = 2,
        StrongLanguage = 3,
        IrrelevantMessages = 4
    }
}