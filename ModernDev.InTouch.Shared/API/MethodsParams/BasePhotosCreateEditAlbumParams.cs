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
    public class BasePhotosCreateEditAlbumParams : MethodParamsGroup
    {
        /// <summary>
        /// Album title. 
        /// </summary>
        [MethodParam(Name = "title", IsRequired = true)]
        public string Title { get; set; }

        /// <summary>
        /// Album description.
        /// </summary>
        [MethodParam(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Privacy settings for album viewing.
        /// </summary>
        [MethodParam(Name = "privacy_view")]
        public List<string> PrivacyView { get; set; }

        /// <summary>
        /// Privacy settings for album commenting.
        /// </summary>
        [MethodParam(Name = "privacy_comment")]
        public List<string> PrivacyComment { get; set; }

        /// <summary>
        /// True - everyone can upload photos to the album; False - only admin can upload photos to the album.
        /// </summary>
        [MethodParam(Name = "upload_by_admins_only")]
        public bool UploadByAdminsOnly { get; set; }

        /// <summary>
        /// True - commenting disabled; False - commenting enabled.
        /// </summary>
        [MethodParam(Name = "comments_disabled")]
        public bool CommentsDisabled { get; set; }
    }
}