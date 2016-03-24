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
    /// A base class for all kind of notification.
    /// </summary>
    [DebuggerDisplay("NotificationItem")]
    [DataContract]
    public abstract class NotificationItem
    {
        /// <summary>
        /// Notification type.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Date the feedback appeared.
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime Date { get; set; }

        /// <summary>
        /// An object describing a comment by the user, sent as a reply to the notification. Is absent if there are no replies.
        /// </summary>
        [DataMember]
        [JsonProperty("reply")]
        public Comment Reply { get; set; }
    }
}