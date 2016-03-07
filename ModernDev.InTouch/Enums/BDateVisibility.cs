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
    /// User's bdate visibility.
    /// </summary>
    [DebuggerDisplay("BDateVisibility")]
    public enum BDateVisibility
    {
        /// <summary>
        /// Hide the date of birth.
        /// </summary>
        Hidden = 0,

        /// <summary>
        /// Show the date of birth.
        /// </summary>
        Visible = 1,

        /// <summary>
        /// Show only the month and the day.
        /// </summary>
        OnlyDayMonth = 2
    }
}