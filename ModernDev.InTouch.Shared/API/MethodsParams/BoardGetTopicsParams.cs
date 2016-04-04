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
    /// A <see cref="BoardGetTopicsParams"/> class describes a <see cref="BoardMethods.GetTopics"/> method params.
    /// </summary>
    public class BoardGetTopicsParams : MethodParamsGroup
    {
        /// <summary>
        /// ID of the community that owns the discussion board. 
        /// </summary>
        [MethodParam(Name = "group_id", IsRequired = true)]
        public int GroupId { get; set; }

        /// <summary>
        /// IDs of topics to be returned (100 maximum). By default, all topics are returned.
        /// If this parameter is set, the order, offset, and count parameters are ignored.
        /// </summary>
        [MethodParam(Name = "topic_ids")]
        public List<int> TopicIds { get; set; }

        /// <summary>
        /// Sort order: 
        /// 1 — by date updated in reverse chronological order.
        /// 2 — by date created in reverse chronological order.
        /// -1 — by date updated in chronological order.
        /// -2 — by date created in chronological order. 
        /// 
        /// If no sort order is specified, topics are returned in the order specified by the group administrator.Pinned topics are returned first, regardless of the sorting. 
        /// </summary>
        [MethodParam(Name = "order")]
        public int Order { get; set; } = 1;

        /// <summary>
        /// Offset needed to return a specific subset of topics.
        /// </summary>
        [MethodParam(Name = "offset")]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// Number of topics to return. 
        /// </summary>
        [MethodParam(Name = "count", Extra = new[] {0, 100})]
        public int Count { get; set; } = 40;

        /// <summary>
        /// True — to return information about users who created topics or who posted there last.
        /// False — to return no additional fields(default).
        /// </summary>
        [MethodParam(Name = "extended")]
        public bool Extended { get; set; }

        /// <summary>
        /// 1 — to return the first comment in each topic.
        /// 2 — to return the last comment in each topic.
        /// 0 — to return no comments(default).
        /// </summary>
        [MethodParam(Name = "preview")]
        public int Preview { get; set; } = 0;

        /// <summary>
        /// Number of characters after which to truncate the previewed comment. To preview the full comment, specify 0. 
        /// </summary>
        [MethodParam(Name = "preview_length")]
        public int PreviewLength { get; set; } = 90;
    }
}