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

namespace ModernDev.InTouch
{
    /// <summary>
    /// Document types.
    /// </summary>
    public enum DocTypes
    {
        /// <summary>
        /// Undefined.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Text documents.
        /// </summary>
        Text = 1,

        /// <summary>
        /// Archives (e.g. rar, zip).
        /// </summary>
        Archive = 2,

        /// <summary>
        /// gif animations.
        /// </summary>
        Gif = 3,

        /// <summary>
        /// Images.
        /// </summary>
        Image = 4,

        /// <summary>
        /// Audio files.
        /// </summary>
        Audio = 5,

        /// <summary>
        /// Video files.
        /// </summary>
        Video = 6,

        /// <summary>
        /// E-books.
        /// </summary>
        EBook = 7,

        /// <summary>
        /// Unknown type.
        /// </summary>
        Unknown = 8
    }
}