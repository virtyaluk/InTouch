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
    /// A <see cref="FacultyChair"/> class describes a university's faculty chair.
    /// </summary>
    [DebuggerDisplay("FacultyChair {Title}")]
    [DataContract]
    public class FacultyChair : TitledItem
    {
        
    }
}