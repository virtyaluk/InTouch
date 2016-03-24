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
    /// Notation types for photo copy size and ratio.
    /// </summary>
    [DebuggerDisplay("PhotoSizeTypes")]
    public enum PhotoSizeTypes
    {
        /// <summary>
        /// Proportional copy with 75px max width.
        /// </summary>
        [EnumMember(Value = "s")]
        S,

        /// <summary>
        /// Proportional copy with 130px max width.
        /// </summary>
        [EnumMember(Value = "m")]
        M,

        /// <summary>
        /// Proportional copy with 604px max width.
        /// </summary>
        [EnumMember(Value = "x")]
        X,

        /// <summary>
        /// If original image's "width/height" ratio is less or equal to 3:2, then proportional copy with 130px max width.
        /// If original image's "width/height" ratio is more than 3:2, then copy of cropped by left side image
        /// with 130px max width and 3:2 sides ratio.
        /// </summary>
        [EnumMember(Value = "o")]
        O,

        /// <summary>
        /// If original image's "width/height" ratio is less or equal to 3:2, then proportional copy with 200px max width.
        /// If original image's "width/height" ratio is more than 3:2, then copy of cropped by left side image
        /// with 200px max width and 3:2 sides ratio.
        /// </summary>
        [EnumMember(Value = "p")]
        P,

        /// <summary>
        /// If original image's "width/height" ratio is less or equal to 3:2, then proportional copy with 320px max width.
        /// If original image's "width/height" ratio is more than 3:2, then copy of cropped by left side image
        /// with 320px max width and 3:2 sides ratio.
        /// </summary>
        [EnumMember(Value = "q")]
        Q,

        /// <summary>
        /// Proportional copy with 807px max width.
        /// </summary>
        [EnumMember(Value = "y")]
        Y,

        /// <summary>
        /// Proportional copy with 1280x1024px max size.
        /// </summary>
        [EnumMember(Value = "z")]
        Z,

        /// <summary>
        /// Proportional copy with 2560x2048px max size.
        /// </summary>
        [EnumMember(Value = "w")]
        W
    }
}