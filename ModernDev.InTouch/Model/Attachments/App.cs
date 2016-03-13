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
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// An <see cref="App"/> class represents an information about attached app.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("App {Name}")]
    [APIVersion(Version = 5.45)]
    public class App : IMediaAttachment
    {
        /// <summary>
        /// App Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// App name.
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// URL of image with maximum size 130x130px.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_130")]
        public string Photo130 { get; set; }

        /// <summary>
        /// URL of image with maximum size 604x604px.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_604")]
        public string Photo604 { get; set; }

        /// <summary>
        /// Id of the user or community that owns the app.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }
    }
}