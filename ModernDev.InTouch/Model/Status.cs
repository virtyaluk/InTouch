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

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="Status"/> class describes a user's or a community's text status.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Status {Text}")]
    public class Status
    {
        /// <summary>
        /// Text of the status.
        /// </summary>
        [DataMember]
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// The current audio user listening to (if any).
        /// </summary>
        [DataMember]
        [JsonProperty("audio")]
        public Audio Audio { get; set; }
    }
}