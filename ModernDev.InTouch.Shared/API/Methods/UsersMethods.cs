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
using static ModernDev.InTouch.Helpers.Utils;

namespace ModernDev.InTouch
{
    public class UsersMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        public UsersMethods(InTouch api) : base(api, "users") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns detailed information on users.
        /// </summary>
        /// <param name="userIds">User IDs or screen names (screen_name). By default, current user ID.</param>
        /// <param name="fields">Profile fields to return.</param>
        /// <param name="nameCase">Case for declension of user name and surname.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<List<User>>> Get(List<object> userIds = null, List<UserProfileFields> fields = null,
            NameCases nameCase = NameCases.Nominative) => await Request<List<User>>("get", new MethodParams
            {
                {"user_ids", userIds?.Where(uid => uid is int || uid is string).ToList(), false, 1000},
                {"fields", fields},
                {"name_case", nameCase}
            }, true);

        /// <summary>
        /// Returns a list of users matching the search criteria.
        /// </summary>
        /// <param name="searchParams"><see cref="UsersSearchParams"/> object containing search params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<ItemsList<User>>> Search(UsersSearchParams searchParams = null)
            => await Request<ItemsList<User>>("search", searchParams);

        /// <summary>
        /// Returns a list of users matching the search criteria.
        /// </summary>
        /// <param name="query">Search query string.</param>
        /// <param name="offset">Offset needed to return a specific subset of users.</param>
        /// <param name="count">Number of users to return. </param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<ItemsList<User>>> Search(string query, int offset = 0, int count = 20)
            => await Search(new UsersSearchParams {Query = query, Count = count, Offset = offset});

        /// <summary>
        /// Returns information whether a user installed the application.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <returns>Returns True if the user installed the application; otherwise returns False.</returns>
        public async Task<Response<bool>> IsAppUser(int? userId = null)
            => await Request<bool>("isAppUser", new MethodParams { {"user_id", userId, false, UserIdsRange} });

        /// <summary>
        /// Returns a list of IDs of users and communities followed by the user.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="count">Number of users and communities to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of subscriptions.</param>
        /// <returns>Returns a <see cref="UserSubscriptions"/> object containing Ids users/communities followed by the user.</returns>
        public async Task<Response<UserSubscriptions>> GetSubscriptions(int? userId = null, int count = 20,
            int offset = 0) => await Request<UserSubscriptions>("getSubscriptions", new MethodParams
            {
                {"user_id", userId},
                {"count", count, false, new[] {0, 200}},
                {"offset", offset}
            }, true);

        /// <summary>
        /// Returns a list of IDs of users and communities followed by the user.
        /// </summary>
        /// <param name="userId">User ID. </param>
        /// <param name="count">Number of users and communities to return. </param>
        /// <param name="offset">Offset needed to return a specific subset of subscriptions.</param>
        /// <param name="fields">A list of profiles fields to return. Accepts <see cref="UserProfileFields"/>, <see cref="GroupProfileFields"/> and regular string.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> and <see cref="Group"/> objects.</returns>
        public async Task<Response<MixedProfilesList>> GetSubscriptionExtended(int? userId = null,
            int count = 20, int offset = 0, List<string> fields = null)
            => await Request<MixedProfilesList>("getSubscriptions", new MethodParams
            {
                {"user_id", userId},
                {"count", count, false, new[] {0, 200}},
                {"offset", offset},
                {"extended", true},
                {"fields", string.Join(",", (fields ?? new List<string>()).Where(str => !string.IsNullOrEmpty(str)))}
            }, true);

        /// <summary>
        /// Returns a list of IDs of users and communities followed by the user.
        /// </summary>
        /// <param name="userId">User ID. </param>
        /// <param name="count">Number of users and communities to return. </param>
        /// <param name="offset">Offset needed to return a specific subset of subscriptions.</param>
        /// <param name="fields">A list of profiles fields to return. Accepts <see cref="UserProfileFields"/>, <see cref="GroupProfileFields"/> and regular string.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> and <see cref="Group"/> objects.</returns>
        public async Task<Response<MixedProfilesList>> GetSubscriptionExtended(int? userId = null,
            int count = 20, int offset = 0, List<object> fields = null)
            => await GetSubscriptionExtended(userId, count, offset, fields?
                .Where(el => el != null && (el is UserProfileFields || el is GroupProfileFields || el is string))
                .Select(el => el is string ? $"{el}" : ToEnumString(el)).ToList());

        /// <summary>
        /// Returns a list of IDs of followers of the user in question, sorted by date added, most recent first.
        /// </summary>
        /// <param name="getFollowersParams"><see cref="UsersGetFollowersParams"/> object containing method params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<ItemsList<User>>> GetFollowers(UsersGetFollowersParams getFollowersParams = null)
            => await Request<ItemsList<User>>("getFollowers", getFollowersParams, true);

        /// <summary>
        /// Returns a list of IDs of followers of the user in question, sorted by date added, most recent first.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="offset">Offset needed to return a specific subset of followers.</param>
        /// <param name="count">Number of followers to return. </param>
        /// <param name="fields">Profile fields to return.</param>
        /// <param name="nameCase">Case for declension of user name and surname.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<ItemsList<User>>> GetFollowers(int? userId = null, int? offset = 0, int? count = 100,
            List<UserProfileFields> fields = null, NameCases nameCase = NameCases.Nominative)
            => await GetFollowers(new UsersGetFollowersParams
            {
                UserId = userId,
                Offset = offset,
                Count = count,
                NameCase = nameCase,
                Fields = fields
            });

        /// <summary>
        /// Reports (submits a complain about) a user. 
        /// </summary>
        /// <param name="userId">ID of the user about whom a complaint is being made</param>
        /// <param name="type">Type of complaint.</param>
        /// <param name="comment">Comment describing the complaint.</param>
        /// <returns>When executed successfully it returns True.</returns>
        public async Task<Response<bool>> Report(int userId, ReportTypes type, string comment = "")
            => await Request<bool>("report", new MethodParams
            {
                {"user_id", userId, true, UserIdsRange},
                {"type", type},
                {"comment", comment}
            });

        /// <summary>
        /// Indexes user's current location and returns a list of users who are located near.
        /// </summary>
        /// <param name="coords">Geographical coordinates including <see cref="Coordinates.Radius"/> and <see cref="Coordinates.Accuracy"/>.</param>
        /// <param name="timeout">Time when a user disappears from location search results, in seconds.</param>
        /// <param name="fields">List of additional fields to return.</param>
        /// <param name="nameCase">Case for declension of user name and surname.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<ItemsList<User>>> GetNearby(Coordinates coords, int timeout = 7200,
            List<UserProfileFields> fields = null, NameCases nameCase = NameCases.Nominative)
            => await Request<ItemsList<User>>("getNearby", new MethodParams
            {
                {"latitude", coords?.Latitude, true},
                {"longitude", coords?.Longitude, true},
                {"radius", coords?.Radius},
                {"accuracy", coords?.Accuracy},
                {"timeout", timeout},
                {"name_case", ToEnumString(nameCase)},
                {"fields", fields}
            });

        #endregion
    }
}