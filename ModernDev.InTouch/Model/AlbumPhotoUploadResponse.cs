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
    /// Album photo upload server response.
    /// </summary>
    [DebuggerDisplay("PhotoUploadResponse {AlbumId} {PhotosList}")]
    [DataContract]
    public class AlbumPhotoUploadResponse : UploadResponse
    {
        /// <summary>
        /// Photos list.
        /// </summary>
        [DataMember]
        [JsonProperty("photos_list")]
        public string PhotosList { get; set; }

        /// <summary>
        /// Album Id.
        /// </summary>
        [DataMember]
        [JsonProperty("aid")]
        public string AlbumId { get; set; }
    }
}