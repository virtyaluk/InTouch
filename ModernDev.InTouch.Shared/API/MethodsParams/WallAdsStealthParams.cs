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
using ModernDev.InTouch.Helpers;

namespace ModernDev.InTouch
{
    public class WallAdsStealthParams : MethodParamsGroup
    {
        /// <summary>
        /// Wall owner ID (community ID should be passed with minus).
        /// </summary>
        [MethodParam(Name = "owner_id")]
        public int OwnerId { get; set; }

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
        /// True — post will be signed with the name of the posting user; False — post will not be signed(default).
        /// </summary>
        [MethodParam(Name = "signed")]
        public bool IsSigned { get;set; }

        /// <summary>
        /// Geographical latitude of a check-in, in degrees (from -90 to 90).
        /// </summary>
        [MethodParam(Name = "lat")]
        public double? Latitude { get; set; }

        /// <summary>
        /// Geographical longitude of a check-in, in degrees (from -180 to 180).
        /// </summary>
        [MethodParam(Name = "long")]
        public double? Longitude { get; set; }

        /// <summary>
        /// Location ID.
        /// </summary>
        [MethodParam(Name = "place_id")]
        public int? PlaceId { get; set; }

        /// <summary>
        /// Unique identifier to avoid duplication the same post.
        /// </summary>
        [MethodParam(Name = "guid")]
        public string GUID { get; } = Utils.RandomString(10);

        /// <summary>
        /// Snippet button Id.
        /// </summary>
        [MethodParam(Name = "link_button")]
        public string LinkButton { get; set; }

        /// <summary>
        /// Snippet button title.
        /// </summary>
        [MethodParam(Name = "link_title")]
        public string LinkTitle { get; set; }

        /// <summary>
        /// Snippet button image url.
        /// </summary>
        [MethodParam(Name = "link_image")]
        public string LinkImage { get; set; }
    }
}