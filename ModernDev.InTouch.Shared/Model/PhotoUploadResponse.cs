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
    [DebuggerDisplay("PhotoUploadResponse {Server}")]
    [DataContract]
    public class PhotoUploadResponse : UploadResponse
    {
        /// <summary>
        /// Photo data.
        /// </summary>
        [DataMember]
        [JsonProperty("photo")]
        public string Photo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("mid")]
        public int MId { get; set; }

        /// <summary>
        /// Message code.
        /// </summary>
        [DataMember]
        [JsonProperty("message_code")]
        public int MessageCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("profile_aid")]
        public int ProfileAId { get; set; }
    }
}