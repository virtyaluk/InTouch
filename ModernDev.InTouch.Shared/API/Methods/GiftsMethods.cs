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
    /// Provides a base class for managing user's gifts.
    /// </summary>
    public class GiftsMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftsMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal GiftsMethods(InTouch api) : base(api, "gifts") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a list of gifts received by the user.
        /// </summary>
        /// <param name="userId">The user id whose gifts you want to return.</param>
        /// <param name="count">the number of gifts you want to return.</param>
        /// <param name="offset">The offset required for sampling a subset of gifts.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="GiftItem"/> objects.</returns>
        public async Task<Response<ItemsList<GiftItem>>> Get(int? userId = null, int? count = null, int? offset = null)
            => await Request<ItemsList<GiftItem>>("get", new MethodParams
            {
                {"user_id", userId},
                {"count", count},
                {"offset", offset}
            });

        #endregion
    }
}