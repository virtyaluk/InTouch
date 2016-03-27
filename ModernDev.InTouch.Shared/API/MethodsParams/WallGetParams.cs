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
    /// An <see cref="WallGetParams"/> class describes a <see cref="WallMethods.Get"/> method params.
    /// </summary>
    public class WallGetParams : WallSearchGetParams
    {
        /// <summary>
        /// Filter to apply.
        /// </summary>
        [MethodParam(Name = "filter")]
        public PostFilterTypes Filter { get; set; } = PostFilterTypes.All;
    }
}