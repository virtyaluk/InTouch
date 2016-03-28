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
    /// An <see cref="PhotosCreateAlbumParams"/> class describes a <see cref="PhotosMethods.CreateAlbum"/> method params.
    /// </summary>
    public class PhotosCreateAlbumParams : BasePhotosCreateEditAlbumParams
    {
        /// <summary>
        /// ID of the community in which the album will be created. 
        /// </summary>
        [MethodParam(Name = "group_id")]
        public int? GroupId { get; set; }
    }
}