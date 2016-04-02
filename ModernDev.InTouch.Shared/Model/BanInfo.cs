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
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Ban message.
        /// </summary>
        [DataMember]
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// ID of the administrator who added the user to the blacklist.
        /// </summary>
        [DataMember]
        [JsonProperty("admin_id")]
        public int AdminId { get; set; }

        /// <summary>
        /// Date when the user was added to the blacklist.
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Reason for ban.
        /// </summary>
        [DataMember]
        [JsonProperty("reason")]
        public BanTypes Reason { get; set; }
    }
}