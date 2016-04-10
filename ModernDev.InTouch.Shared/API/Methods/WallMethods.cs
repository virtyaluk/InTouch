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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ModernDev.InTouch.Helpers.Utils;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A base class for working with user's wall.
    /// </summary>
    public class WallMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="WallMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal WallMethods(InTouch api) : base(api, "wall") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a list of posts on a user wall or community wall.
        /// </summary>
        /// <param name="methodParams">A <see cref="WallGetParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Post"/> objects.</returns>
        public async Task<Response<ItemsList<Post>>> Get(WallGetParams methodParams)
            => await Request<ItemsList<Post>>("get", methodParams, true);

        /// <summary>
        /// Allows to search posts on user or community walls.
        /// </summary>
        /// <param name="methodParams">A <see cref="WallSearchParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Post"/> objects.</returns>
        public async Task<Response<ItemsList<Post>>> Search(WallSearchParams methodParams)
            => await Request<ItemsList<Post>>("search", methodParams, true);

        /// <summary>
        /// Returns a list of posts from user or community walls by their IDs.
        /// </summary>
        /// <param name="posts">
        /// User or community IDs and post IDs, separated by underscores. Use a negative value to designate a community ID.
        /// Example:
        /// <example>93388_21539,93388_20904,2943_4276,-1_1</example>
        /// </param>
        /// <param name="extended">True — to return user and community objects needed to display posts; False — no additional fields are returned(default).</param>
        /// <param name="copyHistoryDepth">Sets the number of parent elements to include in the list <see cref="ModernDev.InTouch.Post.CopyHistory"/> that is returned if the post is a repost from another wall. </param>
        /// <param name="fields">The list of additional fields for the profiles and groups that need to be returned. The list can accept <see cref="UserProfileFields"/>, <see cref="GroupProfileFields"/> and regular string objects.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Post"/> objects.</returns>
        public async Task<Response<ItemsList<Post>>> GetById(List<string> posts, bool extended = false,
            int copyHistoryDepth = 2, List<object> fields = null)
            => await Request<ItemsList<Post>>("getById", new MethodParams
            {
                {"posts", string.Join(",", posts), true},
                {"extended", extended},
                {"copy_history_depth", copyHistoryDepth},
                {
                    "fields", string.Join(",", fields?
                        .Where(el => el != null && (el is UserProfileFields || el is GroupProfileFields || el is string))
                        .Select(el => el is string ? el : ToEnumString(el)) ?? new[] {""})
                }
            }, true);

        /// <summary>
        /// Adds a new post on a user wall or community wall. Can also be used to publish suggested or scheduled posts.
        /// </summary>
        /// <param name="methodParams">A <see cref="WallPostParams"/> object with the params.</param>
        /// <returns>Returns the ID of the created post.</returns>
        public async Task<Response<int>> Post(WallPostParams methodParams)
            => await Request<int>("post", methodParams, false, "post_id");

        /// <summary>
        /// Reposts (copies) an object to a user wall or community wall.
        /// </summary>
        /// <param name="obj">
        /// ID of the object to be reposted on the wall. Example:
        /// <example>wall66748_3675</example>
        /// </param>
        /// <param name="message">Comment to be added along with the reposted object.</param>
        /// <param name="groupId">Target community ID when reposting to a community.</param>
        /// <param name="r"></param>
        /// <returns>Returns a <see cref="RepostResult"/> object.</returns>
        public async Task<Response<RepostResult>> Repost(string obj, string message = null, int? groupId = null,
            string r = null) => await Request<RepostResult>("repost", new MethodParams
            {
                {"object", obj, true},
                {"message", message},
                {"group_id", groupId},
                {"ref", r}
            });

        /// <summary>
        /// Reposts (copies) an object to a user wall or community wall.
        /// </summary>
        /// <param name="post">A <see cref="Post"/> object.</param>
        /// <param name="message">Comment to be added along with the reposted object.</param>
        /// <param name="groupId">Target community ID when reposting to a community.</param>
        /// <param name="r"></param>
        /// <returns>Returns a <see cref="RepostResult"/> object.</returns>
        public async Task<Response<RepostResult>> Repost(Post post, string message = null, int? groupId = null,
            string r = null) => await Repost($"wall{Math.Abs(post.OwnerId)}_{post.Id}", message, groupId, r);

        /// <summary>
        /// Returns information about reposts of a post on user wall or community wall.
        /// </summary>
        /// <param name="ownerId">User ID or community ID. By default, current user ID. Use a negative value to designate a community ID. </param>
        /// <param name="postId">Post ID.</param>
        /// <param name="offset">Offset needed to return a specific subset of reposts.</param>
        /// <param name="count">Number of reposts to return. </param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Post"/> objects.</returns>
        public async Task<Response<ItemsList<Post>>> GetReposts(int? postId = null, int? ownerId = null,
            int? offset = null, int count = 20)
            => await Request<ItemsList<Post>>("getReposts", new MethodParams
            {
                {"owner_id", ownerId},
                {"post_id", postId},
                {"offset", offset},
                {"count", count, false, new[] {0, 1000}}
            }, true);

        /// <summary>
        /// Edits a post on a user wall or community wall.
        /// </summary>
        /// <param name="methodParams">A <see cref="WallEditParams"/> object with the params.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Edit(WallEditParams methodParams) => await Request<bool>("edit", methodParams);

        /// <summary>
        /// Deletes a post from a user wall or community wall.
        /// </summary>
        /// <param name="postId">ID of the post to be deleted.</param>
        /// <param name="ownerId">User ID or community ID. Use a negative value to designate a community ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Delete(int postId, int? ownerId = null)
            => await Request<bool>("delete", new MethodParams
            {
                {"post_id", postId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Restores a post deleted from a user wall or community wall.
        /// </summary>
        /// <param name="postId">ID of the post to be deleted.</param>
        /// <param name="ownerId">User ID or community ID. Use a negative value to designate a community ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Restore(int postId, int? ownerId = null)
            => await Request<bool>("restore", new MethodParams
            {
                {"post_id", postId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Pin the post at the top of the wall.
        /// </summary>
        /// <param name="postId">ID of the post to be deleted.</param>
        /// <param name="ownerId">User ID or community ID. Use a negative value to designate a community ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Pin(int postId, int? ownerId = null)
            => await Request<bool>("pin", new MethodParams
            {
                {"post_id", postId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Unpin the post from the wall.
        /// </summary>
        /// <param name="postId">ID of the post to be deleted.</param>
        /// <param name="ownerId">User ID or community ID. Use a negative value to designate a community ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Unpin(int postId, int? ownerId = null)
            => await Request<bool>("unpin", new MethodParams
            {
                {"post_id", postId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Returns a list of comments on a post on a user wall or community wall.
        /// </summary>
        /// <param name="methodParams">A <see cref="WallGetCommentsParam"/> object with the params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Comment"/> objects.</returns>
        public async Task<Response<ItemsList<Comment>>> GetComments(WallGetCommentsParam methodParams)
            => await Request<ItemsList<Comment>>("getComments", methodParams);

        /// <summary>
        /// Adds a comment to a post on a user wall or community wall.
        /// </summary>
        /// <param name="methodParams">A <see cref="WallAddCommentParams"/> object with the params.</param>
        /// <returns>Returns the ID of the added comment.</returns>
        public async Task<Response<int>> AddComment(WallAddCommentParams methodParams)
            => await Request<int>("addComment", methodParams, false, "comment_id");

        /// <summary>
        /// Edits a comment on a user wall or community wall.
        /// </summary>
        /// <param name="commentId">Comment ID. </param>
        /// <param name="ownerId">User ID or community ID. Use a negative value to designate a community ID. </param>
        /// <param name="text">New comment text.</param>
        /// <param name="attachments">List of objects attached to the comment.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditComment(int commentId, int? ownerId = null, string text = null,
            List<string> attachments = null) => await Request<bool>("editComment", new MethodParams
            {
                {"comment_id", commentId, true},
                {"owner_id", ownerId},
                {"text", text},
                {"attachments", string.Join(",", attachments ?? new List<string>())}
            });

        /// <summary>
        /// Edits a comment on a user wall or community wall.
        /// </summary>
        /// <param name="commentId">Comment ID. </param>
        /// <param name="ownerId">User ID or community ID. Use a negative value to designate a community ID. </param>
        /// <param name="text">New comment text.</param>
        /// <param name="attachments">List of objects attached to the comment.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditComment(int commentId, int? ownerId = null, string text = null,
            List<IMediaAttachment> attachments = null)
            => await EditComment(commentId, ownerId, text, attachments?.GetCommentAttachments());

        /// <summary>
        /// Deletes a comment on a post on a user wall or community wall. 
        /// </summary>
        /// <param name="commentId">Comment ID. </param>
        /// <param name="ownerId">User ID or community ID. Use a negative value to designate a community ID. </param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DeleteComment(int commentId, int? ownerId = null)
            => await Request<bool>("deleteComment", new MethodParams
            {
                {"comment_id", commentId, true },
                {"owner_id", ownerId }
            });

        /// <summary>
        /// Restores a comment deleted from a user wall or community wall. 
        /// </summary>
        /// <param name="commentId">Comment ID. </param>
        /// <param name="ownerId">User ID or community ID. Use a negative value to designate a community ID. </param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> RestoreComment(int commentId, int? ownerId = null)
            => await Request<bool>("restoreComment", new MethodParams
            {
                {"comment_id", commentId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Reports (submits a complaint about) a post on a user wall or community wall. 
        /// </summary>
        /// <param name="postId">ID of the post to be deleted.</param>
        /// <param name="ownerId">User ID or community ID. Use a negative value to designate a community ID.</param>
        /// <param name="reason"></param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> ReportPost(int postId, int ownerId, ReportReasonTypes reason)
            => await Request<bool>("reportPost", new MethodParams
            {
                {"post_id", postId, true},
                {"owner_id", ownerId, true},
                {"reason", (int) reason}
            });

        /// <summary>
        /// Reports (submits a complaint about) a comment on a post on a user wall or community wall. 
        /// </summary>
        /// <param name="commentId"></param>
        /// <param name="ownerId"></param>
        /// <param name="reason"></param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> ReportComment(int commentId, int ownerId, ReportReasonTypes reason)
            => await Request<bool>("restoreComment", new MethodParams
            {
                {"comment_id", commentId, true},
                {"owner_id", ownerId, true},
                {"reason", (int) reason }
            });

        #endregion
    }
}