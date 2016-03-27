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
    /// A <see cref="VideoEditParams"/> class describes a <see cref="VideoMethods.Edit"/> method params.
    /// </summary>
    public class VideoEditParams : MethodParamsGroup
    {
        /// <summary>
        /// ID of the user or community that owns the video.
        /// </summary>
        [MethodParam(Name= "owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Video ID. 
        /// </summary>
        [MethodParam(Name = "video_id", IsRequired = true)]
        public int VideoId { get; set; }

        /// <summary>
        /// New video title.
        /// </summary>
        [MethodParam(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// New video description.
        /// </summary>
        [MethodParam(Name = "desc")]
        public string Description { get; set; }

        /// <summary>
        /// Privacy settings in a special format. 
        /// Privacy setting is available for videos uploaded to own profile by user.
        /// </summary>
        [MethodParam(Name = "privacy_view")]
        public List<string> PrivacyView { get; set; }

        /// <summary>
        /// Privacy settings for comments in a special format.
        /// </summary>
        [MethodParam(Name = "privacy_comment")]
        public List<string> PrivacyComment { get; set; }

        /// <summary>
        /// Disable comments for the group video.
        /// </summary>
        [MethodParam(Name = "no_comments")]
        public bool NoComments { get; set; }

        /// <summary>
        /// True -  to repeat the playback of the video; False — to play the video once.
        /// </summary>
        [MethodParam(Name = "repeat")]
        public bool Repeat { get; set; }
    }
}