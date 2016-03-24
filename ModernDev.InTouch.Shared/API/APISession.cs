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
using System.Diagnostics;

namespace ModernDev.InTouch
{
    /// <summary>
    /// An <see cref="APISession"/> class describes an API session.
    /// </summary>
    [DebuggerDisplay("APISession {UserId}")]
    public class APISession
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="APISession"/> class with a given <c>accessToken</c>, <c>userId</c> and <c>expires</c> parameters.
        /// </summary>
        /// <param name="accessToken">Access key for API calls.</param>
        /// <param name="userId">The authorized user ID.</param>
        /// <param name="expires"><see cref="AccessToken"/> life time specified in seconds.</param>
        public APISession(string accessToken, int userId, int expires)
        {
            AccessToken = accessToken;
            UserId = userId;
            Duration = TimeSpan.FromSeconds(expires);

            _sessionStoredDateTime = DateTime.Now;
        }

        #endregion

        #region Fields

        private readonly DateTime _sessionStoredDateTime;

        #endregion

        #region Properties

        /// <summary>
        /// Access key for API calls.
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// The authorized user ID.
        /// </summary>
        public int UserId { get; }

        /// <summary>
        /// <see cref="AccessToken"/> life time.
        /// </summary>
        public TimeSpan Duration { get; }

        /// <summary>
        /// The amount of time left before session expires.
        /// </summary>
        public TimeSpan TimeRemains => Duration - (_sessionStoredDateTime - DateTime.Now);

        /// <summary>
        /// Whether the session is active.
        /// </summary>
        public bool IsAlive => TimeRemains.TotalSeconds > 0;

        #endregion
    }
}