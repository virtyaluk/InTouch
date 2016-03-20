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
    /// A new post that mentions the user has been posted on someone else's wall.
    /// </summary>
    [DebuggerDisplay("MentionNotification")]
    [DataContract]
    public class MentionNotification : NotificationItem
    {
        /// <summary>
        /// A <see cref="Post"/> object describing feedback.
        /// </summary>
        [DataMember]
        [JsonProperty("feedback")]
        public Post Feedback { get; set; }
    }
}