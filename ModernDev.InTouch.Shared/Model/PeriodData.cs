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
    /// Describes the statistic for a certain period.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("PeriodData")]
    public class PeriodData
    {
        [DataMember]
        [JsonProperty("value")]
        public string Value { get; set; }

        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("visitors")]
        public int Visitors { get; set; }

        [DataMember]
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}