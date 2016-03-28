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

namespace ModernDev.InTouch
{
    /// <summary>
    /// An <see cref="MessagesGetParams"/> class describes a <see cref="MessagesMethods.Get"/> method params.
    /// </summary>
    public class MessagesGetParams : MethodParamsGroup
    {
        /// <summary>
        /// True -to return outgoing messages; False — to return incoming messages(default).
        /// </summary>
        [MethodParam(Name = "out")]
        public bool Out { get; set; }

        /// <summary>
        /// Offset needed to return a specific subset of messages.
        /// </summary>
        [MethodParam(Name = "offset")]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// Number of messages to return. 
        /// </summary>
        [MethodParam(Name = "count", Extra = new[] {0, 200})]
        public int Count { get; set; } = 20;

        /// <summary>
        /// Maximum time since a message was sent, in seconds. To return messages without a time limitation, set as 0. 
        /// </summary>
        [MethodParam(Name = "time_offset")]
        public int TimeOffset { get; set; } = 0;

        /// <summary>
        /// Messages filter: 8 - to return important messages.
        /// </summary>
        [MethodParam(Name = "important")]
        public int OnlyImportant { get; set; } = 8;

        /// <summary>
        /// Number of characters after which to truncate a previewed message. To preview the full message, specify 0.
        /// </summary>
        [MethodParam(Name = "preview_length")]
        public int PreviewLength { get; set; }

        /// <summary>
        /// ID of the message received before the message that will be returned last (provided that no more than count messages were received before it; otherwise offset parameter shall be used). 
        /// </summary>
        [MethodParam(Name = "last_message_id")]
        public int LastMessageId { get; set; }
    }
}