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
    /// A base class for managing user's notifications.
    /// </summary>
    public class NotificationsMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationsMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal NotificationsMethods(InTouch api) : base(api, "notifications") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a list of notifications about other users' feedback to the current user's wall posts.
        /// </summary>
        /// <param name="count">Number of notifications to return. </param>
        /// <param name="startFrom">The <see cref="NotificationsList.NextFrom"/> value received from the last method call.</param>
        /// <param name="filters">Type of notifications to return.</param>
        /// <param name="startTime">Earliest timestamp of a notification to return. By default, 24 hours ago.</param>
        /// <param name="endTime">Latest timestamp of a notification to return. By default, the current time.</param>
        /// <returns>Returns a <see cref="NotificationsList"/> object containing a list of notifications and lists of corresponding users and groups profiles.</returns>
        public async Task<Response<NotificationsList>> Get(int count = 30, string startFrom = null,
            List<NotificationsTypes> filters = null, DateTime? startTime = null, DateTime? endTime = null)
            => await Request<NotificationsList>("get", new MethodParams
            {
                {"count", count, false, new[] {0, 100}},
                {"start_from", startFrom},
                {"filters", filters},
                {"start_time", startTime?.ToUnixTimeStamp()},
                {"end_time", endTime?.ToUnixTimeStamp()}
            });

        /// <summary>
        /// Resets the counter of new notifications about other users' feedback to the current user's wall posts.
        /// </summary>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> MarkAsViewed() => await Request<bool>("markAsViewed");

        #endregion
    }
}