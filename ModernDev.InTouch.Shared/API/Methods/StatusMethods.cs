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

using System.Threading.Tasks;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Provides a base class for setting and retrieving the status of a user or community.
    /// </summary>
    public class StatusMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal StatusMethods(InTouch api) : base(api, "status") { }

        #endregion

        #region Methods

        /// <summary>
        /// Sets a new status for the current user.
        /// </summary>
        /// <param name="text">Text of the new status.</param>
        /// <param name="groupId">Identifier of a community to set a status in. If left blank the status is set to current user. </param>
        /// <returns>When executed successfully it returns True.</returns>
        public async Task<Response<bool>> Set(string text, int? groupId = null)
            => await Request<bool>("set", new MethodParams {{"text", text, true}, {"group_id", groupId}});

        /// <summary>
        /// Returns data required to show the status of a user or community.
        /// </summary>
        /// <param name="userId">User ID or community ID. Use a negative value to designate a community ID. </param>
        /// <param name="groupId">Community ID.</param>
        /// <returns>
        /// Returns a <see cref="Status"/> object with a <see cref="Status.Text"/> field containing the text of the status of the user or community.
        /// If the user added broadcasting of the playing music in the status, and an audio file is currently playing, this method also returns a <see cref="Audio"/> object. 
        /// </returns>
        public async Task<Response<Status>> Get(int? userId = null, int? groupId = null)
            => await Request<Status>("get", new MethodParams {{"user_id", userId}, {"group_id", groupId}});

        #endregion
    }
}