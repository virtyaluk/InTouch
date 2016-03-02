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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using ModernDev.InTouch.API;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="Poll"/> class represents an information about a poll.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Poll {Question}")]
    [APIVersion(Version = 5.45)]
    public class Poll : IMediaAttachment
    {
        /// <summary>
        /// Poll Id to get more info about using <see cref="Polls.GetById"/> method.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Id of the user or community that owns the poll.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Date the poll was created.
        /// </summary>
        [DataMember]
        [JsonProperty("created")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Created { get; set; }

        /// <summary>
        /// The question asked in the vote.
        /// </summary>
        [DataMember]
        [JsonProperty("question")]
        public string Question { get; set; }

        /// <summary>
        /// The number of votes has been done by the poll.
        /// </summary>
        [DataMember]
        [JsonProperty("votes")]
        public int Votes { get; set; }

        /// <summary>
        /// Id of the answer chosen by the current user.
        /// </summary>
        [DataMember]
        [JsonProperty("answer_id")]
        public int AnswerId { get; set; }

        /// <summary>
        /// The List of <see cref="Answer"/> contains information about the answers.
        /// </summary>
        [DataMember]
        [JsonProperty("answers")]
        public List<Answer> Answers { get; set; } 
    }
}