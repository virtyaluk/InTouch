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
using System.Threading.Tasks;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A base class for working with group's boards.
    /// </summary>
    public class BoardMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal BoardMethods(InTouch api) : base(api, "board") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a list of topics on a community's discussion board.
        /// </summary>
        /// <param name="methodParams">A <see cref="BoardGetTopicsParams"/> object with the params.</param>
        /// <returns>Returns a list of topics.</returns>
        public async Task<Response<TopicsList>> GetTopics(BoardGetTopicsParams methodParams)
            => await Request<TopicsList>("getTopics", methodParams, true);

        /// <summary>
        /// Returns a list of comments on a topic on a community's discussion board.
        /// </summary>
        /// <param name="methodParams">A <see cref="BoardGetCommentsParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Comment"/> objects.</returns>
        public async Task<Response<ItemsList<Comment>>> GetComments(BoardGetCommentsParams methodParams)
            => await Request<ItemsList<Comment>>("getComments", methodParams, true);

        /// <summary>
        /// Creates a new topic on a community's discussion board.
        /// </summary>
        /// <param name="groupId">ID of the community that owns the discussion board.</param>
        /// <param name="title">Topic title.</param>
        /// <param name="text">Text of the topic.</param>
        /// <param name="fromGroup">For a community: True — to post the topic as by the community; False — to post the topic as by the user(default).</param>
        /// <param name="attachments">List of media objects attached to the topic</param>
        /// <returns>Returns the ID of the created topic.</returns>
        public async Task<Response<int>> AddTopic(int groupId, string title, string text = null, bool fromGroup = true,
            List<IMediaAttachment> attachments = null)
            => await AddTopic(groupId, title, text, fromGroup, attachments?.GetCommentAttachments());

        /// <summary>
        /// Creates a new topic on a community's discussion board.
        /// </summary>
        /// <param name="groupId">ID of the community that owns the discussion board.</param>
        /// <param name="title">Topic title.</param>
        /// <param name="text">Text of the topic.</param>
        /// <param name="fromGroup">For a community: True — to post the topic as by the community; False — to post the topic as by the user(default).</param>
        /// <param name="attachments">List of media objects attached to the topic</param>
        /// <returns>Returns the ID of the created topic.</returns>
        /// <returns></returns>
        public async Task<Response<int>> AddTopic(int groupId, string title, string text = null, bool fromGroup = true,
            List<string> attachments = null) => await Request<int>("addTopic", new MethodParams
            {
                {"group_id", groupId, true },
                {"title", title, true },
                {"text", text },
                {"from_group", fromGroup },
                {"attachments", attachments }
            });

        /// <summary>
        /// Adds a comment on a topic on a community's discussion board.
        /// </summary>
        /// <param name="methodParams">A <see cref="BoardAddCommentParams"/> object with the params.</param>
        /// <returns>Returns the ID of the created comment.</returns>
        public async Task<Response<int>> AddComment(BoardAddCommentParams methodParams)
            => await Request<int>("addComment", methodParams);

        /// <summary>
        /// Deletes a topic from a community's discussion board.
        /// </summary>
        /// <param name="groupId">ID of the community that owns the discussion board.</param>
        /// <param name="topicId">Topic ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DeleteTopic(int groupId, int topicId)
            => await Request<bool>("deleteTopic", new MethodParams
            {
                {"group_id", groupId, true},
                {"topic_id", topicId, true}
            });

        /// <summary>
        /// Edits the title of a topic on a community's discussion board.
        /// </summary>
        /// <param name="groupId">ID of the community that owns the discussion board.</param>
        /// <param name="topicId">Topic ID.</param>
        /// <param name="title">New title of the topic.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditTopic(int groupId, int topicId, string title)
            => await Request<bool>("editTopic", new MethodParams
            {
                {"group_id", groupId, true},
                {"topic_id", topicId, true},
                {"title", title, true}
            });

        /// <summary>
        /// Edits a comment on a topic on a community's discussion board.
        /// </summary>
        /// <param name="groupId">ID of the community that owns the discussion board.</param>
        /// <param name="topicId">Topic ID.</param>
        /// <param name="commentId">ID of the comment on the topic.</param>
        /// <param name="text">(Required if attachments is not set.) New text of the comment.</param>
        /// <param name="attachments">(Required if text is not set.) List of media objects attached to the comment.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditComment(int groupId, int topicId, int commentId, string text = null,
            List<IMediaAttachment> attachments = null)
            => await EditComment(groupId, topicId, commentId, text, attachments?.GetCommentAttachments());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId">ID of the community that owns the discussion board.</param>
        /// <param name="topicId">Topic ID.</param>
        /// <param name="commentId">ID of the comment on the topic.</param>
        /// <param name="text">(Required if attachments is not set.) New text of the comment.</param>
        /// <param name="attachments">(Required if text is not set.) List of media objects attached to the comment.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditComment(int groupId, int topicId, int commentId, string text = null,
            List<string> attachments = null) => await Request<bool>("editComment", new MethodParams
            {
                {"group_id", groupId, true },
                {"topic_id", topicId, true },
                {"comment_id", commentId, true },
                {"text", text },
                {"attachments", attachments }
            });

        /// <summary>
        /// Restores a comment deleted from a topic on a community's discussion board.
        /// </summary>
        /// <param name="groupId">ID of the community that owns the discussion board.</param>
        /// <param name="topicId">Topic ID.</param>
        /// <param name="commentId">ID of the comment on the topic.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> RestoreComment(int groupId, int topicId, int commentId)
            => await Request<bool>("restoreComment", new MethodParams
            {
                {"group_id", groupId, true},
                {"topic_id", topicId, true},
                {"comment_id", commentId, true}
            });

        /// <summary>
        /// Deletes a comment on a topic on a community's discussion board.
        /// </summary>
        /// <param name="groupId">ID of the community that owns the discussion board.</param>
        /// <param name="topicId">Topic ID.</param>
        /// <param name="commentId">ID of the comment on the topic.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DeleteComment(int groupId, int topicId, int commentId)
            => await Request<bool>("deleteComment", new MethodParams
            {
                {"group_id", groupId, true},
                {"topic_id", topicId, true},
                {"comment_id", commentId, true}
            });

        /// <summary>
        /// Re-opens a previously closed topic on a community's discussion board.
        /// </summary>
        /// <param name="groupId">ID of the community that owns the discussion board.</param>
        /// <param name="topicId">Topic ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> OpenTopic(int groupId, int topicId)
            => await Request<bool>("openTopic", new MethodParams
            {
                {"group_id", groupId, true},
                {"topic_id", topicId, true}
            });

        /// <summary>
        /// Closes a topic on a community's discussion board so that comments cannot be posted.
        /// </summary>
        /// <param name="groupId">ID of the community that owns the discussion board.</param>
        /// <param name="topicId">Topic ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> CloseTopic(int groupId, int topicId)
            => await Request<bool>("closeTopic", new MethodParams
            {
                {"group_id", groupId, true},
                {"topic_id", topicId, true}
            });

        /// <summary>
        /// Pins a topic (fixes its place) to the top of a community's discussion board.
        /// </summary>
        /// <param name="groupId">ID of the community that owns the discussion board.</param>
        /// <param name="topicId">Topic ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> FixTopic(int groupId, int topicId)
            => await Request<bool>("fixTopic", new MethodParams
            {
                {"group_id", groupId, true},
                {"topic_id", topicId, true}
            });

        /// <summary>
        /// Unpins a pinned topic from the top of a community's discussion board.
        /// </summary>
        /// <param name="groupId">ID of the community that owns the discussion board.</param>
        /// <param name="topicId">Topic ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> UnfixTopic(int groupId, int topicId)
            => await Request<bool>("unfixTopic", new MethodParams
            {
                {"group_id", groupId, true},
                {"topic_id", topicId, true}
            });

        #endregion
    }
}