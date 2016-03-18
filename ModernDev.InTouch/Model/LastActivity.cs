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
    /// Users last activity.
    /// </summary>
    [DebuggerDisplay("LastActivity")]
    [DataContract]
    public class LastActivity
    {
        /// <summary>
        /// Whether the user is online.
        /// </summary>
        [DataMember]
        [JsonProperty("online")]
        public bool IsOnline { get; set; }

        /// <summary>
        /// The time of user's last activity.
        /// </summary>
        [DataMember]
        [JsonProperty("time")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime LastActivityTime { get; set; }
    }
}