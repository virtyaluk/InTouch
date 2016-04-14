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
    /// A <see cref="Doc"/> class describes a document.
    /// </summary>
    [DebuggerDisplay("Doc {Title}")]
    [DataContract]
    [APIVersion(Version = 5.45)]
    public class Doc : IMediaAttachment
    {
        #region Properties

        public string Type { get; } = "Doc";

        /// <summary>
        /// Document ID. 
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// ID of the user who uploaded the document.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Document title.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Document size (in bytes).
        /// </summary>
        [DataMember]
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// Document extension. 
        /// </summary>
        [DataMember]
        [JsonProperty("ext")]
        public string Ext { get; set; }

        /// <summary>
        /// Document URL for uploading. 
        /// </summary>
        [DataMember]
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// URL of the 100x75px image (if the file is graphical). 
        /// </summary>
        [DataMember]
        [JsonProperty("photo_100")]
        public string Photo100 { get; set; }

        /// <summary>
        /// URL of the 130x100px image (if the file is graphical). 
        /// </summary>
        [DataMember]
        [JsonProperty("photo_130")]
        public string Photo130 { get; set; }

        #region Extra properties

        /// <summary>
        /// The key to access the content.
        /// </summary>
        [DataMember]
        [JsonProperty("access_key ")]
        public string AccessKey { get; set; }

        [DataMember]
        [JsonProperty("preview")]
        public Preview Preview { get; set; }

        #endregion

        #endregion
    }
}
