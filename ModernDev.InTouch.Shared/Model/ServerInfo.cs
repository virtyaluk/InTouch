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
    /// A <see cref="ServerInfo"/> class describes an info about uploading server.
    /// </summary>
    [DebuggerDisplay("ServerInfo")]
    [DataContract]
    public class ServerInfo
    {
        /// <summary>
        /// URL of the uploading server.
        /// </summary>
        [DataMember]
        [JsonProperty("upload_url")]
        public string UploadUrl { get; set; }
    }
}