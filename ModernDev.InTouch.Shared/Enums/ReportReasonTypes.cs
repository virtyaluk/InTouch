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
    /// Reason for the complaint types.
    /// </summary>
    [DebuggerDisplay("ReportReasonTypes")]
    public enum ReportReasonTypes
    {
        Spam = 0,
        ChildPornography = 1,
        Extremism = 2,
        Violence = 3,
        DrugPropaganda = 4,
        AdultMaterial = 5,
        AbuseOrInsult = 6
    }
}