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
    /// An <see cref="NewsfeedGetRecommendedParams"/> class describes a <see cref="NewsfeedMethods.GetRecommended"/> method params.
    /// </summary>
    public class NewsfeedGetRecommendedParams : BaseNewsfeedGetParams
    {
        /// <summary>
        /// Maximum number of photos to return. By default, 5.
        /// </summary>
        [MethodParam(Name = "max_photos")]
        public int MaxPhotosCount { get; set; } = 5;
    }
}