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
    /// An <see cref="NewsfeedGetParams"/> class describes a <see cref="NewsfeedMethods.Get"/> method params.
    /// </summary>
    public class NewsfeedGetParams : BaseNewsfeedGetParams
    {
        /// <summary>
        /// Filters to apply.
        /// </summary>
        [MethodParam(Name = "filters")]
        public List<NewsfeedFilters> Filters { get; set; }

        /// <summary>
        /// True - to return news items from banned sources.
        /// </summary>
        [MethodParam(Name = "return_banned")]
        public bool ReturnBanned { get; set; }

        /// <summary>
        /// Sources to obtain news from, separated by commas. 
        /// 
        /// User IDs can be specified in formats $uid or u$uid where $uid is the user's friend ID. 
        /// 
        /// Community IDs can be specified in formats -$gid or g$gid where $gid is the community ID.
        /// 
        /// If the parameter is not set, all of the user's friends and communities are returned, except for banned sources,
        /// which can be obtained with the <see cref="NewsfeedMethods.GetBanned"/> method. 
        /// </summary>
        [MethodParam(Name = "source_ids")]
        public List<string> SourceIds { get; set; }

        /// <summary>
        /// Maximum number of photos to return. By default, 5.
        /// </summary>
        [MethodParam(Name = "max_photos")]
        public int MaxPhotosCount { get; set; } = 5;
    }
}