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
    /// Information about blacklisting community.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("BanInfo {Comment}")]
    public class BanInfo
    {
        /// <summary>
        /// Ban end time.
        /// </summary>
        [DataMember]
        [JsonProperty("end_date")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Ban message
        /// </summary>
        [DataMember]
        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}