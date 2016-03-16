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
    /// Uploading video server info.
    /// </summary>
    [DebuggerDisplay("VideoServerInfo")]
    [DataContract]
    public class VideoServerInfo : ServerInfo
    {
        /// <summary>
        /// Video Id.
        /// </summary>
        [DataMember]
        [JsonProperty("video_id")]
        public int VideoId { get; set; }

        /// <summary>
        /// Owner Id.
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
        /// Video description.
        /// </summary>
        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Video access key.
        /// </summary>
        [DataMember]
        [JsonProperty("access_key")]
        public string AccessKey { get; set; }
    }
}