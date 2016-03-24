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
    /// A <see cref="PostedPhoto"/> represents an information about attached photo that was uploaded from user's computer.
    /// </summary>
    [DebuggerDisplay("PostedPhoto {Id}_{OwnerId}")]
    [DataContract]
    public class PostedPhoto : IMediaAttachment
    {
        /// <summary>
        /// PostedPhoto Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Id of the user or community that owns the graffiti.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// URL of image with maximum size 160x160px.
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
    }
}
