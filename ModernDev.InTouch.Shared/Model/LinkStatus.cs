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
    /// The link status.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("LinkStatus {Status} {Link}")]
    public class LinkStatus
    {
        /// <summary>
        /// The link itself.
        /// </summary>
        [DataMember]
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        /// The link status.
        /// </summary>
        [DataMember]
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LinkStatus Status { get; set; }
    }
}