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
    /// A <see cref="VideoGetCommentsParams"/> class describes a <see cref="VideoMethods.GetComments"/> method params.
    /// </summary>
    public class VideoGetCommentsParams : BaseGetCommentsParams
    {
        /// <summary>
        /// Video ID. 
        /// </summary>
        [MethodParam(Name = "video_id", IsRequired = true)]
        public int VideoId { get; set; }
    }
}