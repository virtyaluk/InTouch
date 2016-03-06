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

namespace ModernDev.InTouch.API
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("AuthorizationOptions")]
    public class AuthorizationData
    {
        public AuthorizationData() { }

        public AuthorizationData(int? clientId, AuthorizationDisplayTypes display, AccessPermissions scope, Uri redirectUri, bool revoke = false, bool ssoEnabled = false)
        {
            ClientId = clientId;
            Display = display;
            Scope = scope;
            RedirectUri = redirectUri;
            Revoke = revoke;
            SSOEnabled = ssoEnabled;
        }

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
    }
}