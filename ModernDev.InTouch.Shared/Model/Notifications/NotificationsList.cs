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
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="NotificationsList"/> object describes user's notification.
    /// </summary>
    [DebuggerDisplay("NotificationsList")]
    [DataContract]
    public class NotificationsList : ItemsList<NotificationItem>
    {
        /// <summary>
        /// The last time user checked the notifications.
        /// </summary>
        [DataMember]
        [JsonProperty("last_viewed")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? LastViewed { get; set; }

        /// <summary>
        /// Offset needed for the next API call.
        /// </summary>
        [DataMember]
        [JsonProperty("next_from")]
        public string NextFrom { get; set; }

        /// <summary>
        /// A list of notifications for the current user.
        /// </summary>
        [DataMember]
        [JsonProperty("items")]
        [JsonConverter(typeof(JsonNotificationItemsConverter))]
        public new List<NotificationItem> Items { get; set; } 
    }
}