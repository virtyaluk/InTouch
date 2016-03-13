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
    /// Upload server response.
    /// </summary>
    [DebuggerDisplay("UploadResponse {Server}")]
    [DataContract]
    public abstract class UploadResponse
    {
        /// <summary>
        /// Server name.
        /// </summary>
        [DataMember]
        [JsonProperty("server")]
        public string Server { get; set; }

        /// <summary>
        /// Hash
        /// </summary>
        [DataMember]
        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}