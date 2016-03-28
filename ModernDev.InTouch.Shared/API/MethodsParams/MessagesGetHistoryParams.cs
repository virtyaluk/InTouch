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
    /// An <see cref="MessagesGetHistoryParams"/> class describes a <see cref="MessagesMethods.GetHistory"/> method params.
    /// </summary>
    public class MessagesGetHistoryParams : MethodParamsGroup
    {
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
        /// ID of the user whose message history you want to return.
        /// </summary>
        [MethodParam(Name = "user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// Peer id:
        /// - user_id for user;
        /// - 2000000000 + chat_id for chat;
        /// - -group_id for groups
        /// </summary>
        [MethodParam(Name = "peer_id")]
        public int? PeerId { get; set; }

        /// <summary>
        /// Starting message ID from which to return history.
        /// </summary>
        [MethodParam(Name = "start_message_id")]
        public int? StartMessageId { get; set; }

        /// <summary>
        /// True - to return messages in chronological order. False - to return messages in reverse chronological order.
        /// </summary>
        [MethodParam(Name = "rev")]
        public bool ReverseOrder { get; set; }
    }
}