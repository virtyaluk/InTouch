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
    /// A <see cref="Topic"/> class describes board topic.
    /// </summary>
    [DebuggerDisplay("Topic")]
    [DataContract]
    public class Topic
    {
        /// <summary>
        /// Topic ID.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Title.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Date the topic was created.
        /// </summary>
        [DataMember]
        [JsonProperty("created")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime Created { get; set; }

        /// <summary>
        /// ID of the user who created the topic.
        /// </summary>
        [DataMember]
        [JsonProperty("created_by")]
        public int CreatedBy { get; set; }

        /// <summary>
        /// Date of the last comment on the topic.
        /// </summary>
        [DataMember]
        [JsonProperty("updated")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime Updated { get; set; }

        /// <summary>
        /// ID of the user who left the last comment.
        /// </summary>
        [DataMember]
        [JsonProperty("updated_by")]
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Whether the topic is closed so that comments cannot be posted.
        /// </summary>
        [DataMember]
        [JsonProperty("is_closed")]
        public bool IsClosed { get; set; }

        /// <summary>
        /// Whether the topic is pinned (its place fixed) at the top of the topic list.
        /// </summary>
        [DataMember]
        [JsonProperty("is_fixed")]
        public bool IsFixed { get; set; }

        /// <summary>
        /// Number of comments on the topic.
        /// </summary>
        [DataMember]
        [JsonProperty("comments")]
        public int Comments { get; set; }

        /// <summary>
        /// Text of the first comment.
        /// </summary>
        [DataMember]
        [JsonProperty("first_comment")]
        public string FirstComment { get; set; }

        /// <summary>
        /// Text of the last comment.
        /// </summary>
        [DataMember]
        [JsonProperty("last_comment")]
        public string LastComment { get; set; }
    }
}