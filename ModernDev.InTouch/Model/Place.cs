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
    /// A <see cref="Place"/> class describes a location item.
    /// </summary>
    [DebuggerDisplay("Place {Title}")]
    [DataContract]
    public partial class Place
    {
        /// <summary>
        /// Location ID.
        /// </summary>
        [DataMember]
        [JsonProperty("pid")]
        public int Id { get; set; }

        /// <summary>
        /// Location title.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Geographical latitude, in degrees (from -90 to 90).
        /// </summary>
        [DataMember]
        [JsonProperty("latitude")]
        public int Latitude { get; set; }

        /// <summary>
        /// Geographical longitude, in degrees (from -180 to 180).
        /// </summary>
        [DataMember]
        [JsonProperty("longitude ")]
        public int Longitude { get; set; }

        /// <summary>
        /// Location type.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Country ID.
        /// </summary>
        [DataMember]
        [JsonProperty("country ")]
        public int CountryId { get; set; }

        /// <summary>
        /// City ID.
        /// </summary>
        [DataMember]
        [JsonProperty("city")]
        public int? CityId { get; set; }

        /// <summary>
        /// Address.
        /// </summary>
        [DataMember]
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Date  when the location was added.
        /// </summary>
        [JsonProperty("created")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime Created { get; set; }

        /// <summary>
        /// Number of checkins were made on this place.
        /// </summary>
        [JsonProperty("checkins")]
        public int Checkins { get; set; }

        /// <summary>
        /// Date when the location was updated.
        /// </summary>
        [JsonProperty("updated")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime Updated { get; set; }
    }
}