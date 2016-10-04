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
    /// An <see cref="MessagesGetDialogsParams"/> class describes a <see cref="MessagesMethods.GetDialogs"/> method params.
    /// </summary>
    public class MessagesGetDialogsParams : MethodParamsGroup
    {
        /// <summary>
        /// Offset needed to return a specific subset of messages. 
        /// </summary>
        [MethodParam(Name = "offset")]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// Number of messages to return. 
        /// </summary>
        [MethodParam(Name = "count")]
        public int Count { get; set; } = 20;

        /// <summary>
        /// ID of the message from what to return dialogs.
        /// </summary>
        [MethodParam(Name = "start_message_id")]
        public int StartMessageId { get; set; }

        /// <summary>
        /// Number of characters after which to truncate a previewed message. To preview the full message, specify 0.
        /// </summary>
        [MethodParam(Name = "preview_length")]
        public int PreviewLength { get; set; } = 0;

        /// <summary>
        /// True - return unread messages only. 
        /// </summary>
        [MethodParam(Name = "unread")]
        public bool Unread { get; set; }

        /// <summary>
        /// True - return marked important messages only.
        /// </summary>
        [MethodParam(Name = "important")]
        public bool Important { get; set; }

        /// <summary>
        /// True - return unanswered messages only.
        /// </summary>
        [MethodParam(Name = "unanswered")]
        public bool Unanswered { get; set; }
    }
}