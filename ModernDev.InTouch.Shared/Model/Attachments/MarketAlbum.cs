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
    /// A collection of market items.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("MarketAlbum {Title}")]
    public class MarketAlbum : BaseAlbum, IMediaAttachment
    {
        /// <summary>
        /// Collection cover.
        /// </summary>
        [DataMember]
        [JsonProperty("photo")]
        public Photo Photo { get; set; }

        /// <summary>
        /// Number of items in a collection
        /// </summary>
        [DataMember]
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Collection's last update date.
        /// </summary>
        [DataMember]
        [JsonProperty("updated_time")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime UpdatedTime { get; set; }
    }
}