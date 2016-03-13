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
using System.Collections.Generic;

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

        /// <summary>
        /// Photo Id of album's cover (0 if none).
        /// </summary>
        [DataMember]
        [JsonProperty("thumb_id")]
        public int ThumbId { get; set; }

        /// <summary>
        /// Privacy settings for album viewing (only for the album's owner).
        /// </summary>
        [DataMember]
        [JsonProperty("privacy_view")]
        public List<string> PrivacyView { get; set; }

        /// <summary>
        /// Privacy settings for album commenting (only for album's owner).
        /// </summary>
        [DataMember]
        [JsonProperty("privacy_comment")]
        public List<string> PrivacyComment { get; set; }

        /// <summary>
        /// Whether the admin only can upload to the album (only for album's owner).
        /// </summary>
        [DataMember]
        [JsonProperty("upload_by_admins_only")]
        public bool UploadByAdminsOnly { get; set; }

        /// <summary>
        /// Whether the album commenting is enabled.
        /// </summary>
        [DataMember]
        [JsonProperty("comments_disabled")]
        public bool CommentsDisabled { get; set; }

        /// <summary>
        /// Whether the current user is able to upload photos to the album.
        /// </summary>
        [DataMember]
        [JsonProperty("can_upload")]
        public bool CanUpload { get; set; }

        /// <summary>
        /// URL of the album's cover image.
        /// </summary>
        [DataMember]
        [JsonProperty("thumb_src")]
        public string ThumbSrc { get; set; }

        /// <summary>
        /// A list of a <see cref="PhotoSize"/> objects containing an info about original cover photo copies with different sizes
        /// </summary>
        [DataMember]
        [JsonProperty("sizes")]
        public List<PhotoSize> Sizes { get; set; }
    }
}