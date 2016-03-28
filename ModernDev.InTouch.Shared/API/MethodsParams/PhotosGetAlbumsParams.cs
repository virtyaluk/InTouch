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
    /// An <see cref="PhotosGetAlbumsParams"/> class describes a <see cref="PhotosMethods.GetAlbums"/> method params.
    /// </summary>
    public class PhotosGetAlbumsParams : BasePhotosGetAlbumsParams
    {
        /// <summary>
        /// Album IDs.
        /// </summary>
        [MethodParam(Name = "album_ids")]
        public List<int> AlbumIds { get; set; }

        /// <summary>
        /// True — to return system albums with negative IDs
        /// </summary>
        [MethodParam(Name = "need_system")]
        public bool NeedSystem { get; set; }

        /// <summary>
        /// True - to return an additional <see cref="Album.ThumbSrc"/> field.
        /// </summary>
        [MethodParam(Name = "need_covers")]
        public bool NeedCovers { get; set; }
    }
}