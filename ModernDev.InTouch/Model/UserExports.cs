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
    /// An <see cref="UserExports"/> class describes external services with export configured.
    /// </summary>
    [DebuggerDisplay("UserExports")]
    [DataContract]
    public class UserExports
    {
        [DataMember]
        [JsonProperty("facebook")]
        public string Facebook { get; set; }

        [DataMember]
        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        [DataMember]
        [JsonProperty("livejournal")]
        public string LiveJournal { get; set; }

        [DataMember]
        [JsonProperty("instagram")]
        public string Instagram { get; set; }
    }
}