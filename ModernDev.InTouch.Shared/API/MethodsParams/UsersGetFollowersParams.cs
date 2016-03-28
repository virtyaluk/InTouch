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
using System.Diagnostics;

namespace ModernDev.InTouch
{
    /// <summary>
    /// An <see cref="UsersGetFollowersParams"/> class describes a <see cref="UsersMethods.GetFollowers(ModernDev.InTouch.UsersGetFollowersParams)"/> method params.
    /// </summary>
    [DebuggerDisplay("UsersGetFollowersParams")]
    public class UsersGetFollowersParams : MethodParamsGroup
    {
        /// <summary>
        /// User ID. 
        /// </summary>
        [MethodParam(Name = "user_id", Extra = new[] {0, 1000000000})]
        public int? UserId { get; set; }

        /// <summary>
        /// Offset needed to return a specific subset of followers.
        /// </summary>
        [MethodParam(Name = "offset")]
        public int? Offset { get; set; }

        /// <summary>
        /// Number of followers to return. 
        /// </summary>
        [MethodParam(Name = "count", Extra = new[] {0, 1000})]
        public int? Count { get; set; } = 100;

        /// <summary>
        /// Profile fields to return.
        /// </summary>
        [MethodParam(Name = "fields")]
        public List<UserProfileFields> Fields { get; set; }

        /// <summary>
        /// Case for declension of user name and surname
        /// </summary>
        [MethodParam(Name = "name_case")]
        public NameCases NameCase { get; set; } = NameCases.Nominative;
    }
}