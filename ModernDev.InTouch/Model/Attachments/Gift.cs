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
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="Gift"/> class represents information about gift.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Gift {Id}")]
    [APIVersion(Version = 5.45)]
    public class Gift : IMediaAttachment
    {
        /// <summary>
        /// Gift Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// URL of image with maximum size 256x256px.
        /// </summary>
        [DataMember]
        [JsonProperty("thumb_256")]
        public string Thumb256 { get; set; }

        /// <summary>
        /// URL of image with maximum size 96x96px.
        /// </summary>
        [DataMember]
        [JsonProperty("thumb_96")]
        public string Thumb96 { get; set; }

        /// <summary>
        /// URL of image with maximum size 48x48px.
        /// </summary>
        [DataMember]
        [JsonProperty("thumb_48")]
        public string Thumb48 { get; set; }

        /// <summary>
        /// Gift build hash.
        /// </summary>
        [DataMember]
        [JsonProperty("build_id")]
        public string BuildId { get; set; }
    }
}