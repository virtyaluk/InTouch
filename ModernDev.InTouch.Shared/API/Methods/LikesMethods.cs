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
using ModernDev.InTouch.Helpers;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Provides a base class for working with <c>Likes</c> section.
    /// </summary>
    public class LikesMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LikesMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal LikesMethods(InTouch api) : base(api, "likes") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a list of IDs of users who added the specified object to their <c>Likes</c> list.
        /// </summary>
        /// <param name="methodParams">A <see cref="LikesGetListParams"/> object with the params.</param>
        /// <returns>Returns the total number of users who added the specified object to their Likes list and list of IDs of users who added the specified object to their Likes list.</returns>
        public async Task<Response<ItemsList<User>>> GetList(LikesGetListParams methodParams)
            => await Request<ItemsList<User>>("getList", methodParams);

        /// <summary>
        /// Adds the specified object to the <c>Likes</c> list of the current user.
        /// </summary>
        /// <param name="itemId">Object ID.</param>
        /// <param name="type">Object type.</param>
        /// <param name="ownerId">ID of the user or community that owns the object.</param>
        /// <param name="accessKey">Access key required for an object owned by a private entity.</param>
        /// <param name="r"></param>
        /// <returns>Returns the current number of users who added this object to their Likes list. </returns>
        public async Task<Response<int>> Add(int itemId, MediaTypes type, int? ownerId = null, string accessKey = null,
            string r = null) => await Request<int>("add", new MethodParams
            {
                {"item_id", itemId, true},
                {"type", Utils.ToEnumString(type), true},
                {"owner_id", ownerId},
                {"access_key", accessKey},
                {"ref", r}
            }, false, "likes");

        /// <summary>
        /// Deletes the specified object from the <c>Likes</c> list of the current user.
        /// </summary>
        /// <param name="itemId">Object ID.</param>
        /// <param name="type">Object type.</param>
        /// <param name="ownerId">ID of the user or community that owns the object.</param>
        /// <returns>Returns the number of users who still have this object in their Likes list. </returns>
        public async Task<Response<int>> Delete(int itemId, MediaTypes type, int? ownerId = null)
            => await Request<int>("delete", new MethodParams
            {
                {"item_id", itemId, true},
                {"type", Utils.ToEnumString(type), true},
                {"owner_id", ownerId}
            }, false, "likes");

        /// <summary>
        /// Checks for the object in the <c>Likes</c> list of the specified user.
        /// </summary>
        /// <param name="itemId">Object ID.</param>
        /// <param name="type">Object type.</param>
        /// <param name="userId">User ID. </param>
        /// <param name="ownerId">ID of the user or community that owns the object.</param>
        /// <returns>Returns True if the object is in the user's Likes list; otherwise returns False.</returns>
        public async Task<Response<MediaLiked>> IsLiked(int itemId, MediaTypes type, int? userId = null,
            int? ownerId = null) => await Request<MediaLiked>("isLiked", new MethodParams
            {
                {"item_id", itemId, true},
                {"type", Utils.ToEnumString(type), true},
                {"user_id", userId},
                {"owner_id", ownerId}
            });

        #endregion
    }
}