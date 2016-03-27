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
    /// An <see cref="WallAddCommentParams"/> class describes a <see cref="WallMethods.AddComment"/> method params.
    /// </summary>
    public class WallAddCommentParams : BaseAddCommentParams
    {
        /// <summary>
        /// Post ID.
        /// </summary>
        [MethodParam(Name = "post_id", IsRequired = true)]
        public int PostId { get; set; }

        /// <summary>
        /// (Required if attachments is not set.) Text of the comment. 
        /// </summary>
        [MethodParam(Name = "text")]
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MethodParam(Name = "ref")]
        public string Ref { get; set; }
    }
}