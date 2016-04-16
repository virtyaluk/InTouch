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

namespace ModernDev.InTouch
{
    /// <summary>
    /// A base class for working with communities.
    /// </summary>
    public class GroupsMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupsMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal GroupsMethods(InTouch api) : base(api, "groups") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns information specifying whether a user is a member of a community.
        /// </summary>
        /// <param name="groupId">ID or screen name of the community. </param>
        /// <param name="userId">User Id.</param>
        /// <returns>Returns a <see cref="GroupMembershipStatus"/> object with related information.</returns>
        public async Task<Response<GroupMembershipStatus>> IsMember(object groupId, int? userId = null)
            => await Request<GroupMembershipStatus>("isMember", new MethodParams
            {
                {"group_id", groupId, true},
                {"extended", true},
                {"user_id", userId}
            }, true);

        /// <summary>
        /// Returns information specifying whether users is members of a community.
        /// </summary>
        /// <param name="groupId">ID or screen name of the community. </param>
        /// <param name="userIds">User Ids.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="GroupMembershipStatus"/> objects.</returns>
        public async Task<Response<List<GroupMembershipStatus>>> IsMembers(object groupId, List<int> userIds)
            => await Request<List<GroupMembershipStatus>>("isMember", new MethodParams
            {
                {"group_id", groupId, true},
                {"extended", true},
                {"user_ids", userIds}
            }, true);

        /// <summary>
        /// Returns information about communities by their IDs.
        /// </summary>
        /// <param name="groupIds">IDs or screen names of communities.</param>
        /// <param name="fields">Group fields to return. </param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Group"/> objects.</returns>
        public async Task<Response<List<Group>>> GetById(List<object> groupIds, List<GroupProfileFields> fields = null)
            => await Request<List<Group>>("getById", new MethodParams
            {
                {"group_ids", groupIds},
                {"fields", fields}
            }, true);

        /// <summary>
        /// Returns a list of the communities to which a user belongs.
        /// </summary>
        /// <param name="methodParams"><see cref="GroupsGetParams"/> object containing method params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Group"/> objects.</returns>
        public async Task<Response<ItemsList<Group>>> Get(GroupsGetParams methodParams)
            => await Request<ItemsList<Group>>("get", methodParams);

        /// <summary>
        /// Returns a list of community members.
        /// </summary>
        /// <param name="methodParams"><see cref="UsersGetFollowersParams"/> object containing method params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<ItemsList<User>>> GetMembers(GroupsGetMembersParams methodParams)
            => await Request<ItemsList<User>>("getMembers", methodParams, true);

        /// <summary>
        /// With this method you can join the group or public page, and also confirm your participation in an event.
        /// </summary>
        /// <param name="groupId">ID or screen name of the community. </param>
        /// <param name="notSure">Optional parameter which is taken into account when gid belongs to the event: True — Perhaps I will attend; False — I will be there for sure(default) </param>
        /// <returns>Returns True if the user installed the application; otherwise returns False.</returns>
        public async Task<Response<bool>> Join(object groupId = null, bool notSure = false)
            => await Request<bool>("join", new MethodParams
            {
                {"group_id", groupId?.ToString()},
                {"not_sure", notSure}
            });

        /// <summary>
        /// With this method you can leave a group, public page, or event.
        /// </summary>
        /// <param name="groupId">ID or screen name of the community.</param>
        /// <returns>Returns True if the user installed the application; otherwise returns False.</returns>
        public async Task<Response<bool>> Leave(object groupId) => await Request<bool>("leave",
            new MethodParams
            {
                {"group_id", groupId}
            });

        /// <summary>
        /// Searches for communities by substring.
        /// </summary>
        /// <param name="methodParams"><see cref="GroupsSearchParams"/> object containing method params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Group"/> objects.</returns>
        public async Task<Response<ItemsList<Group>>> Search(GroupsSearchParams methodParams)
            => await Request<ItemsList<Group>>("search", methodParams);

        /// <summary>
        /// Returns communities list for a catalog category.
        /// </summary>
        /// <param name="categoryId">Category id received from <see cref="GetCatalogInfo"/>.</param>
        /// <param name="subcategoryId"></param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Group"/> objects.</returns>
        public async Task<Response<ItemsList<Group>>> GetCatalog(int? categoryId = null, int? subcategoryId = null)
            => await Request<ItemsList<Group>>("getCatalog", new MethodParams
            {
                {"category_id", categoryId},
                {"subcategory_id", subcategoryId}
            });

        /// <summary>
        /// Returns categories list for communities catalog.
        /// </summary>
        /// <param name="extended">True - return communities count and three communities for preview.</param>
        /// <param name="subcategories">True - return subcategories info.</param>
        /// <returns>Returns an object containing catalog categories.</returns>
        public async Task<Response<GroupCatalogInfo>> GetCatalogInfo(bool extended = true, bool subcategories = false)
            => await Request<GroupCatalogInfo>("getCatalogInfo", new MethodParams
            {
                {"extended", extended},
                {"subcategories", subcategories}
            });

