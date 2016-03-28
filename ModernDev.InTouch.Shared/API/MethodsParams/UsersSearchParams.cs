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
    /// An <see cref="UsersSearchParams"/> class describes a <see cref="UsersMethods.Search(UsersSearchParams)"/> method params.
    /// </summary>
    [DebuggerDisplay("UsersSearchParams")]
    public class UsersSearchParams : MethodParamsGroup
    {
        /// <summary>
        /// Search query string
        /// </summary>
        [MethodParam(Name = "q")]
        public string Query { get; set; }

        /// <summary>
        /// Sort order: True — by date registered; False — by rating.
        /// </summary>
        [MethodParam(Name = "sort")]
        public bool SortByDate { get; set; }

        /// <summary>
        /// Offset needed to return a specific subset of users.
        /// </summary>
        [MethodParam(Name = "offset")]
        public int? Offset { get; set; }

        /// <summary>
        /// Number of users to return. 
        /// </summary>
        [MethodParam(Name = "count", Extra = new[] {0, 1000})]
        public int Count { get; set; } = 20;

        /// <summary>
        /// Profile fields to return.
        /// </summary>
        [MethodParam(Name = "fields")]
        public List<UserProfileFields> Fields { get; set; }

        /// <summary>
        /// City ID. 
        /// </summary>
        [MethodParam(Name = "city")]
        public int? City { get; set; }

        /// <summary>
        /// Country ID. 
        /// </summary>
        [MethodParam(Name = "country")]
        public int? Country { get; set; }

        /// <summary>
        /// City name in a string.
        /// </summary>
        [MethodParam(Name = "hometown")]
        public string HomeTown { get; set; }

        /// <summary>
        /// ID of the country where the user graduated.
        /// </summary>
        [MethodParam(Name = "university_country")]
        public int? UniversityCountry { get; set; }

        /// <summary>
        /// ID of the institution of higher education. 
        /// </summary>
        [MethodParam(Name = "university")]
        public int? University { get; set; }

        /// <summary>
        /// Year of graduation from an institution of higher education. 
        /// </summary>
        [MethodParam(Name = "university_year")]
        public int? UniversityYear { get; set; }

        /// <summary>
        /// Faculty ID.
        /// </summary>
        [MethodParam(Name = "university_faculty")]
        public int? UniversityFaculty { get; set; }

        /// <summary>
        /// The department ID.
        /// </summary>
        [MethodParam(Name = "university_chair")]
        public int? UniversityChair { get; set; }

        /// <summary>
        /// User's sex.
        /// </summary>
        [MethodParam(Name = "sex", Extra = true)]
        public UserSex? Sex { get; set; } = null;

        /// <summary>
        /// User's relationship status.
        /// </summary>
        [MethodParam(Name = "status", Extra = true)]
        public RelationTypes? Status { get; set; } = null;

        /// <summary>
        /// Minimum age.
        /// </summary>
        [MethodParam(Name = "age_from")]
        public int? AgeFrom { get; set; }

        /// <summary>
        /// Maximum age. 
        /// </summary>
        [MethodParam(Name = "age_to")]
        public int? AgeTo { get; set; }

        /// <summary>
        /// Day of birth.
        /// </summary>
        [MethodParam(Name = "birth_day")]
        public int? BirthDay { get; set; }

        /// <summary>
        /// Month of birth. 
        /// </summary>
        [MethodParam(Name = "birth_month")]
        public int? BirthMonth { get; set; }

        /// <summary>
        /// Year of birth.
        /// </summary>
        [MethodParam(Name = "birth_year")]
        public int? BirthYear { get; set; }

        /// <summary>
        /// True — online only; False — all users.
        /// </summary>
        [MethodParam(Name = "online")]
        public bool IsOnline { get; set; }

        /// <summary>
        /// True — with photo only; False — all users.
        /// </summary>
        [MethodParam(Name = "has_photo")]
        public bool? HasPhoto { get; set; }

        /// <summary>
        /// ID of the country where users finished school.
        /// </summary>
        [MethodParam(Name = "school_country")]
        public int? SchoolCountry { get; set; }

        /// <summary>
        /// ID of the city where users finished school.
        /// </summary>
        [MethodParam(Name = "school_city")]
        public int? SchoolCity { get; set; }

        [MethodParam(Name = "school_class")]
        public int? SchoolClass { get; set; }

        /// <summary>
        /// ID of the school.
        /// </summary>
        [MethodParam(Name = "school")]
        public int? School { get; set; }

        /// <summary>
        /// School graduation year.
        /// </summary>
        [MethodParam(Name = "school_year")]
        public int? SchoolYear { get; set; }

        /// <summary>
        /// Users' religious affiliation.
        /// </summary>
        [MethodParam(Name = "religion")]
        public string Religion { get; set; }

        /// <summary>
        /// Users' interests.
        /// </summary>
        [MethodParam(Name = "interests")]
        public string Interests { get; set; }

        /// <summary>
        /// Name of the company where users work.
        /// </summary>
        [MethodParam(Name = "company")]
        public string Company { get; set; }

        /// <summary>
        /// Job position.
        /// </summary>
        [MethodParam(Name = "position")]
        public string Position { get; set; }

        /// <summary>
        /// ID of a community to search in communities.
        /// </summary>
        [MethodParam(Name = "group_id")]
        public int? GroupId { get; set; }

        /// <summary>
        /// Sections to search in.
        /// </summary>
        [MethodParam(Name = "from_list")]
        public List<UsersSearchSections> FromList { get; set; }
    }
}