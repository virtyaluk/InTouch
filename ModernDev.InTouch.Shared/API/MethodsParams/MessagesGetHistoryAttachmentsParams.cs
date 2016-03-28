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
    /// An <see cref="MessagesGetHistoryAttachmentsParams"/> class describes a <see cref="MessagesMethods.GetHistoryAttachments"/> method params.
    /// </summary>
    public class MessagesGetHistoryAttachmentsParams : MethodParamsGroup
    {
        /// <summary>
        /// Peer id:
        /// - user_id for user;
        /// - 2000000000 + chat_id for chat;
        /// - -group_id for groups
        /// </summary>
        [MethodParam(Name = "peer_id", IsRequired = true)]
        public int? PeerId { get; set; }

        /// <summary>
        /// Offset needed to return a specific subset of attachments.
        /// </summary>
        [MethodParam(Name = "start_from")]
        public string StartFrom { get; set; }

        /// <summary>
        /// Number of objects to return. 
        /// </summary>
        [MethodParam(Name = "count", Extra = new[] {0, 200})]
        public int Count { get; set; } = 30;

        /// <summary>
        /// True — to return photo sizes in a special format.
        /// </summary>
        [MethodParam(Name = "photo_sizes")]
        public bool PhotoSizes { get; set; }

        /// <summary>
        /// Type of media files to return.
        /// </summary>
        [MethodParam(Name = "media_type")]
        public AttachmentsTypes MediaType { get; set; } = AttachmentsTypes.Photo;

        /// <summary>
        /// Profiles fields to return;
        /// </summary>
        [MethodParam(Name = "fields")]
        public List<string> Fields { get; set; }
    }
}