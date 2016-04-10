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
    /// Provides a base class for managing user's bookmarks.
    /// </summary>
    public class FaveMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FaveMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal FaveMethods(InTouch api) : base(api, "fave") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a list of users whom the current user has bookmarked.
        /// </summary>
        /// <param name="offset">Offset needed to return a specific subset of users.</param>
        /// <param name="count">Number of users to return.</param>
        /// <returns>Returns the total number of users and a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<ItemsList<User>>> GetUsers(int? offset = null, int count = 50)
            => await Request<ItemsList<User>>("getUsers", new MethodParams
            {
                {"offset", offset},
                {"count", count}
            });

        /// <summary>
        /// Returns a list of photos that the current user has liked.
        /// </summary>
        /// <param name="photoSizes">Set to True if you want to return photo's sizes as separated list.</param>
        /// <param name="offset">Offset needed to return a specific subset of photos.</param>
        /// <param name="count">Number of photos to return.</param>
        /// <returns>Returns the total number of photos and a list of <see cref="Photo"/> objects.</returns>
        public async Task<Response<ItemsList<Photo>>> GetPhotos(bool photoSizes = false, int? offset = null,
            int count = 50) => await Request<ItemsList<Photo>>("getPhotos", new MethodParams
            {
                {"photo_sizes", photoSizes},
                {"offset", offset},
                {"count", count}
            });

        /// <summary>
        /// Returns a list of wall posts that the current user has liked. 
        /// </summary>
        /// <param name="offset">Offset needed to return a specific subset of posts.</param>
        /// <param name="count">Number of posts to return. </param>
        /// <param name="extended">True — to return additional <see cref="ItemsList{T}.Profiles"/> and <see cref="ItemsList{T}.Groups"/> fields; False — (default).</param>
        /// <returns></returns>
        public async Task<Response<ItemsList<Post>>> GetPosts(int? offset = null, int count = 50, bool extended = false)
            => await Request<ItemsList<Post>>("getPosts", new MethodParams
            {
                {"offset", offset},
                {"count", count, false, 100},
                {"extended", extended}
            });

        /// <summary>
        /// Returns a list of videos that the current user has liked. 
        /// </summary>
        /// <param name="offset">Offset needed to return a specific subset of videos.</param>
        /// <param name="count">Number of videos to return.</param>
        /// <param name="extended">Return an additional information about videos. Also returns all owners profiles and groups. </param>
        /// <returns>Returns the total number of videos and a <see cref="List{T}"/> of <see cref="Video"/> objects.</returns>
        public async Task<Response<ItemsList<Video>>> GetVideos(int? offset = null, int count = 50,
            bool extended = false) => await Request<ItemsList<Video>>("getVideos", new MethodParams
            {
                {"offset", offset},
                {"count", count, false, 100},
                {"extended", extended}
            });

        /// <summary>
        /// Returns a list of links that the current user has bookmarked.
        /// </summary>
        /// <param name="offset">Offset needed to return a specific subset of links.</param>
        /// <param name="count">Number of links to return.</param>
        /// <returns>Returns the total number of links and a <see cref="List{T}"/> of <see cref="Link"/> objects.</returns>
        public async Task<Response<ItemsList<Link>>> GetLinks(int? offset = null, int count = 50)
            => await Request<ItemsList<Link>>("getLinks", new MethodParams
            {
                { "offset", offset},
                {"count", count, false, 100}
            });

        /// <summary>
        /// Returns market items bookmarked by current user.
        /// </summary>
        /// <param name="offset">Offset to get a certain results subset.</param>
        /// <param name="count">Number of items to return info.</param>
        /// <param name="extended">True – additional fields <see cref="Product.Likes"/>, <see cref="Product.CanComment"/>, <see cref="Product.CanRepost"/>, <see cref="Product.Photos"/> will be returned. These fields are disabled by default.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Product"/> objects.</returns>
        public async Task<Response<ItemsList<Product>>> GetMarketItems(int? offset = null, int count = 50,
            bool extended = false) => await Request<ItemsList<Product>>("getMarketItems", new MethodParams
            {
                {"offset", offset},
                {"count", count, false, 100},
                {"extended", extended}
            });

        /// <summary>
        /// Adds a user to the bookmarks.
        /// </summary>
        /// <param name="userId">Id of the user to add.</param>
        /// <returns>When executed successfully it returns True.</returns>
        public async Task<Response<bool>> AddUser(int userId)
            => await Request<bool>("addUser", new MethodParams {{"user_id", userId, true}});

        /// <summary>
        /// Removes a user from the bookmarks.
        /// </summary>
        /// <param name="userId">Id of the user to remove.</param>
        /// <returns>When executed successfully it returns True.</returns>
        public async Task<Response<bool>> RemoveUser(int userId)
            => await Request<bool>("removeUser", new MethodParams {{"user_id", userId, true}});

        /// <summary>
        /// Adds a group to the bookmarks.
        /// </summary>
        /// <param name="groupId">Id of the group to add.</param>
        /// <returns>When executed successfully it returns True.</returns>
        public async Task<Response<bool>> AddGroup(int groupId)
            => await Request<bool>("addGroup", new MethodParams {{"group_id", groupId, true}});

        /// <summary>
        /// Removes a group from the bookmarks.
        /// </summary>
        /// <param name="groupId">Id of the group to remove.</param>
        /// <returns>When executed successfully it returns True.</returns>
        public async Task<Response<bool>> RemoveGroup(int groupId)
            => await Request<bool>("removeGroup", new MethodParams {{"group_id", groupId, true}});

        /// <summary>
        /// Adds a link to the bookmarks.
        /// </summary>
        /// <param name="link">The address of the link.</param>
        /// <param name="text">Description text.</param>
        /// <returns>When executed successfully it returns True.</returns>
        public async Task<Response<bool>> AddLink(string link, string text = null)
            => await Request<bool>("addLink", new MethodParams {{"link", link, true}, {"text", text}});

        /// <summary>
        /// Removes a link from the bookmarks.
        /// </summary>
        /// <param name="linkId">Id of the link to remove.</param>
        /// <returns>When executed successfully it returns True.</returns>
        public async Task<Response<bool>> RemoveLink(int linkId)
            => await Request<bool>("removeLink", new MethodParams {{"link_id", linkId, true}});

        #endregion
    }
}