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
using Newtonsoft.Json.Converters;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="PostSource"/> class contain information about how the post was created.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("PostSource")]
    public class PostSource
    {
        /// <summary>
        /// The post source type.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PostSoureTypes? Type { get; set; }

        /// <summary>
        /// Which platform was used.
        /// </summary>
        [DataMember]
        [JsonProperty("platform")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PostSourcePlatforms? Platform { get; set; }

        /// <summary>
        /// What action caused creation of the post.
        /// </summary>
        [DataMember]
        [JsonProperty("data")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PostSourceDataTypes? Data { get; set; }

        /// <summary>
        /// Url of a external resource where the post was created.
        /// </summary>
        [DataMember]
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}