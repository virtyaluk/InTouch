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
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="ProfileInfo"/> class describes the current user profile data.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("ProfileInfo {FirstName} {LastName}")]
    public class ProfileInfo
    {
        /// <summary>
        /// User first name.
        /// </summary>
        [DataMember]
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// User last name.
        /// </summary>
        [DataMember]
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// User maiden name (female users only).
        /// </summary>
        [DataMember]
        [JsonProperty("maiden_name")]
        public string MaidenName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        /// <summary>
        /// User sex.
        /// </summary>
        [DataMember]
        [JsonProperty("sex")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UserSex Sex { get; set; }

        /// <summary>
        /// User relationship status.
        /// </summary>
        [DataMember]
        [JsonProperty("relation")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RelationTypes Relation { get; set; }

        /// <summary>
        /// An <see cref="User"/> object, relationship partner (if specified).
        /// </summary>
        [DataMember]
        [JsonProperty("relation_partner")]
        public User RelationPartner { get; set; }

        /// <summary>
        /// Returns True if specified partner did not approve a relationship status
        /// </summary>
        [DataMember]
        [JsonProperty("relation_pending")]
        public bool RelationPending { get; set; }

        /// <summary>
        /// A list of <see cref="User"/> objects who specified a relationship with a current user (if exist).
        /// </summary>
        [DataMember]
        [JsonProperty("relation_requests")]
        public List<User> RelationRequests { get; set; }

        /// <summary>
        /// User birth date, format: DD.MM.YYYY
        /// </summary>
        [DataMember]
        [JsonProperty("bdate")]
        public string BDate { get; set; }

        /// <summary>
        /// Birth date visibility.
        /// </summary>
        [DataMember]
        [JsonProperty("bdate_visibility")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BDateVisibility BDateVisibility { get; set; }

        /// <summary>
        /// User home town.
        /// </summary>
        [DataMember]
        [JsonProperty("home_town")]
        public string HomeTown { get; set; }

        /// <summary>
        /// User country.
        /// </summary>
        [DataMember]
        [JsonProperty("country")]
        public Country Country { get; set; }

        /// <summary>
        /// User city.
        /// </summary>
        [DataMember]
        [JsonProperty("city")]
        public City City { get; set; }

        /// <summary>
        /// Object containing the last name change request info if it was filed.
        /// </summary>
        [DataMember]
        [JsonProperty("name_request")]
        public NameRequest NameRequest { get; set; }
    }
}