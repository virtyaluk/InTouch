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
    /// A base class for registering users.
    /// </summary>
    public class AuthMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        public AuthMethods(InTouch api) : base(api, "auth") { }

        #endregion

        #region Methods

        /// <summary>
        /// Checks a user's phone number for correctness.
        /// </summary>
        /// <param name="phone">Phone number. </param>
        /// <param name="authByPhone"></param>
        /// <returns>Returns True if the phone number is correct; otherwise returns False.</returns>
        public async Task<Response<bool>> CheckPhone(string phone, bool authByPhone)
            => await Request<bool>("checkPhone", new MethodParams
            {
                {"phone", phone, true},
                {"client_id", API.ClientId},
                {"client_secret", API.ClientSecret, true},
                {"auth_by_phone", authByPhone}
            }, true);

        /// <summary>
        /// Registers a new user by phone number.
        /// </summary>
        /// <param name="methodParams">A <see cref="AuthSignupParams"/> object with the params.</param>
        /// <returns>
        /// Returns an SMS with an authorization code, which is sent to the user's phone number.
        /// The authorization code is used by the auth.confirm method to complete the registration. 
        /// 
        /// The <see cref="AuthStatus.SId"/> field returned in the reply is required to resend the SMS in case of delivery failure.
        /// </returns>
        public async Task<Response<AuthStatus>> Signup(AuthSignupParams methodParams)
            => await Request<AuthStatus>("signup", methodParams, true);

        /// <summary>
        /// Completes a user's registration (begun with the <see cref="Signup"/> method) using an authorization code.
        /// </summary>
        /// <param name="phone">The phone number of a registered user. The phone number can be checked first using <see cref="CheckPhone"/> method.</param>
        /// <param name="code">Code sent to the user via SMS.</param>
        /// <param name="password">User's password (minimum of 6 characters). Can be specified earlier with the <see cref="Signup"/> method.</param>
        /// <param name="testMode">True — call the phone number and leave a voice message of the authorization code; False — send the code by SMS(default).</param>
        /// <param name="intro">A bitmask representing status of passing intro in the app.</param>
        /// <returns>An <see cref="AuthStatus"/> object containing registration information.</returns>
        public async Task<Response<AuthStatus>> Confirm(string phone, string code, string password = null,
            bool testMode = false, int? intro = null) => await Request<AuthStatus>("confirm", new MethodParams
            {
                {"client_id", API.ClientId},
                {"client_secret", API.ClientSecret},
                {"phone", phone, true},
                {"code", code, true},
                {"password", password},
                {"test_mode", testMode},
                {"intro", intro}
            }, true);

        /// <summary>
        /// Allows to restore account access using a code received via SMS. 
        /// 
        /// <remarks>
        /// This method is only available for apps with < a href="https://vk.com/dev/auth_direct">Direct authorization</a> access.
        /// </remarks>
        /// </summary>
        /// <param name="phone">User phone number.</param>
        /// <returns>In case of success the method returns an <see cref="AuthStatus"/> object.</returns>
        public async Task<Response<AuthStatus>> Restore(string phone)
            => await Request<AuthStatus>("restore", new MethodParams {{"phone", phone, true}}, true);

        #endregion
    }
}