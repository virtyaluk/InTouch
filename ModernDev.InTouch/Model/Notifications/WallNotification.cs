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
    /// A new post has been created on the user's wall.
    /// </summary>
    [DebuggerDisplay("WallNotification")]
    [DataContract]
    public class WallNotification : NotificationItem
    {
        /// <summary>
        /// A <see cref="Comment"/> object describing feedback.
        /// </summary>
        [DataMember]
        [JsonProperty("feedback")]
        public Post Feedback { get; set; }
    }
}