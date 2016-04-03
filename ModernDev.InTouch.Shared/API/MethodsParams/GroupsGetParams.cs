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
    /// A <see cref="GroupsGetParams"/> class describes a <see cref="GroupsMethods.Get"/> method params.
    /// </summary>
    public class GroupsGetParams : MethodParamsGroup
    {
        /// <summary>
        /// User ID.
        /// </summary>
        [MethodParam(Name = "user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// True - to return complete information about a user's communities.
        /// </summary>
        [MethodParam(Name = "extended")]
        public bool Extended { get; } = true;

        /// <summary>
        /// Number of communities to return. 
        /// </summary>
        [MethodParam(Name = "count", Extra = new[] {0, 1000})]
        public int Count { get; set; } = 100;

        /// <summary>
        /// Offset needed to return a specific subset of communities.
        /// </summary>
        [MethodParam(Name = "offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Profile fields to return. 
        /// </summary>
        [MethodParam(Name = "fields")]
        public List<GroupProfileFields> Fields { get; set; }

        /// <summary>
        /// Types of communities to return.
        /// </summary>
        [MethodParam(Name = "filter")]
        public List<CommunitiesFilterTypes> Filter { get; set; }
    }
}