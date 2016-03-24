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
    /// An <see cref="PhotosGetParams"/> class describes a <see cref="PhotosMethods.Get"/> method params.
    /// </summary>
    public class PhotosGetParams : BasePhotosGetAlbumsParams
    {
        /// <summary>
        /// Photo album ID. To return information about photos from service albums, use the following string values: profile, wall, saved. 
        /// </summary>
        [MethodParam(Name = "album_id")]
        public string AlbumId { get; set; }

        /// <summary>
        /// Photo IDs. 
        /// </summary>
        [MethodParam(Name = "photo_ids")]
        public List<int> PhotoIds { get; set; }

        /// <summary>
        /// Sort order: True — reverse chronological; False — chronological.
        /// </summary>
        [MethodParam(Name = "rev")]
        public bool InReverseOrder { get; set; }

        /// <summary>
        /// True - to return additional <see cref="Photo.Likes"/>, <see cref="Photo.Comments"/>, and <see cref="Photo.Tags"/> fields.
        /// </summary>
        [MethodParam(Name = "extended")]
        public bool Extended { get; set; }

        /// <summary>
        /// Type of feed obtained in <see cref="Feed"/> field of the method.
        /// </summary>
        [MethodParam(Name = "feed_type")]
        public FeedTypes? FeedType { get; set; } = null;

        /// <summary>
        /// <c>Unixtime</c>, that can be obtained with <see cref="NewsfeedMethods.Get"/> method in date field to get all photos uploaded by the user on a specific day, or photos the user has been tagged on. Also, uid parameter of the user the event happened with shall be specified. 
        /// </summary>
        [MethodParam(Name = "feed")]
        public int Feed { get; set; }
    }
}