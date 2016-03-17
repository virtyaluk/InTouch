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
    /// Notifications settings.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("NotificationsSettings")]
    public class NotificationsSettings
    {
        /// <summary>
        /// Whether the notifications is disabled.
        /// </summary>
        [DataMember]
        [JsonProperty("disabled")]
        public bool Disabled { get; set; }

        /// <summary>
        /// Time value, notifications are temporarily disabled until.
        /// </summary>
        [DataMember]
        [JsonProperty("disabled_until")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Until { get; set; }

        /// <summary>
        /// Information about push notifications settings.
        /// </summary>
        [DataMember]
        [JsonProperty("settings")]
        public string Settings { get; set; }

        /// <summary>
        /// List with settings of specific conversations and their number as the first element.
        /// TODO: Deserialize
        /// </summary>
        [DataMember]
        [JsonProperty("conversations")]
        public string Conversations { get; set; }
    }
}