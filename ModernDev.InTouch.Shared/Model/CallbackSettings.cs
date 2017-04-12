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
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="CallbackSettings"/> class describes notifications settings for Callback API.
    /// </summary>
    [DebuggerDisplay("CallbackSettings")]
    [DataContract]
    public class CallbackSettings
    {
        /// <summary>
        /// New message.
        /// </summary>
        [DataMember]
        [JsonProperty("message_new")]
        public bool MessageNew { get; set; }

        /// <summary>
        /// New user consent to messages sending.
        /// </summary>
        [DataMember]
        [JsonProperty("message_allow")]
        public bool MessageAllow { get; set; }

        /// <summary>
        /// New user prohibition to messages sending.
        /// </summary>
        [DataMember]
        [JsonProperty("message_deny")]
        public bool MessageDeny { get; set; }

        /// <summary>
        /// New comment on wall.
        /// </summary>
        [DataMember]
        [JsonProperty("wall_reply_new")]
        public bool WallReplyNew { get; set; }

        /// <summary>
        /// Edited comment on wall .
        /// </summary>
        [DataMember]
        [JsonProperty("wall_reply_edit")]
        public bool WallReplyEdit { get; set; }

        /// <summary>
        /// New comment in topic.
        /// </summary>
        [DataMember]
        [JsonProperty("board_post_new")]
        public bool BoardPostNew { get; set; }

        /// <summary>
        /// Edited comment in topic.
        /// </summary>
        [DataMember]
        [JsonProperty("board_post_edit")]
        public bool BoardPostEdit { get; set; }

        /// <summary>
        /// Deleted comment in topic.
        /// </summary>
        [DataMember]
        [JsonProperty("board_post_delete")]
        public bool BoardPostDelete { get; set; }

        /// <summary>
        /// Restored comment in topic.
        /// </summary>
        [DataMember]
        [JsonProperty("board_post_restore")]
        public bool BoardPostRestore { get; set; }

        /// <summary>
        /// New photo.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_new")]
        public bool PhotoNew { get; set; }

        /// <summary>
        /// New video.
        /// </summary>
        [DataMember]
        [JsonProperty("video_new")]
        public bool VideoNew { get; set; }

        /// <summary>
        /// New audio.
        /// </summary>
        [DataMember]
        [JsonProperty("audio_new")]
        public bool AudioNew { get; set; }

        /// <summary>
        /// New comment to photo.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_comment_new")]
        public bool PhotoCommentNew { get; set; }

        /// <summary>
        /// New comment to video.
        /// </summary>
        [DataMember]
        [JsonProperty("video_comment_new")]
        public bool VideoCommentNew { get; set; }

        /// <summary>
        /// New comment to market item.
        /// </summary>
        [DataMember]
        [JsonProperty("market_comment_new")]
        public bool MarketCommentNew { get; set; }

        /// <summary>
        /// Joined community.
        /// </summary>
        [DataMember]
        [JsonProperty("group_join")]
        public bool GroupJoin { get; set; }

        /// <summary>
        /// Left community.
        /// </summary>
        [DataMember]
        [JsonProperty("group_leave")]
        public bool GroupLeave { get; set; }

        /// <summary>
        /// New post on the wall.
        /// </summary>
        [DataMember]
        [JsonProperty("wall_post_new")]
        public bool WallPostNew { get; set; }

        /// <summary>
        /// Repost from the community.
        /// </summary>
        [DataMember, JsonProperty("wall_repost")]
        public bool WallRepost { get; set; }
    }
}