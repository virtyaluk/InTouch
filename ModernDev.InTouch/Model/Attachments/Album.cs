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
    /// An <see cref="Album"/> represents a photo album.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Album {Title}")]
    [APIVersion(Version = 5.45)]
    public class Album : IMediaAttachment
    {
        /// <summary>
        /// Album Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Album cover.
        /// </summary>
        [DataMember]
        [JsonProperty("thumb")]
        public Photo Thumb { get; set; }

        /// <summary>
        /// Id of the user or community that owns the album.
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
        /// Album description.
        /// </summary>
        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Date the album was created.
        /// </summary>
        [DataMember]
        [JsonProperty("created")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Date the album was updated.
        /// </summary>
        [DataMember]
        [JsonProperty("updated")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Updated { get; set; }

        /// <summary>
        /// The number of photos in the album.
        /// </summary>
        [DataMember]
        [JsonProperty("size")]
        public int Size { get; set; }
    }
}