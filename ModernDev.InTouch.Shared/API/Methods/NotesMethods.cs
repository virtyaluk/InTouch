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
using ModernDev.InTouch.Helpers;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A base class for working with user's notes.
    /// </summary>
    public class NotesMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        public NotesMethods(InTouch api) : base(api, "notes") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a list of notes created by a user.
        /// </summary>
        /// <param name="noteIds">Note IDs.</param>
        /// <param name="userId">Note owner ID.</param>
        /// <param name="count">Number of notes to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of notes.</param>
        /// <param name="sortByDate">Sort order: True — by increasing creation date; False — by decreasing creation date.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Note"/> objects.</returns>
        public async Task<Response<ItemsList<Note>>> Get(List<int> noteIds = null, int? userId = null, int count = 20,
            int offset = 0, bool sortByDate = false) => await Request<ItemsList<Note>>("get", new MethodParams
            {
                {"note_ids", noteIds },
                {"user_id", userId },
                {"count", count, false, new [] {0, 100} },
                {"offset", offset },
                {"sort", sortByDate }
            });

        /// <summary>
        /// Returns a note by its ID.
        /// </summary>
        /// <param name="noteId">Note ID.</param>
        /// <param name="ownerId">Note owner ID.</param>
        /// <param name="needWiki">True - to return wiki code for the note in the <c>text</c> field.</param>
        /// <returns>Returns a <see cref="Note"/> object.</returns>
        public async Task<Response<Note>> GetById(int noteId, int? ownerId = null, bool needWiki = false)
            => await Request<Note>("getById", new MethodParams
            {
                {"note_id", noteId, true},
                {"owner_id", ownerId},
                {"need_wiki", needWiki}
            });

        /// <summary>
        /// Creates a new note for the current user.
        /// </summary>
        /// <param name="title">Note title.</param>
        /// <param name="text">Note text.</param>
        /// <param name="privacyView">View privacy settings in special format.</param>
        /// <param name="privacyComment">Comments privacy settings in special format.</param>
        /// <returns>Returns the ID of the created note.</returns>
        public async Task<Response<int>> Add(string title, string text, List<string> privacyView = null,
            List<string> privacyComment = null) => await Request<int>("add", new MethodParams
            {
                {"title", title, true},
                {"text", text, true},
                {"privacy_view", privacyView},
                {"privacy_comment", privacyComment}
            });

        /// <summary>
        /// Edits a note of the current user.
        /// </summary>
        /// <param name="noteId">Note ID.</param>
        /// <param name="title">Note title.</param>
        /// <param name="text">Note text. </param>
        /// <param name="privacyView">View privacy settings in special format.</param>
        /// <param name="privacyComment">Comments privacy settings in special format.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Edit(int noteId, string title, string text, List<string> privacyView = null,
            List<string> privacyComment = null) => await Request<bool>("edit", new MethodParams
            {
                {"note_id", noteId, true },
                {"title", title, true},
                {"text", text, true},
                {"privacy_view", privacyView},
                {"privacy_comment", privacyComment}
            });

        /// <summary>
        /// Deletes a note of the current user.
        /// </summary>
        /// <param name="noteId">Note ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Delete(int noteId) => await Request<bool>("delete",
            new MethodParams
            {
                {"note_id", noteId, true}
            });

        /// <summary>
        /// Returns a list of comments on a note.
        /// </summary>
        /// <param name="noteId">Note ID.</param>
        /// <param name="ownerId">Note owner ID.</param>
        /// <param name="sortByDate">Sort order: True — by increasing creation date; False — by decreasing creation date.</param>
        /// <param name="count">Number of comments to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of comments.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Comment"/> objects.</returns>
        public async Task<Response<ItemsList<Comment>>> GetComments(int noteId, int? ownerId = null,
            bool sortByDate = false, int count = 20, int offset = 0)
            => await Request<ItemsList<Comment>>("getComments", new MethodParams
            {
                {"note_id", noteId, true},
                {"owner_id", ownerId},
                {"sort", sortByDate},
                {"count", count, false, new[] {0, 100}},
                {"offset", offset}
            });

        /// <summary>
        /// Adds a new comment on a note.
        /// </summary>
        /// <param name="noteId">Note ID.</param>
        /// <param name="message">Comment text.</param>
        /// <param name="ownerId">Note owner ID.</param>
        /// <param name="replyTo">ID of the user to whom the reply is addressed (if the comment is a reply to another comment).</param>
        /// <returns>Returns the ID of the created comment.</returns>
        public async Task<Response<int>> CreateComment(int noteId, string message, int? ownerId = null,
            int? replyTo = null) => await Request<int>("createComment", new MethodParams
            {
                {"note_id", noteId, true},
                {"message", message, true},
                {"owner_id", ownerId},
                {"reply_to", replyTo},
                {"guid", Utils.RandomString(10)}
            });

        /// <summary>
        /// Edits a comment on a note.
        /// </summary>
        /// <param name="commentId">Comment ID.</param>
        /// <param name="message">New comment text.</param>
        /// <param name="ownerId">Note owner ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditComment(int commentId, string message, int? ownerId = null)
            => await Request<bool>("editComment", new MethodParams
            {
                {"comment_id", commentId, true},
                {"message", message, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Deletes a comment on a note.
        /// </summary>
        /// <param name="commentId">Comment ID.</param>
        /// <param name="ownerId">Note owner ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DeleteComment(int commentId, int? ownerId = null)
            => await Request<bool>("deleteComment", new MethodParams
            {
                {"comment_id", commentId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Restores a deleted comment on a note.
        /// </summary>
        /// <param name="commentId">Comment ID.</param>
        /// <param name="ownerId">Note owner ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> RestoreComment(int commentId, int? ownerId = null)
            => await Request<bool>("restoreComment", new MethodParams
            {
                {"comment_id", commentId, true},
                {"owner_id", ownerId}
            });

        #endregion
    }
}