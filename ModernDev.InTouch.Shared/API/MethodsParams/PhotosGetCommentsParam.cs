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
    /// An <see cref="PhotosGetCommentsParam"/> class describes a <see cref="PhotosMethods.GetComments"/> method params.
    /// </summary>
    public class PhotosGetCommentsParam : BaseGetCommentsParams
    {
        /// <summary>
        /// Photo ID. 
        /// </summary>
        [MethodParam(Name = "photo_id", IsRequired = true)]
        public int PhotoId { get; set; }

        /// <summary>
        /// Photo access key.
        /// </summary>
        [MethodParam(Name = "access_key")]
        public string AccessKey { get; set; }
    }
}