        /// <summary>
        /// Returns a list of invitations to join communities and events.
        /// </summary>
        /// <param name="count">Number of invitations to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of invitations. </param>
        /// <param name="extended">True - to return additional information about those who sent invites.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Group"/> objects.</returns>
        public async Task<Response<ItemsList<Group>>> GetInvites(int count = 20, int offset = 0, bool extended = true)
            => await Request<ItemsList<Group>>("getInvites", new MethodParams
            {
                {"count", count},
                {"offset", offset},
                {"extended", extended}
            });

        /// <summary>
        /// Returns invited users list of a community.
        /// </summary>
        /// <param name="groupId">Group id to return invited users for.</param>
        /// <param name="count">Count of users to return.</param>
        /// <param name="offset">Offset to select a certain subset of users.</param>
        /// <param name="fields">Additional fields list to return.</param>
        /// <param name="nameCase">Case for declension of user name and surname.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<ItemsList<User>>> GetInvitedUsers(int groupId, int count = 20, int offset = 0,
            List<UserProfileFields> fields = null, NameCases nameCase = NameCases.Nominative)
            => await Request<ItemsList<User>>("getInvitedUsers", new MethodParams
            {
                {"group_id", groupId, true},
                {"offset", offset},
                {"count", count},
                {"fields", fields},
                {"name_case", nameCase}
            });

        /// <summary>
        /// Adds a user to a community blacklist.
        /// </summary>
        /// <param name="groupId">Community ID.</param>
        /// <param name="userId">User ID.</param>
        /// <param name="endDate">Date when the user will be removed from the blacklist.</param>
        /// <param name="reason">Reason for ban.</param>
        /// <param name="comment">Text of comment to ban.</param>
        /// <param name="commentVisible">True — text of comment will be visible to the user; False — text of comment will be invisible to the user(default)</param>
        /// <returns>Returns True if the user installed the application; otherwise returns False.</returns>
        public async Task<Response<bool>> BanUser(int groupId, int userId, DateTime? endDate = null,
            BanTypes reason = BanTypes.Other, string comment = null, bool commentVisible = false)
            => await Request<bool>("banUser", new MethodParams
            {
                {"group_id", groupId, true},
                {"user_id", userId, true},
                {"end_date", endDate?.ToUnixTimeStamp()},
                {"reason", (int) reason},
                {"comment", comment},
                {"comment_visible", commentVisible}
            });

        /// <summary>
        /// Deletes a user from a community blacklist.
        /// </summary>
        /// <param name="groupId">Community ID.</param>
        /// <param name="userId">User ID.</param>
        /// <returns>Returns True if the user installed the application; otherwise returns False.</returns>
        public async Task<Response<bool>> UnbanUser(int groupId, int userId)
            => await Request<bool>("unbanUser", new MethodParams
            {
                {"group_id", groupId},
                {"user_id", userId}
            });

        /// <summary>
        /// Returns a list of users on a community blacklist.
        /// </summary>
        /// <param name="groupId">Community ID.</param>
        /// <param name="count">Number of users to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of users.</param>
        /// <param name="fields">Additional profile fields list to return.</param>
        /// <param name="userId">User ID.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<ItemsList<User>>> GetBanned(int groupId, int count = 20, int offset = 0,
            List<UserProfileFields> fields = null, int? userId = null)
            => await Request<ItemsList<User>>("getBanned", new MethodParams
            {
                {"group_id", groupId, true},
                {"offset", offset},
                {"count", count, false, new[] {0, 200}},
                {"fields", fields},
                {"user_id", userId}
            });

        /// <summary>
        /// Creates a new community.
        /// </summary>
        /// <param name="title">Community title.</param>
        /// <param name="description">Community description (ignored if type is <see cref="CommunityTypes.Public"/>).</param>
        /// <param name="type">Community type.</param>
        /// <param name="subtype">Public page subtype.</param>
        /// <returns>Returns an id of a created community.</returns>
        public async Task<Response<Group>> Create(string title, string description = null,
            CommunityTypes type = CommunityTypes.Public, CommunitySubtypes? subtype = null)
            => await Request<Group>("create", new MethodParams
            {
                {"title", title, true},
                {"description", description},
                {"type", Utils.ToEnumString(type)},
                {"subtype", subtype.HasValue ? (int) subtype : 1}
            });

        /// <summary>
        /// Edits a community.
        /// <remarks>You must be a community administrator to use this method</remarks>
        /// </summary>
        /// <param name="methodParams"><see cref="GroupsEditParams"/> object containing method params.</param>
        /// <returns>Returns True if the user installed the application; otherwise returns False.</returns>
        public async Task<Response<bool>> Edit(GroupsEditParams methodParams)
            => await Request<bool>("edit", methodParams);

        /// <summary>
        /// Edits community's place.
        /// </summary>
        /// <param name="methodParams"><see cref="GroupsEditPlaceParams"/> object containing method params.</param>
        /// <returns>Returns a <see cref="PlaceStatus"/> object containing editing status.</returns>
        public async Task<Response<PlaceStatus>> EditPlace(GroupsEditPlaceParams methodParams)
            => await Request<PlaceStatus>("editPlace", methodParams);

        /// <summary>
        /// Gets the data needed to display community's settings page.
        /// </summary>
        /// <param name="groupId">Community ID.</param>
        /// <returns>Returns a <see cref="CommunitySettings"/> object containing community settings.</returns>
        public async Task<Response<CommunitySettings>> GetSettings(int groupId)
            => await Request<CommunitySettings>("getSettings", new MethodParams
            {
                {"group_id", groupId, true}
            });

        /// <summary>
        /// Returns a list of users that have sent request to join the community
        /// </summary>
        /// <param name="groupId">Community ID.</param>
        /// <param name="count">Number of users to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of users.</param>
        /// <param name="fields">Additional profile fields to return.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<ItemsList<User>>> GetRequests(int groupId, int count = 20, int offset = 0,
            List<UserProfileFields> fields = null) => await Request<ItemsList<User>>("getRequests", new MethodParams
            {
                {"group_id", groupId},
                {"count", count, false, new[] {0, 200}},
                {"offset", offset},
                {"fields", fields}
            });

        /// <summary>
        /// Allows to assign or demote community's manager, or to change the level of the existing manager.
        /// </summary>
        /// <param name="methodParams"><see cref="GroupsEditManagerParams"/> object containing method params.</param>
        /// <returns>Returns True if the user installed the application; otherwise returns False.</returns>
        public async Task<Response<bool>> EditManager(GroupsEditManagerParams methodParams)
            => await Request<bool>("editManager", methodParams);

        /// <summary>
        /// Invites an user to the community.
        /// </summary>
        /// <param name="groupId">Community ID.</param>
        /// <param name="userId">User Id.</param>
        /// <returns>Returns True if the user installed the application; otherwise returns False.</returns>
        public async Task<Response<bool>> Invite(int groupId, int userId)
            => await Request<bool>("invite", new MethodParams
            {
                {"user_id", userId, true},
                {"group_id", groupId, true}
            });

        /// <summary>
        /// Adds a link to the community.
        /// </summary>
        /// <param name="groupId">Community ID.</param>
        /// <param name="link">Link URL.</param>
        /// <param name="text">Link text.</param>
        /// <returns>Returns a <see cref="CommunityLink"/> containing newly created link info.</returns>
        public async Task<Response<CommunityLink>> AddLink(int groupId, string link, string text = null)
            => await Request<CommunityLink>("addLink", new MethodParams
            {
                {"group_id", groupId, true},
                {"link", link, true},
                {"text", text}
            });

        /// <summary>
        /// Deletes the link form the community.
        /// </summary>
        /// <param name="groupId">Community ID.</param>
        /// <param name="linkId">Link Id.</param>
        /// <returns>Returns True if the user installed the application; otherwise returns False.</returns>
        public async Task<Response<bool>> DeleteLink(int groupId, int linkId)
            => await Request<bool>("deleteLink", new MethodParams
            {
                {"group_id", groupId, true},
                {"link_id", linkId, true}
            });

        /// <summary>
        /// Edits the link.
        /// </summary>
        /// <param name="groupId">Community ID.</param>
        /// <param name="linkId">Link Id.</param>
        /// <param name="text">New link text.</param>
        /// <returns>Returns True if the user installed the application; otherwise returns False.</returns>
        public async Task<Response<bool>> EditLink(int groupId, int linkId, string text = null)
            => await Request<bool>("editLink", new MethodParams
            {
                {"group_id", groupId, true},
                {"link_id", linkId, true},
                {"text", text}
            });

        /// <summary>
        /// Changes the order of the link.
        /// </summary>
        /// <param name="groupId">Community ID.</param>
        /// <param name="linkId">Link Id.</param>
        /// <param name="after">Link Id after which you want to place movable link. 0 - if you want to place the link at the top spot.</param>
        /// <returns>Returns True if the user installed the application; otherwise returns False.</returns>
        public async Task<Response<bool>> ReorderLink(int groupId, int linkId, int after = 0)
            => await Request<bool>("reorderLink", new MethodParams
            {
                {"group_id", groupId, true},
                {"link_id", linkId, true},
                {"after", after}
            });

        /// <summary>
        /// Removes a user from the community or rejects appropriate request (if any).
        /// </summary>
        /// <param name="groupId">Community ID.</param>
        /// <param name="userId">User Id.</param>
        /// <returns>Returns True if the user installed the application; otherwise returns False.</returns>
        public async Task<Response<bool>> RemoveUser(int groupId, int userId)
            => await Request<bool>("removeUser", new MethodParams
            {
                {"group_id", groupId, true},
                {"user_id", userId, true}
            });

        /// <summary>
        /// Approves community memberships request.
        /// </summary>
        /// <param name="groupId">Community ID.</param>
        /// <param name="userId">User Id.</param>
        /// <returns>Returns True if the user installed the application; otherwise returns False.</returns>
        public async Task<Response<bool>> ApproveRequest(int groupId, int userId)
            => await Request<bool>("approveRequest", new MethodParams
            {
                {"group_id", groupId, true},
                {"user_id", userId, true}
            });

        #endregion
    }
}