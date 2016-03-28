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
    /// An <see cref="VideoCreateCommentParams"/> class describes a <see cref="VideoMethods.CreateComment"/> method params.
    /// </summary>
    public class VideoCreateCommentParams : BaseAddCommentParams
    {
        /// <summary>
        /// Video ID. 
        /// </summary>
        [MethodParam(Name = "video_id", IsRequired = true)]
        public int VideoId { get; set; }

        /// <summary>
        /// Comment text.
        /// </summary>
        [MethodParam(Name = "message")]
        public string Message { get; set; }
    }
}