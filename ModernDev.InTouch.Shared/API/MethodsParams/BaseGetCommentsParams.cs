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
    public abstract class BaseGetCommentsParams : MethodParamsGroup
    {
        /// <summary>
        /// User ID or community ID. Use a negative value to designate a community ID. 
        /// </summary>
        [MethodParam(Name = "owner_id")]
        public int? OwnerId { get; set; }

        /// <summary>
        /// True - to return the likes field; False — not to return the likes field(default).
        /// </summary>
        [MethodParam(Name = "need_likes")]
        public bool NeedLikes { get; set; }

        /// <summary>
        /// Comment Id, from which you want to return a list of.
        /// </summary>
        [MethodParam(Name = "start_comment_id")]
        public int? StartCommentId { get; set; }

        /// <summary>
        /// Offset needed to return a specific subset of comments.
        /// </summary>
        [MethodParam(Name = "offset")]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// Number of comments to return (maximum 100).
        /// </summary>
        [MethodParam(Name = "count", Extra = new[] { 0, 100 })]
        public int Count { get; set; } = 10;

        /// <summary>
        /// Sort order.
        /// </summary>
        [MethodParam(Name = "sort")]
        public SortOrder Sort { get; set; } = SortOrder.Descending;

        /// <summary>
        /// Lists of properties profiles, groups additionally be returned.
        /// </summary>
        [MethodParam(Name = "extended")]
        public bool Extended { get; set; }
    }
}