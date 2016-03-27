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

using System.Collections.Generic;

namespace ModernDev.InTouch
{
    public class WallPostEditParams : MethodParamsGroup
    {
        /// <summary>
        /// User ID or community ID. Use a negative value to designate a community ID. 
        /// </summary>
        [MethodParam(Name = "owner_id")]
        public int? OwnerId { get; set; }

        /// <summary>
        /// True — post will be available to friends only; False — post will be available to all users(default).
        /// </summary>
        [MethodParam(Name = "friends_only")]
        public bool FriendsOnly { get; set; }

        /// <summary>
        /// (Required if attachments is not set.) Text of the post.
        /// </summary>
        [MethodParam(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// (Required if message is not set.) List of objects attached to the post.
        /// </summary>
        [MethodParam(Name = "attachments")]
        public List<string> Attachments { get; set; }

        /// <summary>
        /// (Required if message is not set.) List of objects attached to the post.
        /// </summary>
        public List<IMediaAttachment> Attachments2
        {
            set { Attachments = value?.GetPostAttachments(); }
        }

        /// <summary>
        /// List of services or websites the update will be exported to, if the user has so requested. Sample values: twitter, facebook. 
        /// </summary>
        [MethodParam(Name = "services")]
        public List<string> Services { get; set; }

        /// <summary>
        /// Only for posts in communities with <see cref="WallPostParams.FromGroup"/> set to True: True — post will be signed with the name of the posting user; False — post will not be signed(default).
        /// </summary>
        [MethodParam(Name = "signed")]
        public bool Signed { get; set; }

        /// <summary>
        /// Publication date (in Unix time). If used, posting will be delayed until the set time. 
        /// </summary>
        [MethodParam(Name = "publish_date")]
        public int? PublishDate { get; set; }

        /// <summary>
        /// Geographical latitude of a check-in, in degrees (from -90 to 90). 
        /// </summary>
        [MethodParam(Name = "lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Geographical longitude of a check-in, in degrees (from -180 to 180). 
        /// </summary>
        [MethodParam(Name = "long")]
        public double Longitude { get; set; }

        /// <summary>
        /// ID of the location where the user was tagged.
        /// </summary>
        [MethodParam(Name = "place_id")]
        public int? PlaceId { get; set; }
    }
}