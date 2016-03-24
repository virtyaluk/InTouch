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
    /// Photo tag.
    /// </summary>
    [DebuggerDisplay("Tag {TaggedName}")]
    [DataContract]
    public class Tag
    {
        /// <summary>
        /// Tag Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Tag Id.
        /// </summary>
        [DataMember]
        [JsonProperty("tag_id")]
        public int TagId { get; set; }

        /// <summary>
        /// ID of the user to whom the tag corresponds.
        /// </summary>
        [DataMember]
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// ID of the user who added the tag.
        /// </summary>
        [DataMember]
        [JsonProperty("placer_id")]
        public int PlacerId { get; set; }

        /// <summary>
        /// Tag name.
        /// </summary>
        [DataMember]
        [JsonProperty("tagged_name")]
        public string TaggedName { get; set; }

        /// <summary>
        ///  Date the tag was added.
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Tag status (True — confirmed, False — not confirmed).
        /// </summary>
        [DataMember]
        [JsonProperty("viewed")]
        public bool Viewed { get; set; }

        /// <summary>
        /// X coordinate of the upper left corner of the rectangular area where the tag was added.
        /// </summary>
        [DataMember]
        [JsonProperty("x")]
        public int X { get; set; }

        /// <summary>
        /// Y coordinate of the upper left corner of the rectangular area where the tag was added.
        /// </summary>
        [DataMember]
        [JsonProperty("y")]
        public int Y { get; set; }

        /// <summary>
        /// X coordinate of the lower right corner of the rectangular area where the tag was added.
        /// </summary>
        [DataMember]
        [JsonProperty("x2")]
        public int X2 { get; set; }

        /// <summary>
        /// Y coordinate of the lower right corner of the rectangular area where the tag was added.
        /// </summary>
        [DataMember]
        [JsonProperty("y2")]
        public int Y2 { get; set; }
    }
}