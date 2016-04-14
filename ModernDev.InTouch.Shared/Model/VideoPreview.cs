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
    [DataContract]
    [DebuggerDisplay("VideoPreview")]
    public class VideoPreview
    {
        [DataMember]
        [JsonProperty("src")]
        public string Src { get; set; }

        [DataMember]
        [JsonProperty("width")]
        public int Width { get; set; }

        [DataMember]
        [JsonProperty("height")]
        public int Height { get; set; }

        [DataMember]
        [JsonProperty("file_size")]
        public int FileSize { get; set; }
    }
}