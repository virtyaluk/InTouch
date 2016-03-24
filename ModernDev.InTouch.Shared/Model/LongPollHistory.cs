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

using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Returns the updates history from user's dialogs.
    /// </summary>
    [DebuggerDisplay("LongPollHistory")]
    [DataContract]
    public class LongPollHistory
    {
        [DataMember]
        [JsonProperty("new_pts")]
        public int NewPTS { get; set; }

        /// <summary>
        /// List of users profiles.
        /// </summary>
        [DataMember]
        [JsonProperty("profiles")]
        public List<User> Profiles { get; set; }

        /// <summary>
        /// The <see cref="Message"/> objects that has been included in updates with the code 4.
        /// </summary>
        [DataMember]
        [JsonProperty("messages")]
        public ItemsList<Message> Messages { get; set; }

        /// <summary>
        /// Updates list.
        /// </summary>
        [DataMember]
        [JsonProperty("history")]
        public List<List<string>> History { get; set; }   
    }
}