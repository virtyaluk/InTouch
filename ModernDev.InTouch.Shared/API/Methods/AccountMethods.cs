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
using ModernDev.InTouch.API;
using ModernDev.InTouch.Helpers;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A base class for managing account info.
    /// </summary>
    public class AccountMethods : MethodsGroup
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal AccountMethods(InTouch api) : base(api, "account") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns non-null values of user counters.
        /// </summary>
        /// <param name="filter">Counters information of which shall be returned.</param>
        /// <returns>Returns a <see cref="AccountCounters"/> object with counters info.</returns>
        public async Task<Response<AccountCounters>> GetCounters(List<CountersFilterTypes> filter = null)
            => await Request<AccountCounters>("getCounters", new MethodParams
            {
                {"filter", filter}
            });

        /// <summary>
        /// Sets an application screen name (up to 17 characters), that is shown to the user in the left menu.
        /// This happens only in case the user added such application in the left menu from application page, from list of applications and settings.
        /// </summary>
        /// <param name="userId">User ID. </param>
        /// <param name="name">Application screen name.</param>
        /// <returns>If the method is successfully executed, True will be returned.</returns>
        public async Task<Response<bool>> SetNameInMenu(int userId, string name)
            => await Request<bool>("setNameInMenu", new MethodParams
            {
                {"user_id", userId, true},
                {"name", name?.Substring(0, name.Length > 17 ? 17 : name.Length), true}
            });

        /// <summary>
        /// Marks the current user as online for 15 minutes.
        /// </summary>
        /// <param name="voip">Whether the video calls are possible for this device.</param>
        /// <returns>If the method is successfully executed, True will be returned.</returns>
        public async Task<Response<bool>> SetOnline(bool voip = false)
            => await Request<bool>("setOnline", new MethodParams {{"voip", voip}});

        /// <summary>
        /// Marks a current user as Offline.
        /// </summary>
        /// <returns>In case of success returns True.</returns>
        public async Task<Response<bool>> SetOffline() => await Request<bool>("setOffline");

        /// <summary>
        /// Allows to search the VK users using phone numbers, e-mail addresses and user IDs on other services.
        /// You may get these users by <see cref="FriendsMethods.GetSuggestions"/> method as well.
        /// </summary>
        /// <param name="service">Identifier of a service which contacts are used for searching.</param>
        /// <param name="contacts">List of contacts.</param>
        /// <param name="myContact">Contact of a current user on a specified service.</param>
        /// <param name="returnAll">True – also return contacts found using this service before, False – return only contacts found using <c>contacts</c> field. </param>
        /// <param name="fields">List of a profile fields to return.</param>
        /// <returns>Returns a <see cref="Contacts"/> objects containing found contacts.</returns>
        public async Task<Response<Contacts>> LookupContacts(Services service, List<string> contacts = null,
            string myContact = null, bool returnAll = false, List<UserProfileFields> fields = null)
            => await Request<Contacts>("lookupContacts", new MethodParams
            {
                {"service", Utils.ToEnumString(service)},
                {"contacts", contacts},
                {"mycontact", myContact},
                {"return_all", returnAll},
                {"fields", fields}
            });

        /// <summary>
        /// Subscribes a device to receive push notifications
        /// </summary>
        /// <param name="token">Device token used to send notifications. (for mpns, the token shall be URL for sending of notifications).</param>
        /// <param name="deviceId">>Unique device identifier.</param>
        /// <param name="settings">JSON object that describes notification settings in a special format.</param>
        /// <param name="deviceModel">Device model.</param>
        /// <param name="deviceYear">Device year.</param>
        /// <param name="systemVersion">Device system version.</param>
        /// <returns>If the method is successfully executed, True will be returned.</returns>
        public async Task<Response<bool>> RegisterDevice(string token, string deviceId, string settings = null,
            string deviceModel = null, int? deviceYear = null, string systemVersion = null)
            => await Request<bool>("registerDevice", new MethodParams
            {
                {"token", token, true},
                {"device_id", deviceId},
                {"device_model", deviceModel},
                {"settings", settings},
                {"device_year", deviceYear},
                {"system_version", systemVersion}
            });

        /// <summary>
        /// Unsubscribes a device from push notifications.
        /// </summary>
        /// <remarks>
        /// You need the following rights to call this method: <see cref="AccessPermissions.Messages"/>.
        /// </remarks>
        /// <param name="deviceId">Unique device identifier.</param>
        /// <returns>Returns True if the method is successfully executed.</returns>
        public async Task<Response<bool>> UnregisterDevice(string deviceId)
            => await Request<bool>("unregisterDevice", new MethodParams {{"device_id", deviceId, true}});

        /// <summary>
        /// Mutes in parameters of sent push notifications for the set period of time.
        /// </summary>
        /// <param name="deviceId">>Unique device identifier.</param>
        /// <param name="time">The time in seconds for which you want to disable notifications; -1 to disable forever.</param>
        /// <param name="peerId">
        /// Peer Id:
        /// for users - UserId;
        /// for chat - 2000000000 + ChatId;
        /// for community - -GroupId
        /// </param>
        /// <param name="enableSound">True - enable sound in the dialog; False - disable. (Works only if peerId is ChatId).</param>
        /// <returns>If the method is successfully executed, True will be returned.</returns>
        public async Task<Response<bool>> SetSilenceMode(string deviceId = null, int time = 360, int? peerId = null,
            bool enableSound = false) => await Request<bool>("setSilenceMode", new MethodParams
            {
                {"device_id", deviceId},
                {"time", time},
                {"peer_id", peerId},
                {"sound", enableSound}
            });

        /// <summary>
        /// Gets settings of push notifications.
        /// </summary>
        /// <param name="deviceId">>Unique device identifier.</param>
        /// <returns>Returns a <see cref="NotificationsSettings"/> object containing push settings.</returns>
        public async Task<Response<NotificationsSettings>> GetPushSettings(string deviceId)
            => await Request<NotificationsSettings>("getPushSettings", new MethodParams
            {
                {"device_id", deviceId, true}
            });

        /// <summary>
        /// Sets settings of push notifications.
        /// </summary>
        /// <param name="deviceId">>Unique device identifier.</param>
        /// <param name="settings">JSON object that describes notification settings in a special format.</param>
        /// <param name="key">Notification key.</param>
        /// <param name="value">New notification value in special format.</param>
        /// <returns>If the method is successfully executed, True will be returned.</returns>
        public async Task<Response<bool>> SetPushSettings(string deviceId, string settings = null, string key = null,
            List<string> value = null) => await Request<bool>("setPushSettings", new MethodParams
            {
                {"device_id", deviceId, true},
                {"settings", settings},
                {"key", key},
                {"value", value}
            });

        /// <summary>
        /// Gets settings of the current user in this application.
        /// </summary>
        /// <param name="userId">User ID whose settings information shall be got. By default, current user.</param>
        /// <returns>When executed successfully it returns a bit mask of current user's settings in this application. </returns>
        public async Task<Response<int>> GetAppPermissions(int userId)
            => await Request<int>("getAppPermissions", new MethodParams {{"user_id", userId, true, UserIdsRange}});

        /// <summary>
        /// Adds user to the banlist.
        /// </summary>
        /// <remarks>
        /// If specified user is a friend of current user or have incoming or outcoming friend request with him,
        /// your app need following rights to use this method: <see cref="AccessPermissions.Friends"/>.
        /// </remarks>
        /// <param name="userId">User ID.</param>
        /// <returns>When executed successfully it returns True.</returns>
        public async Task<Response<bool>> BanUser(int userId)
            => await Request<bool>("banUser", new MethodParams {{"user_id", userId, true, UserIdsRange}});

        /// <summary>
        /// Deletes user from the banlist.
        /// </summary>
        /// <param name="userId">User ID. </param>
        /// <returns>When executed successfully it returns True.</returns>
        public async Task<Response<bool>> UnbanUser(int userId)
            => await Request<bool>("unbanUser", new MethodParams {{"user_id", userId, true, UserIdsRange}});

        /// <summary>
        /// Returns a user's blacklist.
        /// </summary>
        /// <param name="offset">Offset required to select a certain subset of users. By default — 0.</param>
        /// <param name="count">Number of users, information of which shall be returned. By default - 20</param>
        /// <returns>Returns a list of <see cref="User"/> with info about users who are in the current user's blacklist.</returns>
        public async Task<Response<ItemsList<User>>> GetBanned(int? offset = null, int count = 20)
            => await Request<ItemsList<User>>("getBanned", new MethodParams
            {
                {"offset", offset},
                {"count", count, false, Tuple.Create(0, 200)}
            });

        /// <summary>
        /// Returns current account info.
        /// </summary>
        /// <param name="fields">The list of <see cref="AccountInfoFields"/> that need to be returned.</param>
        /// <returns>Method returns an <see cref="AccountInfo"/> object.</returns>
        public async Task<Response<AccountInfo>> GetInfo(List<AccountInfoFields> fields = null)
            => await Request<AccountInfo>("getInfo", new MethodParams {{"fields", fields}});

        /// <summary>
        /// Allows to edit the current account info.
        /// </summary>
        /// <param name="intro">Bit mask responsible for passing the tutorial in mobile clients. </param>
        /// <param name="ownPostsDefault">True, if only user's posts should be displayed on the user's wall; False, for all posts.</param>
        /// <param name="noWallreplies">True - disable wall posts commenting, False - allow commenting.</param>
        /// <returns>If the method is successfully executed, code True will be returned.</returns>
        public async Task<Response<bool>> SetInfo(int intro = 0, bool ownPostsDefault = true, bool noWallreplies = true)
            => await Request<bool>("setInfo", new MethodParams
            {
                {"intro", intro},
                {"own_posts_default", ownPostsDefault},
                {"no_wall_replies", noWallreplies}
            });

        /// <summary>
        /// Changes a user password after access is successfully restored with the <see cref="AuthMethods.Restore"/> method.
        /// </summary>
        /// <param name="newPassword">New password that will be set as a current.</param>
        /// <param name="oldPassword">Current user password.</param>
        /// <param name="restoreSid">Session id received after the <see cref="AuthMethods.Restore"/> method is executed. (If the password is changed right after the access was restored) </param>
        /// <param name="changePasswordHash">Hash received after a successful OAuth authorization with a code got by SMS. (If the password is changed right after the access was restored) </param>
        /// <returns>If the method is successfully executed, returns a new token.</returns>
        public async Task<Response<string>> ChangePassword(string newPassword, string oldPassword = null,
            string restoreSid = null, string changePasswordHash = null)
            => await Request<string>("changePassword", new MethodParams
            {
                {"new_password", newPassword, true},
                {"old_password", oldPassword},
                {"change_password_hash", changePasswordHash},
                {"restore_sid", restoreSid}
            }, false, "token");

        /// <summary>
        /// Returns the current account info.
        /// </summary>
        /// <remarks>
        /// To get info from other user's profile or to work without authorization use <see cref="UsersMethods.Get"/>.
        /// </remarks>
        /// <returns>Method returns a <see cref="ProfileInfo"/> object.</returns>
        public async Task<Response<ProfileInfo>> GetProfileInfo() => await Request<ProfileInfo>("getProfileInfo");

        /// <summary>
        /// Edits current profile info.
        /// </summary>
        /// <param name="methodParams">A <see cref="AccountSaveProfileInfoParams"/> object with the params.</param>
        /// <returns>Returns the saving status in <see cref="NewProfileInfoSavingStatus"/> object.</returns>
        public async Task<Response<NewProfileInfoSavingStatus>> SaveProfileInfo(
            AccountSaveProfileInfoParams methodParams)
            => await Request<NewProfileInfoSavingStatus>("saveProfileInfo", methodParams);

        #endregion
    }
}