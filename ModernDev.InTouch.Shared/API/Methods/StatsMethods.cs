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

namespace ModernDev.InTouch
{
    /// <summary>
    /// A base class for retrieving visiting statistics.
    /// </summary>
    public class StatsMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StatsMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal StatsMethods(InTouch api) : base(api, "stats") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns statistics of a community or an application.
        /// </summary>
        /// <param name="groupId">Community ID. </param>
        /// <param name="appId">Application ID. </param>
        /// <param name="dateFrom">Latest date of statistics to return.</param>
        /// <param name="dateTo">End date of statistics to return.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Period"/> objects.</returns>
        public async Task<Response<List<Period>>> Get(int? groupId = null, int? appId = null, DateTime? dateFrom = null,
            DateTime? dateTo = null) => await Request<List<Period>>("get", new MethodParams
            {
                {"group_id", groupId},
                {"app_id", appId},
                {"date_from", dateFrom?.ToString("yyyy-MM-dd")},
                {"date_to", dateTo?.ToString("yyyy-MM-dd")}
            });

        /// <summary>
        /// Adds information about the current session in the application's visiting statistics.
        /// </summary>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> TrackVisitor() => await Request<bool>("trackVisitor");

        /// <summary>
        /// Returns statistics for the records on the wall.
        /// </summary>
        /// <param name="ownerId">Owner Id.</param>
        /// <param name="postId">Posit Id.</param>
        /// <returns>Returns a <see cref="PostStats"/> object containing post statistics.</returns>
        public async Task<Response<PostStats>> GetPostReach(int ownerId, int postId)
            => await Request<PostStats>("getPostReach", new MethodParams
            {
                {"post_id", postId, true },
                {"owner_id", ownerId, true }
            });

        #endregion
    }
}