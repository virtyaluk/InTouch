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
using System.Threading.Tasks;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Provides a base class for managing app variables.
    /// </summary>
    public class StorageMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal StorageMethods(InTouch api) : base(api, "storage") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a value of variable with the name set by key parameter.
        /// 
        /// Use <see cref="Set"/> method to set the value. 
        /// 
        /// Variables can be stored in two scopes:
        /// <list type="bullet">
        ///     <item>
        ///         <term>Custom</term>
        ///         <description>Variable is bound to the user and other users cannot read it.</description>
        ///     </item>
        ///     <item>
        ///         <term>Global</term>
        ///         <description>Variable is bound to the application and its usage does not depend on the user. If this method is called by others but not by the application, global parameter should be passed to access the variable.</description>
        ///     </item>
        /// </list>
        /// </summary>
        /// <param name="key">The name of the variable.</param>
        /// <param name="global">Set to True if you want to work with global variables, not the user variables.</param>
        /// <param name="userId">User id, whose variables names are returned if they were requested with a server method.</param>
        /// <returns>Returns a value of the variable. If there is no variable on server, an empty string will be returned.</returns>
        public async Task<Response<string>> Get(string key, bool global = false, int? userId = null)
            => await Request<string>("get", new MethodParams
            {
                {"key", key, true},
                {"global", global},
                {"user_id", userId}
            });

        /// <summary>
        /// Returns a value of variable with the name set by key parameter.
        /// 
        /// Use <see cref="Set"/> method to set the value. 
        /// 
        /// Variables can be stored in two scopes:
        /// <list type="bullet">
        ///     <item>
        ///         <term>Custom</term>
        ///         <description>Variable is bound to the user and other users cannot read it.</description>
        ///     </item>
        ///     <item>
        ///         <term>Global</term>
        ///         <description>Variable is bound to the application and its usage does not depend on the user. If this method is called by others but not by the application, global parameter should be passed to access the variable.</description>
        ///     </item>
        /// </list>
        /// </summary>
        /// <param name="keys">A list of variable names, separated by commas.</param>
        /// <param name="global">Set to True if you want to work with global variables, not the user variables.</param>
        /// <param name="userId">User id, whose variables names are returned if they were requested with a server method.</param>
        /// <returns>Returns a value of variables.</returns>
        public async Task<Response<List<KeyValuePair<string, string>>>> Get(List<string> keys, bool global = false,
            int? userId = null) => await Request<List<KeyValuePair<string, string>>>("get", new MethodParams
            {
                {"keys", keys, true, 1000},
                {"global", global},
                {"user_id", userId}
            });

        /// <summary>
        /// Saves a value of variable with the name set by <c>key</c> parameter.
        /// 
        /// Use <see cref="Set"/> method to receive the saved value.
        /// 
        /// Variables can be stored in two scopes:
        /// <list type="bullet">
        ///     <item>
        ///         <term>Custom.</term>
        ///         <description>Variable is bound to the user and only he/she or the application server can get access to it. Maximum 1000 variables can be created for each user.</description>
        ///     </item>
        ///     <item>
        ///         <term>Global</term>
        ///         <description>Variable is bound to the application and its usage does not depend on the user. To set a global variable when using API by the user, global parameter shall be passed. Maximum 5000 global variables can be created.</description>
        ///     </item>
        /// </list>
        /// 
        /// To delete the variable you shall pass a blank value in value parameter. 
        /// </summary>
        /// <param name="key">The name of the variable.</param>
        /// <param name="value">The value of the variable. Only the first 4096 bytes will be stored.</param>
        /// <param name="global">Set to True if you want to work with global variables, not the user variables.</param>
        /// <param name="userId">User id, whose variables names are returned if they were requested with a server method.</param>
        /// <returns>Returns True if the variable is saved successfully.</returns>
        public async Task<Response<bool>> Set(string key, string value, bool global = false, int? userId = null)
            => await Request<bool>("set", new MethodParams
            {
                {"key", key, true },
                {"value", value },
                {"global", global },
                {"user_id", userId }
            });

        /// <summary>
        /// Returns the names of all variables.
        /// </summary>
        /// <param name="global">Set to True if you want to work with global variables, not the user variables.</param>
        /// <param name="userId">User id, whose variables names are returned if they were requested with a server method.</param>
        /// <param name="offset">Offset required to choose a particular variable names subset. 0 by default. </param>
        /// <param name="count">Amount of variable names the info needs to be collected from. </param>
        /// <returns>Returns a <see cref="List{T}"/> of variables names.</returns>
        public async Task<Response<List<string>>> GetKeys(bool global = false, int? userId = null, int? offset = null,
            int count = 100) => await Request<List<string>>("getKeys", new MethodParams
            {
                {"global", global},
                {"user_id", userId},
                {"offset", offset},
                {"count", count, false, 1000}
            });

        #endregion
    }
}