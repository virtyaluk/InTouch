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
    /// A <see cref="BoardAddCommentParams"/> class describes a <see cref="BoardMethods.AddComment"/> method params.
    /// </summary>
    public class BoardAddCommentParams : BaseAddCommentParams
    {
        /// <summary>
        /// ID of the community that owns the discussion board. 
        /// </summary>
        [MethodParam(Name = "group_id", IsRequired = true)]
        public int GroupId { get; set; }

        /// <summary>
        /// ID of the topic to be commented on. 
        /// </summary>
        [MethodParam(Name = "topic_id", IsRequired = true)]
        public int TopicId { get; set; }

        /// <summary>
        /// (Required if attachments is not set.) Text of the comment. 
        /// </summary>
        [MethodParam(Name = "text")]
        public string Text { get; set; }
    }
}