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

using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ModernDev.InTouch.Helpers;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="Video"/> class describes video file.
    /// </summary>
    [DebuggerDisplay("Video {Title}")]
    [DataContract]
    public partial class Video
    {
        #region Properties

        [IgnoreDataMember]
        public string Type { get; } = "Video";

        /// <summary>
        /// Video ID. 
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

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
        /// Date (in Unix time) the video was created. 
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        public int Date { get; set; }

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

        [DataMember]
        [JsonProperty("comments")]
        public int Comments { get; set; }

        [DataMember]
        [JsonProperty("access_key")]
        public string AccessKey { get; set; }

        [DataMember]
        [JsonConverter(typeof(JsonBoolConverter))]
        [JsonProperty("live")]
        public bool Live { get; set; }

        [DataMember]
        [JsonConverter(typeof(JsonBoolConverter))]
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

        #region Extended fields

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
        [JsonConverter(typeof(JsonBoolConverter))]
        [JsonProperty("can_repost")]
        public bool CanRepost { get; set; }

        /// <summary>
        /// Whether the current user can comment on the video.
        /// </summary>
        [DataMember]
        [JsonConverter(typeof(JsonBoolConverter))]
        [JsonProperty("can_comment")]
        public bool CanComment { get; set; }

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

        #endregion
        #endregion
    }
}