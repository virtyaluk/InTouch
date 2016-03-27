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
    /// An <see cref="WallGetCommentsParam"/> class describes a <see cref="WallMethods.GetComments"/> method params.
    /// </summary>
    public class WallGetCommentsParam : BaseGetCommentsParams
    {
        /// <summary>
        /// Post ID. 
        /// </summary>
        [MethodParam(Name = "post_id", IsRequired = true)]
        public int PostId { get; set; }

        /// <summary>
        /// Number of characters at which to truncate comments when previewed. By default, 90. Specify 0 if you do not want to truncate comments. 
        /// </summary>
        [MethodParam(Name = "preview_length")]
        public int PreviewLength { get; set; } = 0;
    }
}