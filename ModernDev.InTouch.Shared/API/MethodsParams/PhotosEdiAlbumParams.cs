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
    /// An <see cref="PhotosEdiAlbumParams"/> class describes a <see cref="PhotosMethods.EditAlbum"/> method params.
    /// </summary>
    public class PhotosEdiAlbumParams : BasePhotosCreateEditAlbumParams
    {
        /// <summary>
        /// ID of the photo album to be edited. 
        /// </summary>
        [MethodParam(Name = "album_id", IsRequired = true)]
        public int AlbumId { get; set; }

        /// <summary>
        /// ID of the user or community that owns the album.
        /// </summary>
        [MethodParam(Name = "owner_id")]
        public int OwnerId { get; set; }
    }
}