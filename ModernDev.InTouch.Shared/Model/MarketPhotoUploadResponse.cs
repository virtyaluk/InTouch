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
    /// Photo upload server response.
    /// </summary>
    [DebuggerDisplay("MarketPhotoUploadResponse {Server}")]
    [DataContract]
    public class MarketPhotoUploadResponse : PhotoUploadResponse
    {
        /// <summary>
        /// Group Id.
        /// </summary>
        [DataMember]
        [JsonProperty("gid")]
        public string GroupId { get; set; }

        /// <summary>
        /// Crop data.
        /// </summary>
        [DataMember]
        [JsonProperty("crop_data")]
        public string CropData { get; set; }

        /// <summary>
        /// Crop hash.
        /// </summary>
        [DataMember]
        [JsonProperty("crop_hash")]
        public string CropHash { get; set; }
    }
}