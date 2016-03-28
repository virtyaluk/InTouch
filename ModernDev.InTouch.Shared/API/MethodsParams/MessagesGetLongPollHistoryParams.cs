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

namespace ModernDev.InTouch
{
    /// <summary>
    /// An <see cref="MessagesGetLongPollHistoryParams"/> class describes a <see cref="MessagesMethods.GetLongPollHistory"/> method params.
    /// </summary>
    public class MessagesGetLongPollHistoryParams : MethodParamsGroup
    {
        /// <summary>
        /// Last value of the <see cref="LongPollServerData.TS"/> property returned from the Long Poll server or by using <see cref="MessagesMethods.GetLongPollServer"/> method.
        /// </summary>
        [MethodParam(Name = "ts")]
        public int? TS { get; set; }

        /// <summary>
        /// The value of the <see cref="LongPollServerData.PTS"/> property returned from the Long Poll server or by using <see cref="MessagesMethods.GetLongPollServer"/> method.
        /// </summary>
        [MethodParam(Name = "pts")]
        public int? PTS { get; set; }

        /// <summary>
        /// Number of characters after which to truncate a previewed message. To preview the full message, specify 0.
        /// </summary>
        [MethodParam(Name = "preview_length")]
        public int PreviewLength { get; set; } = 0;

        /// <summary>
        /// True to return history from online users only.
        /// </summary>
        [MethodParam(Name = "onlines")]
        public bool Onlines { get; set; }

        /// <summary>
        /// Additional profile fields to return.
        /// </summary>
        [MethodParam(Name = "fields")]
        public List<UserProfileFields> Fields { get; set; }

        /// <summary>
        /// Updates limit.
        /// </summary>
        [MethodParam(Name = "events_limit", Extra = new[] {0, 1000})]
        public int EventsLimit { get; set; } = 1000;

        /// <summary>
        /// The number of messages to return.
        /// </summary>
        [MethodParam(Name = "msgs_limit", Extra = new[] {0, 200})]
        public int MessagesLimit { get; set; } = 200;

        /// <summary>
        /// Maximum ID of the message among existing ones in the local copy. Both messages received with API methods (for example, <see cref="MessagesMethods.GetDialogs"/>, <see cref="MessagesMethods.GetHistory"/>), and data received from a Long Poll server (events with code 4) are taken into account. 
        /// </summary>
        [MethodParam(Name = "max_msg_id")]
        public int? MaxMessageId { get; set; }
    }
}