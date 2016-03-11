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
    /// An <see cref="AnswerVoters"/> class describes an information about users accepted the answer.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("AnswerVoters {AnswerId} {Users.Count}")]
    public class AnswerVoters
    {
        /// <summary>
        /// Answer Id.
        /// </summary>
        [DataMember]
        [JsonProperty("answer_id")]
        public int AnswerId { get; set; }

        /// <summary>
        /// Users accepted the answer.
        /// </summary>
        [DataMember]
        [JsonProperty("users")]
        public ItemsList<User> Users { get; set; } 
    }
}