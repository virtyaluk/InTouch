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
    public class BasePhotosGetAlbumsParams : MethodParamsGroup
    {
        /// <summary>
        /// ID of the user or community that owns the albums.
        /// </summary>
        [MethodParam(Name = "owner_id")]
        public int? OwnerId { get; set; }

        /// <summary>
        /// Offset needed to return a specific subset of albums.
        /// </summary>
        [MethodParam(Name = "offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Number of albums to return.
        /// </summary>
        [MethodParam(Name = "count")]
        public int? Count { get; set; }

        /// <summary>
        /// True - to return photo sizes in a special format.
        /// </summary>
        [MethodParam(Name = "photo_sizes")]
        public bool PhotoSizes { get; set; }
    }
}