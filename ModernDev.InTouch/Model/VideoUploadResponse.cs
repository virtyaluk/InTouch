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
    /// Video upload server response.
    /// </summary>
    [DebuggerDisplay("VideoUploadResponse {VideoId}")]
    [DataContract]
    public class VideoUploadResponse : UploadResponse
    {
        #region Properties

        /// <summary>
        /// Video size.
        /// </summary>
        [DataMember]
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// Video ID.
        /// </summary>
        [DataMember]
        [JsonProperty("video_id")]
        public long VideoId { get; set; }

        #endregion

        #region Methods

        public Video GetVideo(VideoServerInfo videoServerInfo)
        {
            return new Video
            {
                Id = VideoId,
                OwnerId = videoServerInfo?.OwnerId ?? 0,
                Title = videoServerInfo?.Title,
                Description = videoServerInfo?.Description,
                AccessKey = videoServerInfo?.AccessKey
            };
        }

        #endregion
    }
}