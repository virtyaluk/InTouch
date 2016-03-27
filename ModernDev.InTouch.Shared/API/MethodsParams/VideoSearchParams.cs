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

using System.Collections.Generic;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="VideoSearchParams"/> class describes a <see cref="VideoMethods.Search"/> method params.
    /// </summary>
    public class VideoSearchParams : MethodParamsGroup
    {
        /// <summary>
        /// Search query string (e.g., The Beatles).
        /// </summary>
        [MethodParam(Name = "q", IsRequired = true)]
        public string Query { get; set; }

        /// <summary>
        /// Sort order: 
        /// 1 — by duration;
        /// 2 — by relevance;
        /// 0 — by date added.
        /// </summary>
        [MethodParam(Name = "sort")]
        public int Sort { get; set; }

        /// <summary>
        /// If not null, only searches for high-definition videos.
        /// </summary>
        [MethodParam(Name = "hd")]
        public bool NeedHD { get; set; }

        /// <summary>
        /// True - to disable the Safe Search filter; False — to enable the Safe Search filter.
        /// </summary>
        [MethodParam(Name = "adult")]
        public bool UnsafeSearch { get; set; }

        /// <summary>
        /// Filters to apply.
        /// </summary>
        [MethodParam(Name = "filters")]
        public List<VideoSearchFilters> Filters { get; set; }

        /// <summary>
        /// True - search only own videos.
        /// </summary>
        [MethodParam(Name = "search_own")]
        public bool OnlyOwn { get; set; }

        /// <summary>
        /// The minimum duration in seconds of searched videos.
        /// </summary>
        [MethodParam(Name = "longer")]
        public int LongerThan { get; set; }

        /// <summary>
        /// The maximum duration is seconds of searched videos.
        /// </summary>
        [MethodParam(Name = "shorter")]
        public int ShorterThan { get; set; }

        /// <summary>
        /// The number of videos to return.
        /// </summary>
        [MethodParam(Name = "count", Extra = new[] {0, 1000})]
        public int Count { get; set; } = 20;
        
        /// <summary>
        /// Offset needed to return a specific subset of videos. 
        /// </summary>
        [MethodParam(Name = "offset")]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// Return additional profiles objects.
        /// </summary>
        [MethodParam(Name = "extended")]
        public bool Extended { get; set; }
    }
}