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
    /// An <see cref="WallEditParams"/> class describes a <see cref="WallMethods.Edit"/> method params.
    /// </summary>
    public class WallEditParams : WallPostEditParams
    {
        /// <summary>
        /// Post ID. 
        /// </summary>
        [MethodParam(Name = "post_id", IsRequired = true)]
        public int PostId { get; set; }
    }
}