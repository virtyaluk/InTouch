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
using System.Threading.Tasks;
using ModernDev.InTouch.Helpers;
using static ModernDev.InTouch.Helpers.Utils;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A base class for working with user's newsfeed.
    /// </summary>
    public class NewsfeedMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsfeedMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal NewsfeedMethods(InTouch api) : base(api, "newsfeed") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns data required to show newsfeed for the current user.
        /// </summary>
        /// <param name="methodParams">A <see cref="NewsfeedGetParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="NewsFeed"/> object containing news items.</returns>
        public async Task<Response<NewsFeed>> Get(NewsfeedGetParams methodParams = null)
            => await Request<NewsFeed>("get", methodParams);

        /// <summary>
        /// Returns a list of newsfeeds recommended to the current user.
        /// </summary>
        /// <param name="methodParams">A <see cref="NewsfeedGetRecommendedParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="NewsFeed"/> object containing news items.</returns>
        public async Task<Response<NewsFeed>> GetRecommended(NewsfeedGetRecommendedParams methodParams = null)
            => await Request<NewsFeed>("getRecommended", methodParams);

        /// <summary>
        /// Returns a list of comments in the current user's newsfeed.
        /// </summary>
        /// <param name="methodParams">A <see cref="NewsfeedGetCommentsParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="NewsFeed"/> object containing news items.</returns>
        public async Task<Response<NewsFeed>> GetComments(NewsfeedGetCommentsParams methodParams = null)
            => await Request<NewsFeed>("getComments", methodParams);

        /// <summary>
        /// Returns a list of posts on user walls in which the current user is mentioned.
        /// </summary>
        /// <param name="ownerId">Owner Id.</param>
        /// <param name="startTime">Earliest timestamp of a post to return. By default, 24 hours ago.</param>
        /// <param name="endTime">Latest timestamp of a post to return. By default, the current time. </param>
        /// <param name="offset">Offset needed to return a specific subset of posts. </param>
        /// <param name="count">Number of posts to return.</param>
        /// <returns>Returns a list of <see cref="NewsPost"/> objects.</returns>
        public async Task<Response<ItemsList<NewsPost>>> GetMentions(int? ownerId = null, DateTime? startTime = null,
            DateTime? endTime = null, int offset = 0, int count = 20)
            => await Request<ItemsList<NewsPost>>("getMentions", new MethodParams
            {
                {"owner_id", ownerId},
                {"start_time", startTime?.ToUnixTimeStamp()},
                {"end_time", endTime?.ToUnixTimeStamp()},
                {"offset", offset},
                {"count", count, false, new[] {0, 50}}
            });

        /// <summary>
        /// Returns a list of users and communities banned from the current user's newsfeed.
        /// </summary>
        /// <param name="fields">Profile fields to return.</param>
        /// <param name="nameCase">Case for declension of user name and surname.</param>
        /// <returns>Returns a mixed list of <see cref="User"/> and <see cref="Group"/> objects.</returns>
        public async Task<Response<ItemsList<EmptyItem>>> GetBanned(List<UserProfileFields> fields = null,
            NameCases nameCase = NameCases.Nominative) => await Request<ItemsList<EmptyItem>>("getBanned", new MethodParams
            {
                {"extended", true},
                {"fields", fields},
                {"name_case", ToEnumString(nameCase)}
            });

        /// <summary>
        /// Prevents news from specified users and communities from appearing in the current user's newsfeed.
        /// </summary>
        /// <param name="userIds">IDs of users whose news will be removed from the newsfeed. </param>
        /// <param name="groupIds">IDs of communities whose news will be removed from the newsfeed. </param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> AddBan(List<int> userIds, List<int> groupIds)
            => await Request<bool>("addBan", new MethodParams
            {
                {"user_ids", userIds},
                {"group_ids", groupIds}
            });

        /// <summary>
        /// Allows news from previously banned users and communities to be shown in the current user's newsfeed.
        /// </summary>
        /// <param name="userIds">IDs of users whose news will be removed from the newsfeed. </param>
        /// <param name="groupIds">IDs of communities whose news will be removed from the newsfeed. </param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DeleteBan(List<int> userIds, List<int> groupIds)
            => await Request<bool>("deleteBan", new MethodParams
            {
                {"user_ids", userIds},
                {"group_ids", groupIds}
            });

        /// <summary>
        /// Hides an item from the newsfeed.
        /// </summary>
        /// <param name="type">Item type.</param>
        /// <param name="ownerId">Item owner's identifier (user or community).</param>
        /// <param name="itemId">Item identifier.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> IgnoreItem(NewsfeedIgnoreItemTypes type, int ownerId, int itemId)
            => await Request<bool>("ignoreItem", new MethodParams
            {
                {"type", ToEnumString(type), true},
                {"owner_id", ownerId, true},
                {"item_id", itemId, true}
            });

        /// <summary>
        /// Returns a hidden item to the newsfeed.
        /// </summary>
        /// <param name="type">Item type.</param>
        /// <param name="ownerId">Item owner's identifier (user or community).</param>
        /// <param name="itemId">Item identifier.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> UnignoreItem(NewsfeedIgnoreItemTypes type, int ownerId, int itemId)
            => await Request<bool>("unignoreItem", new MethodParams
            {
                {"type", ToEnumString(type), true},
                {"owner_id", ownerId, true},
                {"item_id", itemId, true}
            });

        /// <summary>
        /// Returns search results by statuses. 
        /// </summary>
        /// <param name="methodParams">A <see cref="NewsfeedSearchParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="NewsFeed"/> object containing news items.</returns>
        public async Task<Response<NewsFeed>> Search(NewsfeedSearchParams methodParams)
            => await Request<NewsFeed>("search", methodParams);

        /// <summary>
        /// Returns a list of newsfeeds followed by the current user.
        /// </summary>
        /// <param name="listIds">Numeric list identifiers.</param>
        /// <param name="extended">True - to return additional list info (<see cref="NewsList.SourceIds"/> and <see cref="NewsList.NoReposts"/> values).</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="NewsList"/> objects.</returns>
        public async Task<Response<ItemsList<NewsList>>> GetLists(List<int> listIds = null, bool extended = true)
            => await Request<ItemsList<NewsList>>("getLists", new MethodParams
            {
                {"list_ids", listIds},
                {"extended", extended}
            });

        /// <summary>
        /// Creates and edits user newsfeed lists.
        /// </summary>
        /// <param name="title">List name.</param>
        /// <param name="listId">Numeric list identifier (if not sent, will be set automatically).</param>
        /// <param name="sourceIds">Users and communities identifiers to be added to the list. Community identifiers must be negative numbers.</param>
        /// <param name="noReposts">Reposts display on and off (True is for off).</param>
        /// <returns>If successfully executed, returns a created or edited list identifier.</returns>
        public async Task<Response<int>> SaveList(string title, int? listId = null, List<int> sourceIds = null,
            bool noReposts = true) => await Request<int>("saveList", new MethodParams
            {
                {"title", title, true},
                {"source_ids", sourceIds},
                {"list_id", listId},
                {"no_reposts", noReposts}
            });

        /// <summary>
        /// Deletes user newsfeed list.
        /// </summary>
        /// <param name="listId">Numeric list identifier (if not sent, will be set automatically).</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DeleteList(int listId)
            => await Request<bool>("deleteList", new MethodParams
            {
                {"list_id", listId}
            });

        /// <summary>
        /// Unsubscribes the current user from specified newsfeeds.
        /// </summary>
        /// <param name="itemId">Object ID.</param>
        /// <param name="type">Type of object from which to unsubscribe.</param>
        /// <param name="ownerId">Object owner ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Unsubscribe(int itemId, NewsfeedCommentsFilters type, int? ownerId = null)
            => await Request<bool>("unsubscribe", new MethodParams
            {
                {"type", ToEnumString(type), true},
                {"item_id", itemId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Returns communities and users that current user is suggested to follow.
        /// </summary>
        /// <param name="count">Number of sources to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of sources.</param>
        /// <param name="shuffle">Shuffle the returned list or not.</param>
        /// <param name="fields">Profile fields to return.</param>
        /// <returns>Returns a mixed list of <see cref="User"/> and <see cref="Group"/> objects.</returns>
        public async Task<Response<MixedProfilesList>> GetSuggestedSources(int count = 20, int offset = 0,
            bool shuffle = false, List<object> fields = null)
            => await Request<MixedProfilesList>("getSuggestedSources", new MethodParams
            {
                {"count", count, false, new[] {0, 1000}},
                {"offset", offset},
                {"shuffle", shuffle},
                {"fields", fields}
            });

        #endregion
    }
}