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
using ModernDev.InTouch.Helpers;

namespace ModernDev.InTouch
{
    public abstract class BaseAddCommentParams : MethodParamsGroup
    {
        /// <summary>
        /// User ID or community ID. Use a negative value to designate a community ID. 
        /// </summary>
        [MethodParam(Name = "owner_id")]
        public int? OwnerId { get; set; }

        /// <summary>
        /// True— to post the comment as from the community; False — (default) to post the comment as from the user.
        /// </summary>
        [MethodParam(Name = "from_group")]
        public bool FromGroup { get; set; }

        /// <summary>
        /// ID of comment to reply.
        /// </summary>
        [MethodParam(Name = "reply_to_comment")]
        public int? ReplyToComment { get; set; }
        /// <summary>
        /// (Required if message is not set.) List of objects attached to the comment.
        /// </summary>
        [MethodParam(Name = "attachments")]
        public List<string> Attachments { get; set; }

        /// <summary>
        /// (Required if message is not set.) List of objects attached to the comment.
        /// </summary>
        public List<IMediaAttachment> Attachments2
        {
            set { Attachments = value?.GetCommentAttachments(); }
        }

        /// <summary>
        /// Sticker Id.
        /// </summary>
        [MethodParam(Name = "sticker_id")]
        public int? StickerId { get; set; }

        /// <summary>
        /// A unique identifier for the prevention of re-sending the same comments.
        /// </summary>
        [MethodParam(Name = "guid")]
        public string GUID { get; set; } = Utils.RandomString(10);
    }
}