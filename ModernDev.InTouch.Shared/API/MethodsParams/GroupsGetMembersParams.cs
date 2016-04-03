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
    /// A <see cref="GroupsGetMembersParams"/> class describes a <see cref="GroupsMethods.GetMembers"/> method params.
    /// </summary>
    public class GroupsGetMembersParams : MethodParamsGroup
    {
        /// <summary>
        /// ID or screen name of the community. 
        /// </summary>
        [MethodParam(Name = "group_id")]
        public string GroupId { get; set; }

        /// <summary>
        /// Sort order.
        /// </summary>
        [MethodParam(Name = "sort")]
        public CommunityMembersSortOrder Sort { get; set; } = CommunityMembersSortOrder.IdAscending;

        /// <summary>
        /// Offset needed to return a specific subset of community members. 
        /// </summary>
        [MethodParam(Name = "offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Number of community members to return.
        /// </summary>
        [MethodParam(Name = "count", Extra = new[] {0, 1000})]
        public int Count { get; set; } = 1000;

        /// <summary>
        /// List of additional fields to be returned.
        /// </summary>
        [MethodParam(Name = "fields")]
        public List<UserProfileFields> Fields { get; set; }

        /// <summary>
        /// Type of members to return.
        /// </summary>
        [MethodParam(Name = "filter")]
        public CommunityMembersFilterTypes? Filter { get; set; }
    }
}