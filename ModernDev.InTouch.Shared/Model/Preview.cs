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
    [DebuggerDisplay("Preview")]
    public class Preview
    {
        [DataMember]
        [JsonProperty("photo")]
        public Photo Photo { get; set; }

        [DataMember]
        [JsonProperty("video")]
        public VideoPreview Video { get; set; }
    }
}