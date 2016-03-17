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
    /// A basic class for all kind of places.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("BasicPlace {Title}")]
    public abstract class BasicPlace : Coordinates
    {
        /// <summary>
        /// Location Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Place Id.
        /// </summary>
        [DataMember]
        [JsonProperty("pid")]
        public int PId { get; set; }

        /// <summary>
        /// Location title.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Location type.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Address.
        /// </summary>
        [DataMember]
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Date  when the location was added.
        /// </summary>
        [DataMember]
        [JsonProperty("created")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Number of checkins were made on this place.
        /// </summary>
        [JsonProperty("checkins")]
        [DataMember]
        public int Checkins { get; set; }

        /// <summary>
        /// Date when the location was updated.
        /// </summary>
        [JsonProperty("updated")]
        [DataMember]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Url of icon image.
        /// </summary>
        [DataMember]
        [JsonProperty("icon")]
        public string Icon { get; set; }

        /// <summary>
        /// Group Id.
        /// </summary>
        [DataMember]
        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        /// <summary>
        /// Url of group's photo.
        /// </summary>
        [DataMember]
        [JsonProperty("group_photo")]
        public string GroupPhoto { get; set; }
    }
}