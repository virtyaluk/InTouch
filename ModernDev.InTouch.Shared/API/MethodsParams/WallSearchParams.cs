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
    /// An <see cref="WallSearchParams"/> class describes a <see cref="WallMethods.Search"/> method params.
    /// </summary>
    public class WallSearchParams : WallSearchGetParams
    {
        /// <summary>
        /// Search query string.
        /// </summary>
        [MethodParam(Name = "query")]
        public string Query { get; set; }
    }
}