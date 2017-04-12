namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="GroupsSetCallbackSettingsParams"/> class describes a <see cref="GroupsMethods.SetCallbackSettings"/> method params.
    /// </summary>
    public class GroupsSetCallbackSettingsParams : MethodParamsGroup
    {
        /// <summary>
        /// Community ID. 
        /// </summary>
        [MethodParam(Name ="group_id", IsRequired = true)]
        public int GroupId { get; set; }

        /// <summary>
        /// New messages notifications.
        /// </summary>
        [MethodParam(Name = "message_new")]
        public bool MessageNew { get; set; }

        /// <summary>
        /// New user consent to messages sending.
        /// </summary>
        [MethodParam(Name = "message_allow")]
        public bool MessageAllow { get; set; }

        /// <summary>
        /// New user prohibition to messages sending.
        /// </summary>
        [MethodParam(Name = "message_deny")]
        public bool MessageDeny { get; set; }

        /// <summary>
        /// New photos notifications.
        /// </summary>
        [MethodParam(Name = "photo_new")]
        public bool PhotoNew { get; set; }

        /// <summary>
        /// New audios notifications.
        /// </summary>
        [MethodParam(Name = "audio_new")]
        public bool AudioNew { get; set; }

        /// <summary>
        /// New videos notifications.
        /// </summary>
        [MethodParam(Name = "video_new")]
        public bool VideoNew { get; set; }

        /// <summary>
        /// New wall replies notifications.
        /// </summary>
        [MethodParam(Name = "wall_reply_new")]
        public bool WallReplyNew { get; set; }

        /// <summary>
        /// Wall replies edited notifications.
        /// </summary>
        [MethodParam(Name = "wall_reply_edit")]
        public bool WallReplyEdit { get; set; }

        /// <summary>
        /// New wall posts notifications.
        /// </summary>
        [MethodParam(Name = "wall_post_new")]
        public bool WallPostNew { get; set; }

        /// <summary>
        /// New board posts notifications.
        /// </summary>
        [MethodParam(Name = "board_post_new")]
        public bool BoardPostNew { get; set; }

        /// <summary>
        /// Board posts edited notifications.
        /// </summary>
        [MethodParam(Name = "board_post_edit")]
        public bool BoardPostEdit { get; set; }

        /// <summary>
        /// Board posts restored notifications
        /// </summary>
        [MethodParam(Name = "board_post_restore")]
        public bool BoardPostRestore { get; set; }

        /// <summary>
        /// Board posts deleted notifications.
        /// </summary>
        [MethodParam(Name = "board_post_delete")]
        public bool BoardPostDelete { get; set; }

        /// <summary>
        /// New comment to photo notifications.
        /// </summary>
        [MethodParam(Name = "photo_comment_new")]
        public bool PhotoCommentNew { get; set; }

        /// <summary>
        /// New comment to video notifications.
        /// </summary>
        [MethodParam(Name = "video_comment_new")]
        public bool VideoCommentNew { get; set; }

        /// <summary>
        /// New comment to market item notifications.
        /// </summary>
        [MethodParam(Name = "market_comment_new")]
        public bool MarketCommentNew { get; set; }

        /// <summary>
        /// Joined community notifications.
        /// </summary>
        [MethodParam(Name = "group_join")]
        public bool GroupJoin { get; set; }

        /// <summary>
        /// Left community notifications.
        /// </summary>
        [MethodParam(Name = "group_leave")]
        public bool GroupLeave { get; set; }

        /// <summary>
        /// epost from the community
        /// </summary>
        [MethodParam(Name = "wall_repost")]
        public bool WallRepost { get; set; }
    }
}