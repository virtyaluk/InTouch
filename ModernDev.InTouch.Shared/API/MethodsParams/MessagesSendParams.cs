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
using System.Collections.Generic;
using System.Linq;

namespace ModernDev.InTouch
{
    /// <summary>
    /// An <see cref="MessagesSendParams"/> class describes a <see cref="MessagesMethods.Send"/> method params.
    /// </summary>
    public class MessagesSendParams : MethodParamsGroup
    {
        /// <summary>
        /// User ID (by default — current user).
        /// </summary>
        [MethodParam(Name = "user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// A unique identifier for the prevention of re-sending the same message. It is saved with the message and is available in the message history.
        /// </summary>
        [MethodParam(Name = "random_id")]
        public int RandomId { get; } = new Random().Next(10000, 99999);

        /// <summary>
        /// Peer id:
        /// - user_id for user;
        /// - 2000000000 + chat_id for chat;
        /// - -group_id for groups
        /// </summary>
        [MethodParam(Name = "peer_id")]
        public int? PeerId { get; set; }

        /// <summary>
        /// User's short address (for example, virtyaluk).
        /// </summary>
        [MethodParam(Name = "domain")]
        public string Domain { get; set; }

        /// <summary>
        /// ID of conversation the message will relate to.
        /// </summary>
        [MethodParam(Name = "chat_id")]
        public int? ChatId { get; set; }

        /// <summary>
        /// IDs of message recipients (if new conversation shall be started).
        /// </summary>
        [MethodParam(Name = "user_ids")]
        public List<int> UserIds { get; set; }

        /// <summary>
        /// Geographical latitude of a check-in, in degrees (from -90 to 90). 
        /// </summary>
        [MethodParam(Name = "lat")]
        public double? Latitude { get; set; }

        /// <summary>
        /// Geographical longitude of a check-in, in degrees (from -180 to 180). 
        /// </summary>
        [MethodParam(Name = "long")]
        public double? Longitude { get; set; }

        /// <summary>
        /// (Required if attachments is not set.) Text of the message. 
        /// </summary>
        [MethodParam(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// (Required if message is not set.) List of objects attached to the message.
        /// </summary>
        [MethodParam(Name = "attachment")]
        public List<string> Attachments { get; set; }

        /// <summary>
        /// (Required if message is not set.) List of objects attached to the message.
        /// </summary>
        public List<IMediaAttachment> Attachments2
        {
            set { Attachments = value?.GetMessageAttachments(); }
        }

        /// <summary>
        /// ID of forwarded messages. Listed messages of the sender will be shown in the message body at the recipient's. 
        /// </summary>
        [MethodParam(Name = "forward_messages")]
        public List<int> ForwardMessages { get; set; }

        /// <summary>
        /// Messages to attach to the message. Listed messages of the sender will be shown in the message body at the recipient's. 
        /// </summary>
        public List<Message> ForwardMessages2
        {
            set { ForwardMessages = value?.Select(msg => msg.Id).ToList(); }
        }

        /// <summary>
        /// Sticker id. 
        /// </summary>
        [MethodParam(Name = "sticker_id")]
        public int? StickerId { get; set; }

        /// <summary>
        /// Whether the message is notification. Used when sending messages from group.
        /// </summary>
        [MethodParam(Name = "notification")]
        public bool IsNotification { get; set; }
    }
}