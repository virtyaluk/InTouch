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

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="Photo"/> class describes a photo.
    /// </summary>
    [DebuggerDisplay("Photo {PhotoId}_{OwnerId}")]
    [DataContract]
    public class Photo : IMediaAttachment, IMessageAttachment
    {
        #region Properties

        /// <summary>
        /// Photo ID. 
        /// </summary>
        [DataMember]
        [JsonProperty("pid")]
        public int PhotoId { get; set; }

        /// <summary>
        /// Photo Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Photo album ID. 
        /// </summary>
        [DataMember]
        [JsonProperty("aid")]
        public int AlbumId { get; set; }

        /// <summary>
        /// ID of the user or community that owns the photo.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// URL of image with maximum size 130x130px. 
        /// </summary>
        [DataMember]
        [JsonProperty("src")]
        public string Src { get; set; }

        /// <summary>
        /// URL of image with maximum size 604x604px. 
        /// </summary>
        [DataMember]
        [JsonProperty("src_big")]
        public string SrcBig { get; set; }

        /// <summary>
        /// URL of image with maximum size 75x75px. 
        /// </summary>
        [DataMember]
        [JsonProperty("src_small")]
        public string SrcSmall { get; set; }

        /// <summary>
        /// URL of image with maximum size 807x807px. 
        /// </summary>
        [DataMember]
        [JsonProperty("src_xbig")]
        public string SrcXBig { get; set; }

        /// <summary>
        /// URL of image with maximum size 1280x1024px. 
        /// </summary>
        [DataMember]
        [JsonProperty("src_xxbig")]
        public string SrcXXBig { get; set; }

        /// <summary>
        /// URL of image with maximum size 2560x2048px. 
        /// </summary>
        [DataMember]
        [JsonProperty("src_xxxbig")]
        public string SrcXXXBig { get; set; }

        /// <summary>
        /// Width (in pixels) of the original photo. 
        /// </summary>
        [DataMember]
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Height (in pixels) of the original photo. 
        /// </summary>
        [DataMember]
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// Text describing the photo. 
        /// </summary>
        [DataMember]
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Date the photo was added.
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime Date { get; set; }

        /// <summary>
        /// URL of image with maximum size 75x75px.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_75")]
        public string Photo75 { get; set; }

        /// <summary>
        /// URL of image with maximum size 130x130px.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_130")]
        public string Photo130 { get; set; }

        /// <summary>
        /// URL of image with maximum size 604x604px.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_604")]
        public string Photo604 { get; set; }

        /// <summary>
        /// URL of image with maximum size 807x807px.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_807")]
        public string Photo807 { get; set; }

        /// <summary>
        /// URL of image with maximum size 1280x1024px.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_1280")]
        public string Photo1280 { get; set; }

        /// <summary>
        /// URL of image with maximum size 2560x2048px.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_2560")]
        public string Photo2560 { get; set; }

        /// <summary>
        /// A list of a <see cref="PhotoSize"/> objects containing an info about original photo copies with different sizes
        /// </summary>
        [DataMember]
        [JsonProperty("sizes")]
        public List<PhotoSize> Sizes { get; set; }

        /// <summary>
        /// Number of likes and information whether the current user liked the photo.
        /// </summary>
        [DataMember]
        [JsonProperty("likes")]
        public Likes Likes { get; set; }

        /// <summary>
        /// Number of comments on the photo.
        /// </summary>
        [DataMember]
        [JsonProperty("comments")]
        public Comments Comments { get; set; }

        /// <summary>
        /// Number of tags on the photo.
        /// </summary>
        [DataMember]
        [JsonProperty("tags")]
        public Tags Tags { get; set; }

        /// <summary>
        /// Number of reposts of the photo.
        /// </summary>
        [DataMember]
        [JsonProperty("reposts")]
        public Reposts Reposts { get; set; }

        /// <summary>
        /// Whether the current user can comment on the photo.
        /// </summary>
        [DataMember]
        [JsonProperty("can_comment")]
        public bool CanComment { get; set; }

        /// <summary>
        /// If location is attached to a photo, returns a geo latitude of a place where the photo was taken.
        /// </summary>
        [DataMember]
        [JsonProperty("lat")]
        public int Lat { get; set; }

        /// <summary>
        /// If location is attached to a photo, returns a geo longitude of a place where the photo was taken.
        /// </summary>
        [DataMember]
        [JsonProperty("long")]
        public int Long { get; set; }

        #region Extra properties

        /// <summary>
        /// The key to access the content.
        /// </summary>
        [DataMember]
        [JsonProperty("access_key")]
        public string AccessKey { get; set; }

        /// <summary>
        /// Message ID the attachment is attached to.
        /// </summary>
        [DataMember]
        [JsonProperty("message_id")]
        public int? MessageId { get; set; }

        #endregion

        #region Tag properties

        /// <summary>
        /// ID of the user who added the tag.
        /// </summary>
        [DataMember]
        [JsonProperty("")]
        public int PlacerId { get; set; }

        /// <summary>
        /// Tag creation date.
        /// </summary>
        [DataMember]
        [JsonProperty("tag_create")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? TagCreated { get; set; }

        /// <summary>
        /// Tag ID.
        /// </summary>
        [DataMember]
        [JsonProperty("tag_id")]
        public int TagId { get; set; }

        #endregion

        #endregion
    }
}
