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
    /// An <see cref="LikesGetListParams"/> class describes a <see cref="LikesMethods.GetList"/> method params.
    /// </summary>
    public class LikesGetListParams : MethodParamsGroup
    {
        /// <summary>
        /// Object type
        /// </summary>
        [MethodParam(Name = "type", IsRequired = true)]
        public MediaTypes Type { get; set; }

        /// <summary>
        /// ID of the user, community, or application that owns the object. If the <see cref="Type"/> parameter is set as <see cref="MediaTypes.Sitepage"/>, the application ID is passed as <see cref="OwnerId"/>. Use negative value for a community id. If the type parameter is not set, the <see cref="OwnerId"/> is assumed to be either the current user or the same application ID as if the type parameter was set to sitepage. 
        /// </summary>
        [MethodParam(Name = "owner_id")]
        public int? OwnerId { get; set; }

        /// <summary>
        /// Object ID.
        /// </summary>
        [MethodParam(Name = "item_id", IsRequired = true)]
        public int ItemId { get; set; }

        /// <summary>
        /// URL of the page where the Like widget is installed. Used instead of the <see cref="ItemId"/> parameter. 
        /// </summary>
        [MethodParam(Name = "page_url")]
        public string PageUrl { get; set; }

        /// <summary>
        /// Specifies which users are returned: True — to return only the current user's friends ; False — to return all users(default).
        /// </summary>
        [MethodParam(Name = "friends_only")]
        public bool FriendsOnly { get; set; }

        /// <summary>
        /// Specifies whether extended information will be returned.
        /// </summary>
        [MethodParam(Name = "extended")]
        public bool Extended { get; } = true;

        /// <summary>
        /// Offset needed to select a specific subset of users.
        /// </summary>
        [MethodParam(Name = "offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Number of user IDs to return (maximum 1000).
        /// </summary>
        [MethodParam(Name = "count", Extra = new[] {0, 1000})]
        public int Count { get; set; } = 100;

        /// <summary>
        /// Do not count the user.
        /// </summary>
        [MethodParam(Name = "skip_own")]
        public bool SkipOwn { get; set; }

        /// <summary>
        /// Filters to apply.
        /// </summary>
        [MethodParam(Name = "filter")]
        public LikesListFilterTypes Filter { get; set; } = LikesListFilterTypes.Likes;
    }
}