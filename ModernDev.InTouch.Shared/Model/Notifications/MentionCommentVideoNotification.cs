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
    /// A new comment that mentions the user has been published on the video.
    /// </summary>
    [DebuggerDisplay("MentionCommentVideoNotification")]
    [DataContract]
    public class MentionCommentVideoNotification : NotificationItem
    {
        /// <summary>
        /// A <see cref="Comment"/> object describing feedback.
        /// </summary>
        [DataMember]
        [JsonProperty("feedback")]
        public Comment Feedback { get; set; }

        /// <summary>
        /// An object describing a material owns feedback.
        /// </summary>
        [DataMember]
        [JsonProperty("parent")]
        public Video Parent { get; set; }
    }
}