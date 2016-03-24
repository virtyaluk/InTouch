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
using System.Linq;
using System.Threading.Tasks;
using ModernDev.InTouch.Helpers;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A base class for working with friends.
    /// </summary>
    public class FriendsMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FriendsMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        public FriendsMethods(InTouch api) : base(api, "friends") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a list of user IDs or detailed information about a user's friends.
        /// </summary>
        /// <param name="userId">User ID. By default, the current user ID.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="listId">ID of the friend list returned by the <see cref="GetLists"/> method to be used as the source. This parameter is taken into account only when the uid parameter is set to the current user ID. </param>
        /// <param name="count">Number of friends to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of friends.</param>
        /// <param name="fields">Profile fields to return.</param>
        /// <param name="nameCase">Case for declension of user name and surname.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<ItemsList<User>>> Get(int? userId = null, FriendsOrder order = FriendsOrder.Hints,
            int? listId = null, int? count = null, int offset = 0, List<UserProfileFields> fields = null,
            NameCases nameCase = NameCases.Nominative)
            => await Request<ItemsList<User>>("get", new MethodParams
            {
                {"user_id", userId},
                {"order", Utils.ToEnumString(order)},
                {"list_id", listId},
                {"count", count},
                {"offset", offset},
                {
                    "fields",
                    fields == null || !fields.Any() ? new List<UserProfileFields> {UserProfileFields.Nickname} : fields
                },
                {"name_case", Utils.ToEnumString(nameCase)}
            }, true);

        /// <summary>
        /// Returns a list of user IDs of a user's friends who are online.
        /// </summary>
        /// <param name="userId">User ID. By default, the current user ID.</param>
        /// <param name="listId">Friend list ID. If this parameter is not set, information about all online friends is returned. </param>
        /// <param name="order">Sort order.</param>
        /// <param name="count">Number of friends to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of friends.</param>
        /// <returns>Return an <see cref="OnlineFriends"/> containing info about online fiends.</returns>
        public async Task<Response<OnlineFriends>> GetOnline(int? userId = null, int? listId = null,
            FriendsOrder order = FriendsOrder.Hints, int? count = null, int offset = 0)
            => await Request<OnlineFriends>("getOnline", new MethodParams
            {
                {"user_id", userId},
                {"list_id", listId},
                {"online_mobile", true},
                {"order", Utils.ToEnumString(order)},
                {"count", count},
                {"offset", offset}
            });

        /// <summary>
        /// Returns a list of user IDs of the mutual friends of two users.
        /// </summary>
        /// <param name="targetUids">IDs of the users whose friends will be checked against the friends of the user specified in source_uid.</param>
        /// <param name="sourceUid">ID of the user whose friends will be checked against the friends of the user specified in target_uid.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="count">Number of friends to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of friends.</param>
        /// <returns>Returns a <see cref="MutualFriends"/> object containing info about mutual friends.</returns>
        public async Task<Response<List<MutualFriends>>> GetMutual(List<int> targetUids, int? sourceUid = null,
            FriendsOrder order = FriendsOrder.Hints, int? count = null, int offset = 0)
            => await Request<List<MutualFriends>>("getMutual", new MethodParams
            {
                {"target_uids", string.Join(",", targetUids ?? new List<int>())},
                {"source_uid", sourceUid},
                {"order", Utils.ToEnumString(order)},
                {"count", count},
                {"offset", offset}
            });

        /// <summary>
        /// Returns a list of user IDs of the current user's recently added friends.
        /// </summary>
        /// <param name="count">Number of friends to return.</param>
        /// <returns>Returns a <see cref="List{T}"/> of IDs of the current user's recently added friends sorted in reverse chronological order.</returns>
        public async Task<Response<List<int>>> GetRecent(int count = 100)
            => await Request<List<int>>("getRecent", new MethodParams
            {
                {"count", count, false, new[] {0, 1000}}
            });

        /// <summary>
        /// Returns information about the current user's incoming and outgoing friend requests.
        /// </summary>
        /// <param name="count">Number of requests to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of requests.</param>
        /// <param name="needMutual">True — to return a list of mutual friends (up to 20), if any.</param>
        /// <param name="outcoming">True - to return outgoing requests; False — to return incoming requests(default).</param>
        /// <param name="sortByMutualsCount">True - sort by number of mutual friends; False - sort by date.</param>
        /// <param name="needViewed">False - do not return viewed requests, True — return viewed requests. Ignored for outcoming.</param>
        /// <param name="suggested">True - to return a list of suggested friends; False — to return friend requests(default).</param>
        /// <returns>Returns a <see cref="List{T}"/> if <see cref="FriendRequest"/> object.</returns>
        public async Task<Response<ItemsList<FriendRequest>>> GetRequests(int count = 100, int offset = 0,
            bool needMutual = false, bool outcoming = false, bool sortByMutualsCount = false, bool needViewed = false,
            bool suggested = false) => await Request<ItemsList<FriendRequest>>("getRequests", new MethodParams
            {
                {"count", count, false, new[] {0, 1000}},
                {"offset", offset},
                {"extended", true},
                {"need_mutual", needMutual},
                {"out", outcoming},
                {"sort", sortByMutualsCount},
                {"need_viewed", needViewed},
                {"suggested", suggested}
            });

        /// <summary>
        /// Approves or creates a friend request.
        /// 
        /// If the selected user ID is in the friend request list obtained using the <see cref="GetRequests"/> method,
        /// this method approves the friend request and adds the selected user to the current user's friend list.
        /// Otherwise, this method creates a friend request from the current user to the selected user.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="text">Text of the message (up to 500 characters) for the friend request, if any.</param>
        /// <param name="follow"></param>
        /// <returns>
        /// Returns one of the following values:
        /// 1 — Friend request sent.
        /// 2 — Friend request from the user approved.
        /// 4 — Request resending.
        /// </returns>
        public async Task<Response<int>> Add(int userId, string text = null, bool follow = false)
            => await Request<int>("add", new MethodParams
            {
                {"user_id", userId, true},
                {"text", text},
                {"follow", true}
            });

        /// <summary>
        /// Edits the friend lists of the selected user.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="listIds">IDs of the friend lists to which to add the user.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Edit(int userId, List<int> listIds = null)
            => await Request<bool>("edit", new MethodParams
            {
                {"user_id", userId},
                {"edit", string.Join(",", listIds ?? new List<int>())}
            });

        /// <summary>
        /// Declines a friend request or deletes a user from the current user's friend list.
        /// If the selected user ID is in the friend request list obtained using the <see cref="GetRequests"/> method,
        /// this method declines the friend request. Otherwise, this method deletes the specified user from the friend list
        /// of the current user obtained using the <see cref="Get"/> method.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <returns>
        /// Returns one of the following values:
        /// 1 — User deleted from the current user's friend list.
        /// 2 — Friend request from the user declined.
        /// 3 — Friend request suggestion for the user deleted.
        /// </returns>
        public async Task<Response<FriendDeleteStatus>> Delete(int userId)
            => await Request<FriendDeleteStatus>("delete", new MethodParams
            {
                {"user_id", userId, true}
            });

        /// <summary>
        /// Returns a list of the current user's friend lists.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="returnSystem">True - to return system lists.</param>
        /// <returns>Returns a <see cref="List{T}"/> if <see cref="FriendsList"/> object.</returns>
        public async Task<Response<ItemsList<FriendsList>>> GetLists(int? userId = null, bool returnSystem = true)
            => await Request<ItemsList<FriendsList>>("getLists", new MethodParams
            {
                {"user_id", userId },
                {"return_system", returnSystem }
            });

        /// <summary>
        /// Creates a new friend list for the current user.
        /// </summary>
        /// <param name="name">Name of the friend list.</param>
        /// <param name="userIds">IDs of users to be added to the friend list.</param>
        /// <returns>Returns the ID of the friend list that was created.</returns>
        public async Task<Response<int>> AddList(string name, List<int> userIds = null)
            => await Request<int>("addList", new MethodParams
            {
                {"name", name, true},
                {"userIds", string.Join(",", userIds ?? new List<int>())}
            }, false, "list_id");

        /// <summary>
        /// Edits a friend list of the current user.
        /// </summary>
        /// <param name="listId">Friend list ID.</param>
        /// <param name="name">Name of the friend list.</param>
        /// <param name="userIds">IDs of users in the friend list.</param>
        /// <param name="addUserIds">(Applies if user_ids parameter is not set.) User IDs to add to the friend list.</param>
        /// <param name="deleteUserIds">(Applies if user_ids parameter is not set.) User IDs to delete from the friend list.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditList(int listId, string name = null, List<int> userIds = null,
            List<int> addUserIds = null, List<int> deleteUserIds = null)
            => await Request<bool>("editList", new MethodParams
            {
                {"list_id", listId, true},
                {"name", name},
                {"user_ids", string.Join(",", userIds ?? new List<int>())},
                {"add_user_ids", string.Join(",", addUserIds ?? new List<int>())},
                {"delete_user_ids", string.Join(",", deleteUserIds ?? new List<int>())}
            });

        /// <summary>
        /// Deletes a friend list of the current user.
        /// </summary>
        /// <param name="listId">Friend list ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DeleteList(int listId)
            => await Request<bool>("deleteList", new MethodParams
            {
                {"list_id", listId, true}
            });

        /// <summary>
        /// Returns a list of IDs of the current user's friends who installed the application.
        /// </summary>
        /// <returns>Returns a list of IDs of the current user's friends who installed the application.</returns>
        public async Task<Response<List<int>>> GetAppUsers() => await Request<List<int>>("getAppUsers");

        /// <summary>
        /// Returns a list of the current user's friends whose phone numbers, validated or specified in a profile,
        /// are in a given list.
        /// 
        /// This method can be used only if the current user's mobile phone number is validated. To check the validation,
        /// use the <see cref="Get"/> method with user_ids=API_USER and fields=has_mobile parameters
        /// where API_USER is equal to the current user ID.
        /// </summary>
        /// <param name="phones">
        /// List of phone numbers in MSISDN format (maximum 1000).
        /// Example:
        /// <example>+79219876543,+79111234567</example>
        /// </param>
        /// <param name="fields">Profile fields to return.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<List<User>>> GetByPhones(List<string> phones, List<UserProfileFields> fields = null)
            => await Request<List<User>>("getByPhones", new MethodParams
            {
                {"phones", phones, true},
                {"fields", fields}
            });

        /// <summary>
        /// Marks all incoming friend requests as viewed.
        /// </summary>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DeleteAllRequests() => await Request<bool>("deleteAllRequests");

        /// <summary>
        /// Returns a list of profiles of users whom the current user may know.
        /// </summary>
        /// <param name="filter">Types of potential friends to return.</param>
        /// <param name="count">Number of suggestions to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of suggestions.</param>
        /// <param name="fields">Profile fields to return.</param>
        /// <param name="nameCase">Case for declension of user name and surname.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<ItemsList<User>>> GetSuggestions(
            FriendSuggestionsTypes filter = FriendSuggestionsTypes.All, int count = 500, int offset = 0,
            List<UserProfileFields> fields = null, NameCases nameCase = NameCases.Nominative)
            => await Request<ItemsList<User>>("getSuggestions", new MethodParams
            {
                {"filter", filter == FriendSuggestionsTypes.All ? null : Utils.ToEnumString(filter)},
                {"count", count, false, new[] {0, 500}},
                {"offset", offset},
                {"fields", fields},
                {"name_case", Utils.ToEnumString(nameCase)}
            });

        /// <summary>
        /// Checks the current user's friendship status with other specified users.
        /// Also returns information specifying whether there is an outgoing or incoming friend request(new follower).
        /// </summary>
        /// <param name="userIds">IDs of the users whose friendship status to check.</param>
        /// <param name="needSign">Whether to return <see cref="FriendshipStatus.Sign"/> property.</param>
        /// <returns>Returns a <see cref="List{T}"/> if <see cref="FriendshipStatus"/> object.</returns>
        public async Task<Response<List<FriendshipStatus>>> AreFriends(List<int> userIds, bool needSign = false)
            => await Request<List<FriendshipStatus>>("areFriends", new MethodParams
            {
                {"user_ids", userIds, true},
                {"need_sign", needSign}
            });

        /// <summary>
        /// Gets the list of user Ids that can be called using <c>callUser</c> method of <c>JS API</c>.
        /// </summary>
        /// <param name="fields">Profile fields to return.</param>
        /// <param name="nameCase">Case for declension of user name and surname.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<ItemsList<User>>> GetAvailableForCall(List<UserProfileFields> fields = null,
            NameCases nameCase = NameCases.Nominative)
            => await Request<ItemsList<User>>("getAvailableForCall", new MethodParams
            {
                {"name_case", Utils.ToEnumString(nameCase)},
                {
                    "fields", fields != null && fields.Any() ? fields : new List<UserProfileFields> {UserProfileFields.Sex}
                }
            });

        /// <summary>
        /// Allows to search through the list of user's friends.
        /// For advanced search through the list of friends, you can use a method <see cref="UsersMethods.Search(UsersSearchParams)"/> with a parameter from_list = friends.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="q">Query string.</param>
        /// <param name="count">Number of users to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of users.</param>
        /// <param name="fields">Profile fields to return.</param>
        /// <param name="nameCase">Case for declension of user name and surname.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<ItemsList<User>>> Search(int userId, string q = null, int count = 20, int offset = 0,
            List<UserProfileFields> fields = null, NameCases nameCase = NameCases.Nominative)
            => await Request<ItemsList<User>>("search", new MethodParams
            {
                {"user_id", userId, true},
                {"q", q},
                {"count", count, false, new[] {0, 1000}},
                {"offset", offset},
                {"fields", fields},
                {"name_case", Utils.ToEnumString(nameCase)}
            });

        #endregion
    }
}