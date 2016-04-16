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

using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Repost result.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("RepostResult {Success}")]
    public class RepostResult
    {
        /// <summary>
        /// Whether the repost was successful.
        /// </summary>
        [DataMember]
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Id of created post.
        /// </summary>
        [DataMember]
        [JsonProperty("post_id")]
        public int PostId { get; set; }

        /// <summary>
        /// The number of reposts.
        /// </summary>
        [DataMember]
        [JsonProperty("reposts_count")]
        public int RepostsCount { get; set; }

        /// <summary>
        /// The number of times users liked the post.
        /// </summary>
        [DataMember]
        [JsonProperty("likes_count")]
        public int LikesCount { get; set; }
    }
}