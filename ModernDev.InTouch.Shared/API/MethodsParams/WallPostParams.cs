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

using ModernDev.InTouch.Helpers;

namespace ModernDev.InTouch
{
    /// <summary>
    /// An <see cref="WallPostParams"/> class describes a <see cref="WallMethods.Post"/> method params.
    /// </summary>
    public class WallPostParams : WallPostEditParams
    {
        /// <summary>
        /// For a community: True — post will be published by the community; False — post will be published by the user(default).
        /// </summary>
        [MethodParam(Name = "from_group")]
        public bool FromGroup { get; set; }

        /// <summary>
        /// Post ID. Used for publishing of scheduled and suggested posts. 
        /// </summary>
        [MethodParam(Name = "post_id")]
        public int? PostId { get; set; }

        /// <summary>
        /// A unique identifier for the prevention of re-sending the same posts.
        /// </summary>
        [MethodParam(Name = "guid")]
        public string GUID { get; set; } = Utils.RandomString(10);
    }
}