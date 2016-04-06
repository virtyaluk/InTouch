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
    /// A base  class for working with market items.
    /// </summary>
    public class MarketMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MarketMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        public MarketMethods(InTouch api) : base(api, "market") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns items list for a community.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="albumId">Identifier of a collection to return items from.</param>
        /// <param name="count">Number of items to return.</param>
        /// <param name="offset">Offset based on a first matching item to get a certain items subset.</param>
        /// <param name="extended">True - method will return additional fields. These parameters are not returned by default.</param>
        /// <returns>Returns a list of <see cref="Product"/> objects.</returns>
        public async Task<Response<ItemsList<Product>>> Get(int ownerId, int? albumId = null, int count = 100,
            int offset = 0, bool extended = false) => await Request<ItemsList<Product>>("get", new MethodParams
            {
                {"owner_id", ownerId},
                {"album_id", albumId},
                {"count", count, false, new[] {0, 200}},
                {"offset", offset},
                {"extended", extended}
            });

        /// <summary>
        /// Returns information about market items by their ids.
        /// </summary>
        /// <param name="itemIds">
        /// Ids list: {user id}_{item id}. 
        /// If an item belongs to a community -{community id} is used.
        /// <example>
        /// Videos value example: 
        /// -4363_136089719,13245770_137352259
        /// </example>
        /// </param>
        /// <param name="extended">True - method will return additional fields. These parameters are not returned by default.</param>
        /// <returns>Returns a list of <see cref="Product"/> objects.</returns>
        public async Task<Response<ItemsList<Product>>> GetById(List<string> itemIds, bool extended = false)
            => await Request<ItemsList<Product>>("getById", new MethodParams
            {
                {"item_ids", itemIds},
                {"extended", extended}
            });

        /// <summary>
        /// Searches market items in a community's catalog.
        /// </summary>
        /// <param name="methodParams">A <see cref="MarketSearchParams"/> object with the params.</param>
        /// <returns>Returns a list of <see cref="Product"/> objects.</returns>
        public async Task<Response<ItemsList<Product>>> Search(MarketSearchParams methodParams)
            => await Request<ItemsList<Product>>("search", methodParams);

        /// <summary>
        /// Returns community's albums list.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="count">Number of items to return.</param>
        /// <param name="offset">Offset based on a first matching item to get a certain items subset.</param>
        /// <returns>Returns a list of <see cref="MarketAlbum"/> objects.</returns>
        public async Task<Response<ItemsList<MarketAlbum>>> GetAlbums(int ownerId, int count = 50, int offset = 0)
            => await Request<ItemsList<MarketAlbum>>("getAlbums", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"count", count, false, new[] {0, 100}},
                {"offset", offset}
            });

        /// <summary>
        /// Returns items album's data.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="albumIds"></param>
        /// <returns>Returns a list of <see cref="MarketAlbum"/> objects.</returns>
        public async Task<Response<ItemsList<MarketAlbum>>> GetAlbumById(int ownerId, List<int> albumIds)
            => await Request<ItemsList<MarketAlbum>>("getAlbumById", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"album_ids", albumIds}
            });

        /// <summary>
        /// Creates a new comment for an item.
        /// </summary>
        /// <param name="methodParams">A <see cref="MarketCreateCommentParams"/> object with the params.</param>
        /// <returns>Returns created comment's id.</returns>
        public async Task<Response<int>> CreateComment(MarketCreateCommentParams methodParams)
            => await Request<int>("createComment", methodParams);

        /// <summary>
        /// Returns comments list for an item.
        /// </summary>
        /// <param name="methodParams">A <see cref="MarketGetCommentsParams"/> object with the params.</param>
        /// <returns>Returns a list of <see cref="Comment"/> objects.</returns>
        public async Task<Response<ItemsList<Comment>>> GetComments(MarketGetCommentsParams methodParams)
            => await Request<ItemsList<Comment>>("getComments", methodParams);

        /// <summary>
        /// Deletes an item's comment.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="commentId">Comment Id.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DeleteComment(int ownerId, int commentId)
            => await Request<bool>("deleteComment", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"comment_id", commentId, true}
            });

        /// <summary>
        /// Restores a recently deleted comment.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="commentId">Comment Id.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> RestoreComment(int ownerId, int commentId)
            => await Request<bool>("restoreComment", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"comment_id", commentId, true}
            });

        /// <summary>
        /// Changes item comment's text.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="commentId">Comment Id.</param>
        /// <param name="message">New comment text (required if <c>attachments</c> are not specified). 2048 symbols max.</param>
        /// <param name="attachments">
        /// List of objects attached to a comment.
        /// The field is submitted the following way:
        /// <example>{type}{owner_id}_{media_id},{type}{owner_id}_{media_id}</example>
        /// {type} - media attachment type:
        /// photo - photo 
        /// video - video
        /// audio - audio
        /// doc - document
        /// 
        /// {owner_id} - media owner id 
        /// {media_id} - media attachment id
        /// 
        /// For example:
        /// <example>photo100172_166443618,photo66748_265827614</example>
        /// </param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditComment(int ownerId, int commentId, string message = null,
            List<string> attachments = null) => await Request<bool>("editComment", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"comment_id", commentId, true},
                {"message", message},
                {"attachments", attachments}
            });

        /// <summary>
        /// Changes item comment's text.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="commentId">Comment Id.</param>
        /// <param name="message">New comment text (required if <c>attachments</c> are not specified). 2048 symbols max.</param>
        /// <param name="attachments">List of objects attached to a comment.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditComment(int ownerId, int commentId, string message = null,
            List<IMediaAttachment> attachments = null)
            => await EditComment(ownerId, commentId, message, attachments?.GetCommentAttachments());

        /// <summary>
        /// Sends a complaint to the item's comment.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="commentId">Comment Id.</param>
        /// <param name="reason">Complaint reason.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> ReportComment(int ownerId, int commentId, ReportTypes reason)
            => await Request<bool>("reportComment", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"comment_id", commentId, true},
                {"reason", (int) reason, true}
            });

        /// <summary>
        /// Returns a list of items categories.
        /// </summary>
        /// <param name="count">Number of items to return.</param>
        /// <param name="offset">Offset based on a first matching item to get a certain items subset.</param>
        /// <returns>Returns a list of <see cref="MarketCategory"/> objects.</returns>
        public async Task<Response<ItemsList<MarketCategory>>> GetCategories(int count = 10, int offset = 0)
            => await Request<ItemsList<MarketCategory>>("getCategories", new MethodParams
            {
                {"count", count, false, new[] {0, 1000}},
                {"offset", offset}
            });

        /// <summary>
        /// Sends a complaint to the item.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="itemId">Item Id.</param>
        /// <param name="reason">Complaint reason.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Report(int ownerId, int itemId, ReportTypes reason)
            => await Request<bool>("report", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"item_id", itemId, true},
                {"reason", (int) reason, true}
            });

        /// <summary>
        /// Ads a new item to the market.
        /// </summary>
        /// <param name="methodParams">A <see cref="MarketAddParams"/> object with the params.</param>
        /// <returns>Returns created item's id if executed successfully.</returns>
        public async Task<Response<int>> Add(MarketAddParams methodParams) => await Request<int>("add", methodParams);

        /// <summary>
        /// Edits an item.
        /// </summary>
        /// <param name="methodParams">A <see cref="MarketEditParams"/> object with the params.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Edit(MarketEditParams methodParams) => await Request<bool>("edit", methodParams);

        /// <summary>
        /// Deletes an item.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="itemId">Item Id.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Delete(int ownerId, int itemId)
            => await Request<bool>("delete", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"item_id", itemId, true}
            });

        /// <summary>
        /// Restores recently deleted item.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="itemId">Item Id.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Restore(int ownerId, int itemId)
            => await Request<bool>("restore", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"item_id", itemId, true}
            });

        /// <summary>
        /// Changes item place in a collection.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="itemId">Item Id.</param>
        /// <param name="albumId">Identifier of a collection to reorder items in. Set 0 to reorder full items list..</param>
        /// <param name="after">Id of an item to place current item after it.</param>
        /// <param name="before">Id of an item to place current item before it.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> ReorderItems(int ownerId, int itemId, int? albumId = null, int? after = null,
            int? before = null) => await Request<bool>("reorderItems", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"item_id", itemId, true},
                {"album_id", albumId},
                {"after", after},
                {"before", before}
            });

        /// <summary>
        /// Reorders the collections list.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="albumId">Collection id.</param>
        /// <param name="before">Id of a collection to place current collection before it.</param>
        /// <param name="after">Id of a collection to place current collection after it.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> ReorderAlbums(int ownerId, int albumId, int? before = null, int? after = null)
            => await Request<bool>("reorderAlbums", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"album_id", albumId, true},
                {"before", before},
                {"after", after}
            });

        /// <summary>
        /// Creates new collection of items.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="title">Collection title.</param>
        /// <param name="photoId">Collection cover photo Id.</param>
        /// <param name="mainAlbum">Set as main (True – set, False – no).</param>
        /// <returns>Returns created collection Id.</returns>
        public async Task<Response<int>> AddAlbum(int ownerId, string title, int? photoId = null, bool mainAlbum = false)
            => await Request<int>("addAlbum", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"title", title, true},
                {"photo_id", photoId},
                {"main_album", mainAlbum}
            }, false, "market_album_id");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="albumId"></param>
        /// <param name="title">New collection title.</param>
        /// <param name="photoId">New collection cover photo Id.</param>
        /// <param name="mainAlbum">Set as main (True – set, False – no).</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditAlbum(int ownerId, int albumId, string title, int? photoId = null,
            bool mainAlbum = false)
            => await Request<bool>("editAlbum", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"album_id", albumId, true},
                {"title", title, true},
                {"photo_id", photoId},
                {"main_album", mainAlbum}
            });

        /// <summary>
        /// Deletes a collection of items.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="albumId">Collection Id.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DeleteAlbum(int ownerId, int albumId)
            => await Request<bool>("deleteAlbum", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"album_id", albumId, true}
            });

        /// <summary>
        /// Removes an item from one or multiple collections.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="itemId">Item Id.</param>
        /// <param name="albumIds">Collections ids to remove item from.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> RemoveFromAlbum(int ownerId, int itemId, List<int> albumIds)
            => await Request<bool>("removeFromAlbum", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"item_id", itemId, true},
                {"album_ids", albumIds, true}
            });

        /// <summary>
        /// Adds an item to one or multiple collections.
        /// </summary>
        /// <param name="ownerId">Identifier of an item owner community.</param>
        /// <param name="itemId">Item Id.</param>
        /// <param name="albumIds">Collections ids to add item to.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> AddToAlbum(int ownerId, int itemId, List<int> albumIds)
            => await Request<bool>("addToAlbum", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"item_id", itemId, true},
                {"album_ids", albumIds, true}
            });

        #endregion
    }
}
