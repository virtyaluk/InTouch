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

namespace ModernDev.InTouch
{
    /// <summary>
    /// Provides a base class for VK secure methods.
    /// </summary>
    public class SecureMethods: MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SecureMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal SecureMethods(InTouch api) : base(api, "secure") { }

        #endregion

        #region Methods

        /// <summary>
        /// Sets user game level in the application which can be seen by his/her friends.
        /// </summary>
        /// <param name="levels">Allows to set levels for several users by one request. Use the following format: user_id1:level1,user_id2:level2, e.g.: 66748:6,6492:2. If this parameter is passed, user_id, level and increment parameters will be ignored.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="level">Level value.</param>
        /// <returns>Returns True if the level is set successfully.</returns>
        public async Task<Response<bool>> SetUserLevel(IEnumerable<string> levels = null, int? userId = null,
            int? level = null)
            => await Request<bool>("setUserLevel", new MethodParams
            {
                {"levels", string.Join(",", levels ?? new[] {""})},
                {"user_id", userId},
                {"level", level}
            }, true);

        /// <summary>
        /// Sets user game level in the application which can be seen by his/her friends.
        /// </summary>
        /// <param name="levels">Allows to set levels for several users by one request. Use the following format: user_id1:level1,user_id2:level2, e.g.: 66748:6,6492:2. If this parameter is passed, user_id, level and increment parameters will be ignored.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="level">Level value.</param>
        /// <returns>Returns True if the level is set successfully.</returns>
        public async Task<Response<bool>> SetUserLevel(Dictionary<string, string> levels = null, int? userId = null,
            int? level = null) => await SetUserLevel(levels?.Select(kvp => $"{kvp.Key}:{kvp.Value}"), userId, level);

        /// <summary>
        /// Sets a counter which is shown to the user in bold in the left menu.
        /// </summary>
        /// <param name="counters">Allows to set counters for several users by one request. Use the following format: user_id1:counter1[:increment],user_id2:counter2[:increment], e.g.: 66748:6:1,6492:2. If this parameter is passed, user_id, counter and increment parameters will be ignored.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="counter">Counter value.</param>
        /// <param name="increment">Determines if counter value should be updated or incremented. True — to increment existing value, False — to update value.</param>
        /// <returns>Returns True if the counter is set successfully. </returns>
        public async Task<Response<bool>> SetCounter(IEnumerable<string> counters = null, int? userId = null,
            int? counter = null, bool increment = false) => await Request<bool>("setCounter", new MethodParams
        {
            {"counters", string.Join(",", counters ?? new[] {""})},
            {"user_id", userId},
            {"counter", counter},
            {"increment", increment}
        }, true);

        /// <summary>
        /// Sets a counter which is shown to the user in bold in the left menu.
        /// </summary>
        /// <param name="counters">Allows to set counters for several users by one request. Use the following format: user_id1:counter1[:increment],user_id2:counter2[:increment], e.g.: 66748:6:1,6492:2. If this parameter is passed, user_id, counter and increment parameters will be ignored. </param>
        /// <param name="userId">User Id.</param>
        /// <param name="counter">Counter value.</param>
        /// <param name="increment">Determines if counter value should be updated or incremented. True — to increment existing value, False — to update value.</param>
        /// <returns>Returns True if the counter is set successfully. </returns>
        public async Task<Response<bool>> SetCounter(Dictionary<string, string> counters = null, int? userId = null,
            int? counter = null, bool increment = false)
            => await SetCounter(counters?.Select(kvp => $"{kvp.Key}:{kvp.Value}"), userId, counter, increment);

        /// <summary>
        /// Sends SMS notification to a user's mobile device.
        /// </summary>
        /// <param name="userId">ID of the user to whom SMS notification is sent. The user shall allow the application to send him/her notifications.</param>
        /// <param name="message">SMS text to be sent in UTF-8 encoding. Only Latin letters and numbers are allowed. Maximum size is 160 characters.</param>
        /// <returns>Returns True if SMS was sent successfully.</returns>
        public async Task<Response<bool>> SendSMSNotification(int userId, string message)
            => await Request<bool>("sendSMSNotification", new MethodParams
            {
                {"user_id", userId},
                {"message", message}
            }, true);

        /// <summary>
        /// Sends notification to the user.
        /// </summary>
        /// <param name="message">Notification text which should be sent in UTF-8 encoding (254 characters maximum).</param>
        /// <param name="userIds">IDs of users to whom notification is sent (100 maximum).</param>
        /// <param name="userId">User Id.</param>
        /// <returns>Returns IDs of users to whom notification was successfully sent.</returns>
        public async Task<Response<List<int>>> SendNotification(string message, List<int> userIds = null,
            int? userId = null) => await Request<List<int>>("sendNotification", new MethodParams
        {
            {"message", message},
            {"user_ids", userIds},
            {"user_id", userId}
        }, true);

        // TODO: getUserLevel

        // TODO: getTransactionsHistory

        // TODO: getSMSHistory

        /// <summary>
        /// Returns payment balance of the application in hundredth of a vote.
        /// </summary>
        /// <returns>Returns number of votes (in hundredth) on the application balance. For example, if this method returns 5000, it means that there are 50 votes on the application balance.</returns>
        public async Task<Response<int>> GetAppBalance()
            => await Request<int>("getAppBalance", new MethodParams(), true);

        /// <summary>
        /// Checks the user authentification using the access_token parameter.
        /// </summary>
        /// <param name="token">Client access_token.</param>
        /// <param name="ip">User ip address. Note that user may access using the ipv6 address, in this case it is required to transmit the ipv6 address. If not transmitted, the address will not be checked.</param>
        /// <returns>Returns token status.</returns>
        public async Task<Response<TokenStatus>> CheckToken(string token, string ip = null)
            => await Request<TokenStatus>("checkToken", new MethodParams
            {
                {"token", token, true},
                {"ip", ip}
            }, true);

        // TODO: addAppEvent

        #endregion
    }
}
