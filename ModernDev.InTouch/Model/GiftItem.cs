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
    /// A <see cref="GiftItem"/> describes a gift item.
    /// </summary>
    [DebuggerDisplay("Gift {Id}, {FromId}")]
    [DataContract]
    public class GiftItem
    {
        /// <summary>
        /// Gift receiver Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gift sender Id. 0, if anonymous.
        /// </summary>
        [DataMember]
        [JsonProperty("from_id")]
        public int FromId { get; set; }

        /// <summary>
        /// Gift message.
        /// </summary>
        [DataMember]
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Sending date.
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// A <see cref="Gift"/> object.
        /// </summary>
        [DataMember]
        [JsonProperty("gift")]
        public Gift Gift { get; set; }

        /// <summary>
        /// A privacy level for the gift.
        /// </summary>
        [DataMember]
        [JsonProperty("privacy")]
        public GiftPrivacies Privacy { get; set; }
    }
}
