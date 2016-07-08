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
using Newtonsoft.Json;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json.Converters;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="Video"/> class describes video file.
    /// </summary>
    [DebuggerDisplay("Video {Title}")]
    [DataContract]
    public class Video : IMediaAttachment, IVideoCatalogItem
    {
        #region Properties

        /// <summary>
        /// Video ID. 
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// ID of the user or community that owns the video. 
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Video title. 
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Description of the video. 
        /// </summary>
        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Duration of the video, in seconds.
        /// </summary>
        [DataMember]
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// String with video+vid key. 
        /// </summary>
        [DataMember]
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        /// URL of the video cover image with the size of 130x98px. 
        /// </summary>
        [DataMember]
        [JsonProperty("photo_130")]
        public string Photo130 { get; set; }

        /// <summary>
        /// URL of the video cover image with the size of 320x240px. 
        /// </summary>
        [DataMember]
        [JsonProperty("photo_320")]
        public string Photo320 { get; set; }

        /// <summary>
        /// URL of the video cover image with the size of 640x480px (if available).
        /// </summary>
        [DataMember]
        [JsonProperty("photo_640")]
        public string Photo640 { get; set; }

        /// <summary>
        /// URL of the video cover image with the size of 800x640px (if available).
        /// </summary>
        [DataMember]
        [JsonProperty("photo_800")]
        public string Photo800 { get; set; }

        /// <summary>
        /// Date (in Unix time) the video was created. 
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime Date { get; set; }

        /// <summary>
        /// Date (in Unix time) the video was added by user or group. 
        /// </summary>
        [DataMember]
        [JsonProperty("adding_date")]
        public int AddingDate { get; set; }

        /// <summary>
        /// Number of times the video has been viewed. 
        /// </summary>
        [DataMember]
        [JsonProperty("views")]
        public int Views { get; set; }

        /// <summary>
        /// URL of the page with a player that can be used to play the video in the browser.
        /// Flash and HTML5 video players are supported; the player is always zoomed to fit the window size. 
        /// </summary>
        [DataMember]
        [JsonProperty("player")]
        public string Player { get; set; }

        /// <summary>
        /// The number of comments to the video.
        /// </summary>
        [DataMember]
        [JsonProperty("comments")]
        public int Comments { get; set; }

        /// <summary>
        /// The key to access the content.
        /// </summary>
        [DataMember]
        [JsonProperty("access_key")]
        public string AccessKey { get; set; }

        /// <summary>
        /// Whether the video is a live broadcast.
        /// </summary>
        [DataMember]
        [JsonProperty("live")]
        public bool Live { get; set; }

        /// <summary>
        /// Whether the video is being processed by a server.
        /// </summary>
        [DataMember]
        [JsonProperty("processing")]
        public bool Proccessing { get; set; }

        /// <summary>
        /// If you use direct authorization in your app, returns an additional <see cref="VideoFiles"/> field,
        /// containing a link to the video file (if the video is placed on a VK server)
        /// or a link to an external site (if the video is integrated from another video hosting service).
        /// </summary>
        [DataMember]
        [JsonProperty("files")]
        public VideoFiles Files { get; set; }

        #region Extended properties

        /// <summary>
        /// Information about likes.
        /// </summary>
        [DataMember]
        [JsonProperty("likes")]
        public Likes Likes { get; set; }

        /// <summary>
        /// Whether the current user can copy the video using the "Share with friends" feature.
        /// </summary>
        [DataMember]
        [JsonProperty("can_repost")]
        public bool CanRepost { get; set; }

        /// <summary>
        /// Whether the current user can comment on the video.
        /// </summary>
        [DataMember]
        [JsonProperty("can_comment")]
        public bool CanComment { get; set; }

        /// <summary>
        /// Whether the current user can add video to the own page.
        /// </summary>
        [DataMember]
        [JsonProperty("can_add")]
        public bool CanAdd { get; set; }

        /// <summary>
        /// Privacy settings in a special format (only for the current user).
        /// </summary>
        [DataMember]
        [JsonProperty("privacy_view")]
        public List<object> PrivacyView { get; set; }

        /// <summary>
        /// Comment privacy settings in a special format (only for the current user).
        /// </summary>
        [DataMember]
        [JsonProperty("privacy_comment")]
        public List<object> PrivacyComment { get; set; }

        /// <summary>
        /// Whether the video is repeating.
        /// </summary>
        [DataMember]
        [JsonProperty("repeat")]
        public bool Repeat { get; set; }

        #endregion

        #region Tags

        /// <summary>
        /// Tag placer Id.
        /// </summary>
        [DataMember]
        [JsonProperty("placer_id")]
        public int PlacerId { get; set; }

        /// <summary>
        /// Tag Id.
        /// </summary>
        [DataMember]
        [JsonProperty("tag_id")]
        public int TagId { get; set; }

        /// <summary>
        /// Date the tag was created.
        /// </summary>
        [DataMember]
        [JsonProperty("tag_created")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? TagCreated { get; set; }

        #endregion

        #region Video catalog properties

        /// <summary>
        /// The type of an item.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public VideoCatalogItemTypes Type { get; set; } = VideoCatalogItemTypes.Video;

        #endregion

        #endregion

        public override string ToString()
        {
            return Title;
        }
    }
}