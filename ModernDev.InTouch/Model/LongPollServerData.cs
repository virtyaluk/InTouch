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
    /// The data to interact with Long Poll server.
    /// </summary>
    [DebuggerDisplay("LongPollServerData")]
    [DataContract]
    public class LongPollServerData
    {
        [DataMember]
        [JsonProperty("key")]
        public string Key { get; set; }

        [DataMember]
        [JsonProperty("server")]
        public string Server { get; set; }

        [DataMember]
        [JsonProperty("ts")]
        public int TS { get; set; }

        [DataMember]
        [JsonProperty("pts")]
        public int PTS { get; set; }
    }
}