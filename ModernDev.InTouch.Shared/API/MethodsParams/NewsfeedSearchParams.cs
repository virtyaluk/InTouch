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
    /// An <see cref="NewsfeedSearchParams"/> class describes a <see cref="NewsfeedMethods.Search"/> method params.
    /// </summary>
    public class NewsfeedSearchParams : BaseNewsfeedGetParams
    {
        /// <summary>
        /// Search query string (e.g., New Year).
        /// </summary>
        [MethodParam(Name = "q")]
        public string Query { get; set; }

        /// <summary>
        /// True - to return additional information about the user or community that placed the post.
        /// </summary>
        [MethodParam(Name = "extended")]
        public bool Extended { get; set; }

        /// <summary>
        /// Geographical latitude point (in degrees, -90 to 90) within which to search. 
        /// </summary>
        [MethodParam(Name = "latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Geographical longitude point (in degrees, -180 to 180) within which to search. 
        /// </summary>
        [MethodParam(Name = "longitude")]
        public double Longitude { get; set; }
    }
}