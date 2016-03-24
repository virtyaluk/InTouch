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
using System.Diagnostics;
using System.Runtime.Serialization;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="Checkin"/> class describes a place checkin.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Checkin {Text.Substring(0, 50}")]
    public class Checkin : Coordinates
    {
        /// <summary>
        /// Check-in ID.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// ID of the checked-in user.
        /// </summary>
        [DataMember]
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Post Id.
        /// </summary>
        [DataMember]
        [JsonProperty("post_id")]
        public int PostId { get; set; }

        /// <summary>
        /// Date when the tag was added.
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Location ID.
        /// </summary>
        [DataMember]
        [JsonProperty("place_id")]
        public int PlaceId { get; set; }

        /// <summary>
        /// Text of the related message.
        /// </summary>
        [DataMember]
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Distance from the initial search point.
        /// </summary>
        [DataMember]
        [JsonProperty("distance")]
        public int Distance { get; set; }

        /// <summary>
        /// Location title.
        /// </summary>
        [DataMember]
        [JsonProperty("place_title")]
        public string PlaceTitle { get; set; }

        /// <summary>
        /// Country ID.
        /// </summary>
        [DataMember]
        [JsonProperty("place_country")]
        public int PlaceCountryId { get; set; }

        /// <summary>
        /// City ID.
        /// </summary>
        [DataMember]
        [JsonProperty("place_city")]
        public int PlaceCityId { get; set; }

        /// <summary>
        /// Street address of the location.
        /// </summary>
        [DataMember]
        [JsonProperty("place_address")]
        public string PlaceAddress { get; set; }

        /// <summary>
        /// Location type.
        /// </summary>
        [DataMember]
        [JsonProperty("place_type")]
        public int PlaceTypeId { get; set; }

        /// <summary>
        /// Location icon.
        /// </summary>
        [DataMember]
        [JsonProperty("place_icon")]
        public string PlaceIcon { get; set; }
    }
}