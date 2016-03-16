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
    /// Chat notification settings.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("ChatPushSettings")]
    public class ChatPushSettings
    {
        /// <summary>
        /// Sounds status.
        /// </summary>
        [DataMember]
        [JsonProperty("sounds")]
        public int Sounds { get; set; }

        /// <summary>
        /// Disabled status.
        /// </summary>
        [DataMember]
        [JsonProperty("disabled_until")]
        public int DisabledUntil { get; set; }
    }
}