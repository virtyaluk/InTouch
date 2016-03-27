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
using System.Linq;
using static ModernDev.InTouch.Helpers.Utils;

namespace ModernDev.InTouch
{
    public class WallSearchGetParams : MethodParamsGroup
    {
        /// <summary>
        /// User or community id.
        /// 
        /// <remarks>
        /// Remember that for a community owner_id must be negative.
        /// </remarks>
        /// </summary>
        [MethodParam(Name = "owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// User or community screen name.
        /// </summary>
        [MethodParam(Name = "domain")]
        public string Domain { get; set; }

        /// <summary>
        /// True – returns only page owner's posts.
        /// </summary>
        [MethodParam(Name = "owners_only")]
        public bool OwnersOnly { get; set; }

        /// <summary>
        /// Count of posts to return. 
        /// </summary>
        [MethodParam(Name = "count", Extra = new[] {0, 100})]
        public int Count { get; set; } = 20;

        /// <summary>
        /// Results offset.
        /// </summary>
        [MethodParam(Name = "offset")]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// Show extended post info.
        /// </summary>
        [MethodParam(Name = "extended")]
        public bool Extended { get; set; }

        private List<string> _fields;

        /// <summary>
        /// The list of additional fields for the profiles and groups that need to be returned. The list can accept <see cref="UserProfileFields"/>, <see cref="GroupProfileFields"/> and regular string objects.
        /// </summary>
        [MethodParam(Name = "fields")]
        public List<object> Fields
        {
            get { return _fields?.Cast<object>().ToList(); }
            set
            {
                _fields = value?.Where(
                    el => el != null && (el is UserProfileFields || el is GroupProfileFields || el is string))
                    .Select(el => el is string ? (string) el : ToEnumString(el)).ToList();
            }
        }
    }
}