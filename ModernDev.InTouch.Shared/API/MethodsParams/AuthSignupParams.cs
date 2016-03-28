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

namespace ModernDev.InTouch
{
    /// <summary>
    /// An <see cref="AuthSignupParams"/> class describes a <see cref="AuthMethods.Signup"/> method params.
    /// </summary>
    public class AuthSignupParams : MethodParamsGroup
    {
        /// <summary>
        /// User's first name. 
        /// </summary>
        [MethodParam(Name = "first_name", IsRequired = true)]
        public string FirstName { get; set; }

        /// <summary>
        /// User's surname.
        /// </summary>
        [MethodParam(Name = "last_name", IsRequired = true)]
        public string LastName { get; set; }

        /// <summary>
        /// Your application ID. 
        /// </summary>
        [MethodParam(Name = "client_id", IsRequired = true)]
        public int ClientId { get; }

        /// <summary>
        /// Your application secret.
        /// </summary>
        [MethodParam(Name = "client_secret", IsRequired = true)]
        public string ClientSecret { get; }

        /// <summary>
        /// User's phone number. Can be pre-checked with the <see cref="AuthMethods.CheckPhone"/> method. 
        /// </summary>
        [MethodParam(Name = "phone", IsRequired = true)]
        public string Phone { get; set; }

        /// <summary>
        /// User's password (minimum of 6 characters). Can be specified later with the <see cref="AuthMethods.Confirm"/> method. 
        /// </summary>
        [MethodParam(Name = "password")]
        public string Password { get; set; }

        /// <summary>
        /// True — test mode, in which the user will not be registered and the phone number will not be checked for availability;
        /// False — default mode(default)
        /// </summary>
        [MethodParam(Name = "test_mode")]
        public bool TestMode { get; set; }

        /// <summary>
        /// True — call the phone number and leave a voice message of the authorization code;
        /// False — send the code by SMS(default).
        /// </summary>
        [MethodParam(Name = "voice")]
        public bool Voice { get; set; }

        /// <summary>
        /// 1 — female; 2 — male
        /// </summary>
        [MethodParam(Name = "sex")]
        public int Sex { get; set; }

        /// <summary>
        /// Session ID required for method recall when SMS was not delivered. 
        /// </summary>
        [MethodParam(Name = "sid")]
        public string SId { get; set; }

        public AuthSignupParams()
        {
            ClientId = API.ClientId;
            ClientSecret = API.ClientSecret;
        }
    }
}