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
    /// User contact
    /// </summary>
    [DebuggerDisplay("UserContact")]
    [DataContract]
    public class UserContact
    {
        /// <summary>
        /// A contact where a user was found.
        /// </summary>
        [DataMember]
        [JsonProperty("contact")]
        public string Contact { get; set; }

        /// <summary>
        /// Whether the contact was imported by current user's friends or contacts.
        /// or
        /// Number of common friends with a current user.
        /// </summary>
        [DataMember]
        [JsonProperty("common_count")]
        public int CommonCount { get; set; }

        /// <summary>
        /// Whether the friend request has already been sent or the user is already a friend.
        /// </summary>
        [DataMember]
        [JsonProperty("request_sent")]
        public bool RequestSent { get; set; }
    }
}