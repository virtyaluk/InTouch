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
    /// Owner photo.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("OwnerPhoto {PostId}")]
    public class OwnerPhoto
    {
        /// <summary>
        /// Photo hash.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_hash")]
        public string PhotoHash { get; set; }

        /// <summary>
        /// Url of the photo.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_src")]
        public string PhotoSrc { get; set; }

        /// <summary>
        /// Url of a big copy of the photo.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_src_big")]
        public string PhotoSrcBig { get; set; }

        /// <summary>
        /// Url of a small copy of the photo.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_src_small")]
        public string PhotoSrcSmall { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("saved")]
        public bool Saved { get; set; }

        /// <summary>
        /// Id of the post on the users wall with the photo.
        /// </summary>
        [DataMember]
        [JsonProperty("post_id")]
        public int PostId { get; set; }
    }
}