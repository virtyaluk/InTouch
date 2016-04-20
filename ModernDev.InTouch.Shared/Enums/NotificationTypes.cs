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

using System.Diagnostics;
using System.Runtime.Serialization;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Notification types.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("NotificationTypes")]
    public enum NotificationTypes
    {
        /// <summary>
        /// One or more followers of the user have appeared.
        /// </summary>
        [EnumMember(Value = "follow")]
        Follow,

        /// <summary>
        /// A friend request made by the user has been accepted.
        /// </summary>
        [EnumMember(Value = "friend_accepted")]
        FriendAccepted,

        /// <summary>
        /// A new post that mentions the user has been posted on someone else's wall.
        /// </summary>
        [EnumMember(Value = "mention")]
        Mention,

        /// <summary>
        /// A new comment that mentions the user has been posted.
        /// </summary>
        [EnumMember(Value = "mention_comments")]
        MentionComments,

        /// <summary>
        /// A new post has been created on the user's wall.
        /// </summary>
        [EnumMember(Value = "wall")]
        Wall,

        /// <summary>
        /// A post offered by the user has been published on the group's wall.
        /// </summary>
        [EnumMember(Value = "wall_publish")]
        WallPublish,

        /// <summary>
        /// A new comment has been added about the user's post.
        /// </summary>
        [EnumMember(Value = "comment_post")]
        CommentPost,

        /// <summary>
        /// A new comment has been added about the user's photo.
        /// </summary>
        [EnumMember(Value = "comment_photo")]
        CommentPhoto,

        /// <summary>
        /// A new comment has been added about the user's video.
        /// </summary>
        [EnumMember(Value = "comment_video")]
        CommentVideo,

        /// <summary>
        /// A new reply has been added about the user's comment.
        /// </summary>
        [EnumMember(Value = "reply_comment")]
        ReplyComment,

        /// <summary>
        /// A new reply has been added about the user's comment about a photo.
        /// </summary>
        [EnumMember(Value = "reply_comment_photo")]
        ReplyCommentPhoto,

        /// <summary>
        /// A new reply has been added about the user's comment about a video.
        /// </summary>
        [EnumMember(Value = "reply_comment_video")]
        ReplyCommentVideo,

        /// <summary>
        /// A new reply has been added about the user's comment about market item.
        /// </summary>
        [EnumMember(Value = "reply_comment_market")]
        ReplyCommentMarket,

        /// <summary>
        /// A new reply has been added about the user's topic.
        /// </summary>
        [EnumMember(Value = "reply_topic")]
        ReplyTopic,

        /// <summary>
        /// One or more Likes have been added to the user's post.
        /// </summary>
        [EnumMember(Value = "like_post")]
        LikePost,

        /// <summary>
        /// One or more Likes have been added to the user's comment.
        /// </summary>
        [EnumMember(Value = "like_comment")]
        LikeComment,

        /// <summary>
        /// One or more Likes have been added to the user's photo.
        /// </summary>
        [EnumMember(Value = "like_photo")]
        LikePhoto,

        /// <summary>
        /// One or more Likes have been added to the user's video.
        /// </summary>
        [EnumMember(Value = "like_video")]
        LikeVideo,

        /// <summary>
        /// One or more Likes have been added to the user's comment about a photo.
        /// </summary>
        [EnumMember(Value = "like_comment_photo")]
        LikeCommentPhoto,

        /// <summary>
        /// One or more Likes have been added to the user's comment about a video.
        /// </summary>
        [EnumMember(Value = "like_comment_video")]
        LikeCommentVideo,

        /// <summary>
        /// One or more Likes have been added to the user's comment about a topic.
        /// </summary>
        [EnumMember(Value = "like_comment_topic")]
        LikeCommentTopic,

        /// <summary>
        /// One or more users have copied the user's post.
        /// </summary>
        [EnumMember(Value = "copy_post")]
        CopyPost,

        /// <summary>
        /// 	One or more users have copied the user's photo.
        /// </summary>
        [EnumMember(Value = "copy_photo")]
        CopyPhoto,

        /// <summary>
        /// One or more users have copied the user's video.
        /// </summary>
        [EnumMember(Value = "copy_video")]
        CopyVideo,

        /// <summary>
        /// A new comment that mentions the user has been posted on a photo.
        /// </summary>
        [EnumMember(Value = "mention_comment_photo")]
        MentionCommentPhoto,

        /// <summary>
        /// A new comment that mentions the user has been posted on a video.
        /// </summary>
        [EnumMember(Value = "mention_comment_video")]
        MentionCommentVideo
    }
}