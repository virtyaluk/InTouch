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
using Newtonsoft.Json.Converters;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="NewsPost"/> describes a post from user's newsfeed.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("NewsPost")]
    public class NewsPost : Post
    {
        /// <summary>
        /// Type of newsfeed, based on the specified filters.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public NewsfeedFilters Type { get; set; }

        /// <summary>
        /// ID of the news source (positive number signifies a user; negative number signifies a community).
        /// </summary>
        [DataMember]
        [JsonProperty("source_id")]
        public int SourceId { get; set; }

        /// <summary>
        /// Post ID on the owner wall.
        /// </summary>
        [DataMember]
        [JsonProperty("post_id")]
        public int PostId { get; set; }

        /// <summary>
        /// Owner Id of copied message, if the message is a copy of the message to someone's else wall.
        /// </summary>
        [DataMember]
        [JsonProperty("copy_owner_id")]
        public int CopyOwnerId { get; set; }

        /// <summary>
        /// The id of copied message, if the message is a copy of the message to someone's else wall.
        /// </summary>
        [DataMember]
        [JsonProperty("copy_post_id")]
        public int CopyPostId { get; set; }

        /// <summary>
        /// The date of copied message, if the message is a copy of the message to someone's else wall.
        /// </summary>
        [DataMember]
        [JsonProperty("copy_post_date")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? CopyPostDate { get; set; }

        /// <summary>
        /// A list of <see cref="Photo"/> objects.
        /// </summary>
        [DataMember]
        [JsonProperty("photos")]
        public ItemsList<Photo> Photos { get; set; }

        /// <summary>
        /// A list of <see cref="Photo"/> objects.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_tags")]
        public ItemsList<Photo> PhotoTags { get; set; }

        /// <summary>
        /// A list of <see cref="Note"/> objects.
        /// </summary>
        [DataMember]
        [JsonProperty("notes")]
        public ItemsList<Note> Notes { get; set; }

        /// <summary>
        /// A list of <see cref="User"/> object.
        /// </summary>
        [DataMember]
        [JsonProperty("friends")]
        public ItemsList<User> Friends { get; set; }

        /// <summary>
        /// A list of <see cref="Video"/> objects.
        /// </summary>
        [DataMember]
        [JsonProperty("video")]
        public ItemsList<Video> Video { get; set; }

        /// <summary>
        /// A list of <see cref="Audio"/> objects.
        /// </summary>
        [DataMember]
        [JsonProperty("audio")]
        [JsonConverter(typeof(JsonNewsPostAudioConverter))]
        public ItemsList<Audio> Audio { get; set; }  
    }
}