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

using System;
using System.Collections.Generic;

namespace ModernDev.InTouch
{
    public class BaseNewsfeedGetParams : MethodParamsGroup
    {
        /// <summary>
        /// Earliest timestamp of a news item to return. By default, 24 hours ago. 
        /// </summary>
        [MethodParam(Name = "start_time")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Latest timestamp of a news item to return. By default, the current time. 
        /// </summary>
        [MethodParam(Name = "end_time")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Identifier required to get the next page of results. 
        /// Value for this parameter is returned in <c>next_from</c> field in a reply.
        /// </summary>
        [MethodParam(Name = "start_from")]
        public string StartFrom { get; set; }

        /// <summary>
        /// Number of news items to return. For auto feed, you can use the <c>new_offset</c> parameter returned by this method. 
        /// </summary>
        [MethodParam(Name = "count")]
        public int Count { get; set; } = 50;

        /// <summary>
        /// Additional user\community profile fields to return. Accepted values is <see cref="UserProfileFields"/>, <see cref="GroupProfileFields"/> or plain string.
        /// </summary>
        [MethodParam(Name = "fields")]
        public List<object> Fields { get; set; }
    }
}