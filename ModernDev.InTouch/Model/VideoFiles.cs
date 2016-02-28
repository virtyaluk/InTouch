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
    /// Link to the video file (if the video is placed on a VK server)
    /// or a link to an external site (if the video is integrated from another video hosting service).
    /// </summary>
    [DataContract]
    [DebuggerDisplay("VideoFiles")]
    public partial class VideoFiles
    {
        [DataMember]
        [JsonProperty("mp4_240")]
        public string Vid240 { get; set; }

        [DataMember]
        [JsonProperty("mp4_360")]
        public string Vid360 { get; set; }

        [DataMember]
        [JsonProperty("mp4_480")]
        public string Vid480 { get; set; }

        [DataMember]
        [JsonProperty("mp4_720")]
        public string Vid720 { get; set; }

        [DataMember]
        [JsonProperty("mp4_1080")]
        public string Vid1080 { get; set; }

        [DataMember]
        [JsonProperty("external")]
        public string External { get; set; }
    }
}