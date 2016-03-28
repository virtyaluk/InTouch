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
    /// An <see cref="NewsfeedGetCommentsParams"/> class describes a <see cref="NewsfeedMethods.GetComments"/> method params.
    /// </summary>
    public class NewsfeedGetCommentsParams : BaseNewsfeedGetParams
    {
        /// <summary>
        /// Filters to apply.
        /// </summary>
        [MethodParam(Name = "filters")]
        public List<NewsfeedCommentsFilters> Filters { get; set; }

        /// <summary>
        /// Object ID, comments on repost of which shall be returned, e.g. wall1_45486.
        /// (If the parameter is set, the filters parameter is optional.)
        /// </summary>
        [MethodParam(Name = "reposts")]
        public string Resposts { get; set; }

        /// <summary>
        /// Number of comments to each entry to return.
        /// </summary>
        [MethodParam(Name = "last_comments_count")]
        public int LastCommentsCount { get; set; }
    }
}