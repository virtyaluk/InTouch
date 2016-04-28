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
    /// An <see cref="Answer"/> class represents an information about poll answer.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Answer {Text}")]
    public class Answer
    {
        /// <summary>
        /// Answer Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Answer text.
        /// </summary>
        [DataMember]
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// The number of votes for the answer.
        /// </summary>
        [DataMember]
        [JsonProperty("votes")]
        public int Votes { get; set; }

        /// <summary>
        /// Answer rate.
        /// </summary>
        [DataMember]
        [JsonProperty("rate")]
        public double Rate { get; set; }
    }
}