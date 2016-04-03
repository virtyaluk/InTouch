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
    /// A <see cref="GroupsSearchParams"/> class describes a <see cref="GroupsMethods.Search"/> method params.
    /// </summary>
    public class GroupsSearchParams : MethodParamsGroup
    {
        /// <summary>
        /// Search query string. 
        /// </summary>
        [MethodParam(Name = "q", IsRequired = true)]
        public string Query { get; set; }

        /// <summary>
        /// Community type.
        /// </summary>
        [MethodParam(Name = "type")]
        public CommunityTypes? Type { get; set; }

        /// <summary>
        /// Country ID. 
        /// </summary>
        [MethodParam(Name = "country_id")]
        public int? CountryId { get; set; }

        /// <summary>
        /// City ID.
        /// </summary>
        [MethodParam(Name = "city_id")]
        public int? CityId { get; set; }

        /// <summary>
        /// If True, only upcoming events will be returned. Works with the event type only. 
        /// </summary>
        [MethodParam(Name = "future")]
        public bool Future { get; set; }

        /// <summary>
        /// If True, only communities with enabled market.
        /// </summary>
        [MethodParam(Name = "market")]
        public bool Market { get; set; }

        /// <summary>
        /// Offset needed to return a specific subset of search results. 
        /// </summary>
        [MethodParam(Name = "offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Number of communities to return.
        /// </summary>
        [MethodParam(Name = "count", Extra = new[] {0, 1000})]
        public int Count { get; set; } = 20;

        /// <summary>
        /// Sort order:
        /// 0 – default sorting (similar th the full version of the site); 
        /// 1 – by growth speed; 
        /// 2 – by the "day attendance/members number" ratio; 
        /// 3 – by the "Likes number/members number" ratio; 
        /// 4 – by the "comments number/members number" ratio; 
        /// 5 – by the "boards entries number/members number" ratio.
        /// </summary>
        [MethodParam(Name = "sort")]
        public int Sort { get; set; } = 0;
    }
}