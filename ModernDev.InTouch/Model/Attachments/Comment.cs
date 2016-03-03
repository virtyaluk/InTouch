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
    /// A <see cref="Comment"/> class describes a comment.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Comment {Id}")]
    [APIVersion(Version = 5.45)]
    public class Comment : IMediaAttachment
    {
        /// <summary>
        /// Comment ID.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Comment author ID.
        /// </summary>
        [DataMember]
        [JsonProperty("from_id")]
        public int FromId { get; set; }

        /// <summary>
        /// Post ID.
        /// </summary>
        [DataMember]
        [JsonProperty("post_id")]
        public int PostId { get; set; }

        /// <summary>
        /// User ID or community ID.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Date when the comment was added.
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// ID of the user or community to whom the reply is addressed (if the comment is a reply to another comment).
        /// </summary>
        [DataMember]
        [JsonProperty("reply_to_user")]
        public int ReplyToUser { get; set; }

        /// <summary>
        /// ID of the comment the reply to which is represented by the current comment (if the comment is a reply to another comment).
        /// </summary>
        [DataMember]
        [JsonProperty("reply_to_comment")]
        public int ReplyToComment { get; set; }

        /// <summary>
        /// Information about likes.
        /// </summary>
        [DataMember]
        [JsonProperty("likes")]
        public Likes Likes { get; set; }

        /// <summary>
        /// Information about attachments in the comment.
        /// </summary>
        [DataMember]
        [JsonProperty("attachments")]
        [JsonConverter(typeof(JsonAttachmentsConverter))]
        public IReadOnlyCollection<IMediaAttachment> Attachments { get; set; } 
    }
}