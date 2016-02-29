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
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="Note"/> object describes a note.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Note {Title}")]
    public class Note
    {
        /// <summary>
        /// Note ID.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Note owner ID.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Note title.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Note text.
        /// </summary>
        [DataMember]
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Date when the note was created.
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Number of comments.
        /// </summary>
        [DataMember]
        [JsonProperty("comments")]
        public int Comments { get; set; }

        /// <summary>
        /// Number of read comments (only if <see cref="OwnerId"/> is the current user).
        /// </summary>
        [DataMember]
        [JsonProperty("read_comments")]
        public int ReadComments { get; set; }

        /// <summary>
        /// Address for page display.
        /// </summary>
        [DataMember]
        [JsonProperty("view_url")]
        public string ViewUrl { get; set; }
    }
}
