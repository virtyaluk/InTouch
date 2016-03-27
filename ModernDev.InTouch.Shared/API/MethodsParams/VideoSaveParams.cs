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
    /// A <see cref="VideoSaveParams"/> class describes a <see cref="VideoMethods.Save"/> method params.
    /// </summary>
    public class VideoSaveParams : MethodParamsGroup
    {
        /// <summary>
        /// Name of the video.
        /// </summary>
        [MethodParam(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the video.
        /// </summary>
        [MethodParam(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// True - to designate the video as private (send it via a private message); the video will not appear on the user's video list and will not be available by ID for other users;
        /// False — not to designate the video as private.
        /// </summary>
        [MethodParam(Name = "is_private")]
        public bool IsPrivate { get; set; }

        /// <summary>
        /// True - to post the saved video on a user's wall;
        /// False — not to post the saved video on a user's wall.
        /// </summary>
        [MethodParam(Name = "wallpost")]
        public bool PublishToWall { get; set; }

        /// <summary>
        /// URL for embedding the video from an external website.
        /// </summary>
        [MethodParam(Name = "link")]
        public string Link { get; set; }

        /// <summary>
        /// ID of the community in which the video will be saved. By default, the current user's page. 
        /// </summary>
        [MethodParam(Name = "group_id")]
        public int? GroupId { get; set; }

        /// <summary>
        /// ID of the album to which the saved video will be added. 
        /// </summary>
        [MethodParam(Name = "album_id")]
        public int? AlbumId { get; set; }

        /// <summary>
        /// View privacy settings in special format.
        /// </summary>
        [MethodParam(Name = "privacy_view")]
        public List<string> PrivacyView { get; set; }

        /// <summary>
        /// Commenting privacy settings in special format.
        /// </summary>
        [MethodParam(Name = "privacy_comment")]
        public List<string> PrivacyComment { get; set; }

        /// <summary>
        /// True - to disable video commenting.
        /// </summary>
        [MethodParam(Name = "no_comments")]
        public bool NoComments { get; set; }

        /// <summary>
        /// True - to repeat the playback of the video; False — to play the video once.
        /// </summary>
        [MethodParam(Name = "repeat")]
        public bool Repeat { get; set; }
    }
}