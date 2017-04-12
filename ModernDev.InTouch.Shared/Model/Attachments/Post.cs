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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="Post"/> class  describes a wall post.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Post {Id}")]
    public class Post : IMediaAttachment, IFeedback, IMessageAttachment
    {
        #region Properties

        /// <summary>
        /// Post ID on the wall. 
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Wall owner ID.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// ID of the user who posted. 
        /// </summary>
        [DataMember]
        [JsonProperty("from_id")]
        public int? FromId { get; set; }

        /// <summary>
        /// Date the post was added. 
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Text of the post. 
        /// </summary>
        [DataMember]
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// ID of the wall owner the post to which the reply is addressed (if the post is a reply to another wall post). 
        /// </summary>
        [DataMember]
        [JsonProperty("reply_owner_id")]
        public int? ReplyOwnerId { get; set; }

        /// <summary>
        /// ID of the wall post to which the reply is addressed (if the post is a reply to another wall post). 
        /// </summary>
        [DataMember]
        [JsonProperty("reply_post_id")]
        public int? ReplyPostId { get; set; }

        /// <summary>
        /// True, if the post was created with "Friends only" option. 
        /// </summary>
        [DataMember]
        [JsonProperty("friends_only")]
        public bool FriendsOnly { get; set; }

        /// <summary>
        /// Information about comments to the post.
        /// </summary>
        [DataMember]
        [JsonProperty("comments")]
        public Comments Comments { get; set; }

        /// <summary>
        /// Information about likes to the post.
        /// </summary>
        [DataMember]
        [JsonProperty("likes")]
        public Likes Likes { get; set; }

        /// <summary>
        /// Information about reposts.
        /// </summary>
        [DataMember]
        [JsonProperty("reposts")]
        public Reposts Reposts { get; set; }

        /// <summary>
        /// Type of the post.
        /// </summary>
        [DataMember]
        [JsonProperty("post_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PostTypes PostType { get; set; }

        /// <summary>
        /// Information about the means of posting.
        /// </summary>
        [DataMember]
        [JsonProperty("post_source")]
        public PostSource PostSource { get; set; }

        /// <summary>
        /// Information about attachments to the post.
        /// </summary>
        [DataMember]
        [JsonProperty("attachments")]
        [JsonConverter(typeof(JsonAttachmentsConverter))]
        public ReadOnlyCollection<IMediaAttachment> Attachments { get; set; }

        /// <summary>
        /// Information about location.
        /// </summary>
        [DataMember]
        [JsonProperty("geo")]
        public Geo Geo { get; set; }

        /// <summary>
        /// ID of the author (if the post was published by a community and signed by a user).
        /// </summary>
        [DataMember]
        [JsonProperty("signer_id")]
        public int? SignerId { get; set; }

        /// <summary>
        /// A list containing reposts history for current post. Returns only if current post is a repost.
        /// Each list item is a <see cref="Post"/> object as well.
        /// </summary>
        [DataMember]
        [JsonProperty("copy_history")]
        public List<Post> CopyHistory { get; set; }

        /// <summary>
        /// Shows if current user can pin a post.
        /// </summary>
        [DataMember]
        [JsonProperty("can_pin")]
        public bool CanPin { get; set; }

        /// <summary>
        /// Whether the current user can delete the post.
        /// </summary>
        [DataMember]
        [JsonProperty("can_delete")]
        public bool CanDelete { get; set; }

        /// <summary>
        /// Whether the current user can edit the post.
        /// </summary>
        [DataMember]
        [JsonProperty("can_edit")]
        public bool CanEdit { get; set; }

        /// <summary>
        /// Shows if the post is pinned.
        /// </summary>
        [DataMember]
        [JsonProperty("is_pinned")]
        public bool IsPinned { get; set; }

        /// <summary>
        /// An information about post views.
        /// </summary>
        [DataMember, JsonProperty("views")]
        public PostViews Views { get; set; }

        #region Extra properties

        [DataMember]
        [JsonProperty("to_id")]
        public int? ToId { get; set; }

        /// <summary>
        /// Message ID the attachment is attached to.
        /// </summary>
        [DataMember]
        [JsonProperty("message_id")]
        public int? MessageId { get; set; }

        #endregion

        #endregion
    }
}