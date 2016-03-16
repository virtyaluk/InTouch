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
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Video album.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("VideoAlbum {Title}")]
    public class VideoAlbum : IVideoCatalogItem
    {
        #region Properties

        /// <summary>
        /// Album Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Owner Id.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Album title.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Number of videos in the album.
        /// </summary>
        [DataMember]
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// URL of the album cover with 320px width.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_320")]
        public string Photo320 { get; set; }

        /// <summary>
        /// URL of the album cover with 160px width.
        /// </summary>
        [DataMember]
        [JsonProperty("photo)160")]
        public string Photo160 { get; set; }

        /// <summary>
        /// Last update time.
        /// </summary>
        [DataMember]
        [JsonProperty("updated_time")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? UpdatedTime { get; set; }

        /// <summary>
        /// Privacy settings
        /// </summary>
        [DataMember]
        [JsonProperty("privacy")]
        public List<string> Privacy { get; set; }

        #region Video catalog properties

        /// <summary>
        /// The type of an item.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        [JsonConverter(typeof (StringEnumConverter))]
        public VideoCatalogItemTypes Type { get; set; } = VideoCatalogItemTypes.Album;

        #endregion

        #endregion
    }
}