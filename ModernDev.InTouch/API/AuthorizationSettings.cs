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
using ModernDev.InTouch.API;

namespace ModernDev.InTouch
{
    /// <summary>
    /// An <see cref="AuthorizationSettings"/> class describes an authorization parameters.
    /// </summary>
    [DebuggerDisplay("AuthorizationSettings")]
    public class AuthorizationSettings
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationSettings"/> class.
        /// </summary>
        public AuthorizationSettings() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationSettings"/> class with the specified settings.
        /// </summary>
        /// <param name="clientId">Your application ID. Set to <code>null</code> if you want to use <c>clientId</c> from <see cref="InTouch"/> instance.</param>
        /// <param name="display">Specifies how the authorization page is displayed.</param>
        /// <param name="scope">Bit mask of application access settings which shall be checked during authorization and requested when unavailable.</param>
        /// <param name="redirectUri">URL where user will be redirected to after authorization (domain of the specified URL shall correspond to the main domain in application settings).</param>
        /// <param name="revoke">Whether the authorization dialog must revoke previously accessed application permissions.</param>
        /// <param name="ssoEnabled">Whether the app supports single sign-on (SSO).</param>
        public AuthorizationSettings(int? clientId, AuthorizationDisplayTypes display, AccessPermissions scope, Uri redirectUri, bool revoke = false, bool ssoEnabled = false)
        {
            ClientId = clientId;
            Display = display;
            Scope = scope;
            RedirectUri = redirectUri;
            Revoke = revoke;
            SSOEnabled = ssoEnabled;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Your application ID.
        /// </summary>
        public int? ClientId { get; set; }

        /// <summary>
        /// Authorization window appearance.
        /// </summary>
        public AuthorizationDisplayTypes Display { get; set; } = AuthorizationDisplayTypes.Mobile;

        /// <summary>
        /// Requested application access permissions.
        /// </summary>
        public AccessPermissions Scope { get; set; } = AccessPermissions.None;

        /// <summary>
        /// Whether the authorization dialog must revoke previously accessed application permissions.
        /// </summary>
        public bool Revoke { get; set; }

        /// <summary>
        /// URL where access_token will be passed to.
        /// </summary>
        public Uri RedirectUri { get; set; } = new Uri("https://oauth.vk.com/blank.html");

        /// <summary>
        /// Whether the app supports single sign-on (SSO).
        /// <remarks>
        /// See more on
        /// <a href="https://msdn.microsoft.com/en-us/windows/uwp/security/web-authentication-broker">How to use <c>SSO</c> in your app</a>.
        /// </remarks>
        /// </summary>
        public bool SSOEnabled { get; set; }

        #endregion
    }
}