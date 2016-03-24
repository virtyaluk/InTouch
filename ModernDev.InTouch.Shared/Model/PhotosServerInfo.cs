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
    /// Photos server info.
    /// </summary>
    [DebuggerDisplay("PhotosServerInfo {AlbumId} {UserId}")]
    [DataContract]
    public class PhotosServerInfo : ServerInfo
    {
        /// <summary>
        /// Id of the user who uploads the photo.
        /// </summary>
        [DataMember]
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Album Id, in which the photo will be uploaded.
        /// </summary>
        [DataMember]
        [JsonProperty("album_id")]
        public int AlbumId { get; set; }
    }
}