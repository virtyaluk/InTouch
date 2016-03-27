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
    /// A <see cref="VideoReorderVideosParams"/> class describes a <see cref="VideoMethods.ReorderVideos"/> method params.
    /// </summary>
    public class VideoReorderVideosParams : MethodParamsGroup
    {
        /// <summary>
        /// ID of the user or community that owns the album with videos. 
        /// </summary>
        [MethodParam(Name = "target_id")]
        public int TargetId { get; set; }

        /// <summary>
        /// ID of the video album.
        /// </summary>
        [MethodParam(Name = "album_id")]
        public int AlbumId { get; set; }

        /// <summary>
        /// ID of the user or community that owns the video.
        /// </summary>
        [MethodParam(Name = "owner_id", IsRequired = true)]
        public int OwnerId { get; set; }

        /// <summary>
        /// ID of the video.
        /// </summary>
        [MethodParam(Name = "video_id", IsRequired = true)]
        public int VideoId { get; set; }

        /// <summary>
        /// ID of the user or community that owns the video before which the video in question shall be placed.
        /// </summary>
        [MethodParam(Name = "before_owner_id")]
        public int BeforeOwnerId { get; set; }

        /// <summary>
        /// ID of the video before which the video in question shall be placed. 
        /// </summary>
        [MethodParam(Name = "before_video_id")]
        public int BeforeVideoId { get; set; }

        /// <summary>
        /// ID of the user or community that owns the video after which the photo in question shall be placed. 
        /// </summary>
        [MethodParam(Name = "after_owner_id")]
        public int AfterOwnerId { get; set; }

        /// <summary>
        /// ID of the video after which the photo in question shall be placed. 
        /// </summary>
        [MethodParam(Name = "after_video_id")]
        public int AfterVideoId { get; set; }
    }
}