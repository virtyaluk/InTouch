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
    /// A <see cref="BoardGetCommentsParams"/> class describes a <see cref="BoardMethods.GetComments"/> method params.
    /// </summary>
    public class BoardGetCommentsParams : BaseGetCommentsParams
    {
        /// <summary>
        /// ID of the community that owns the discussion board.
        /// </summary>
        [MethodParam(Name = "group_id", IsRequired = true)]
        public int GroupId { get; set; }

        /// <summary>
        /// Topic ID. 
        /// </summary>
        [MethodParam(Name = "topic_id", IsRequired = true)]
        public int TopicId { get; set; }
    }
}