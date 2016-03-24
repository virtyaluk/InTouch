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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModernDev.InTouch.Helpers;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A base class for working with photos.
    /// </summary>
    public class PhotosMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PhotosMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        public PhotosMethods(InTouch api) : base(api, "photos") { }

        #endregion

        #region Methods

        /// <summary>
        /// Creates an empty photo album.
        /// </summary>
        /// <param name="methodParams">A <see cref="PhotosCreateAlbumParams"/> object with method params.</param>
        /// <returns>Returns an <see cref="Album"/> object.</returns>
        public async Task<Response<Album>> CreateAlbum(PhotosCreateAlbumParams methodParams)
            => await Request<Album>("createAlbum", methodParams);

        /// <summary>
        /// Edits information about a photo album.
        /// </summary>
        /// <param name="methodParams">A <see cref="PhotosEdiAlbumParams"/> object with method params.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditAlbum(PhotosEdiAlbumParams methodParams)
            => await Request<bool>("editAlbum", methodParams);

        /// <summary>
        /// Returns a list of a user's or community's photo albums.
        /// </summary>
        /// <param name="methodParams">A <see cref="PhotosGetAlbumsParams"/> object with method params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Album"/> objects.</returns>
        public async Task<Response<ItemsList<Album>>> GetAlbums(PhotosGetAlbumsParams methodParams)
            => await Request<ItemsList<Album>>("getAlbums", methodParams, true);

        /// <summary>
        /// Returns a list of a user's or community's photos.
        /// </summary>
        /// <param name="methodParams">A <see cref="PhotosGetParams"/> object with method params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Photo"/> objects.</returns>
        public async Task<Response<ItemsList<Photo>>> Get(PhotosGetParams methodParams)
            => await Request<ItemsList<Photo>>("get", methodParams, true);

        /// <summary>
        /// Returns the number of photo albums belonging to a user or community.
        /// </summary>
        /// <param name="userId">User ID. </param>
        /// <param name="groupId">Community ID.</param>
        /// <returns>Returns the number of photo albums belonging to the user or community (considering privacy settings).</returns>
        public async Task<Response<int>> GetAlbumsCount(int? userId = null, int? groupId = null)
            => await Request<int>("getAlbumsCount", new MethodParams
            {
                {"user_id", userId},
                {"owner_id", groupId}
            });

        /// <summary>
        /// Returns information about photos by their IDs.
        /// </summary>
        /// <param name="photos">
        /// IDs of users who posted photos and IDs of photos themselves with an underscore character between such IDs. To get information about a photo in the group album, you shall specify group ID instead of user ID.
        /// Example:
        /// <example>1_129207899,6492_135055734,-20629724_271945303</example>
        /// </param>
        /// <param name="extended">True — to return additional fields.</param>
        /// <param name="photoSizes">True - to return photo sizes in a special format.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Photo"/> objects.</returns>
        public async Task<Response<List<Photo>>> GetById(List<string> photos, bool extended = true,
            bool photoSizes = true) => await Request<List<Photo>>("getById", new MethodParams
            {
                {"photos", photos, true},
                {"extended", extended},
                {"photo_sizes", photoSizes}
            }, true);

        /// <summary>
        /// Returns information about photos by their IDs.
        /// </summary>
        /// <param name="photos">IDs of users who posted photos and IDs of photos themselves. To get information about a photo in the group album, you shall specify group ID instead of user ID.</param>
        /// <param name="extended">True — to return additional fields.</param>
        /// <param name="photoSizes">True - to return photo sizes in a special format.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Photo"/> objects.</returns>
        public async Task<Response<List<Photo>>> GetById(Dictionary<int, int> photos, bool extended = true,
            bool photoSizes = true)
            => await GetById(photos.Select(kvp => $"{kvp.Key}_{kvp.Value}").ToList(), extended, photoSizes);

        /// <summary>
        /// Returns the server address for photo upload.
        /// When uploaded successfully, the photo can be saved with the <see cref="Save"/> method.
        /// </summary>
        /// <param name="albumId">Album ID.</param>
        /// <param name="groupId">ID of community that owns the album (if the photo will be uploaded to a community album).</param>
        /// <returns>Returns object including server upload url.</returns>
        public async Task<Response<PhotosServerInfo>> GetUploadServer(int? albumId = null, int? groupId = null)
            => await Request<PhotosServerInfo>("getUploadServer", new MethodParams
            {
                {"album_id", albumId},
                {"group_id", groupId}
            });

        /// <summary>
        /// Returns an upload server address for a profile or community photo.
        /// After the successful upload you can use the <see cref="SaveOwnerPhoto"/> method.
        /// </summary>
        /// <param name="ownerId">Identifier of a community or current user. Note that community id must be negative.</param>
        /// <returns>Returns object including server upload url.</returns>
        public async Task<Response<ServerInfo>> GetOwnerPhotoUploadServer(int? ownerId = null)
            => await Request<ServerInfo>("getOwnerPhotoUploadServer", new MethodParams {{"owner_id", ownerId}});

        /// <summary>
        /// Returns an upload link for chat cover pictures.
        /// </summary>
        /// <param name="chatId">ID of the chat for which you want to upload a cover photo.</param>
        /// <param name="cropX">X coordinate to crop.</param>
        /// <param name="cropY">Y coordinate to crop.</param>
        /// <param name="cropWidth">Width (in pixels) of the photo after cropping</param>
        /// <returns>Returns object including server upload url.</returns>
        public async Task<Response<ServerInfo>> GetChatUploadServer(int chatId, int? cropX = null, int? cropY = null,
            int cropWidth = 200) => await Request<ServerInfo>("getChatUploadServer", new MethodParams
            {
                {"chat_id", chatId, true},
                {"crop_x", cropX},
                {"crop_y", cropY},
                {"crop_width", cropWidth, false, new[] {200, 2400}}
            });

        /// <summary>
        /// Returns an upload link for product photo.
        /// </summary>
        /// <param name="groupId">Group Id for which you want to upload a market photo.</param>
        /// <param name="mainPhoto">Whether the photo is album cover.</param>
        /// <param name="cropX">X coordinate to crop.</param>
        /// <param name="cropY">Y coordinate to crop.</param>
        /// <param name="cropWidth">The image width after crop.</param>
        /// <returns>Returns object including server upload url.</returns>
        public async Task<Response<ServerInfo>> GetMarketUploadServer(int groupId, bool mainPhoto = false,
            int? cropX = null, int? cropY = null, int cropWidth = 200)
            => await Request<ServerInfo>("getMarketUploadServer", new MethodParams
            {
                {"group_id", groupId, true},
                {"main_photo", mainPhoto},
                {"crop_x", cropX},
                {"crop_y", cropY},
                {"crop_width", cropWidth, false, new[] {200, 2400}}
            });

        /// <summary>
        /// Returns an upload link for products section photo.
        /// </summary>
        /// <param name="groupId">Group Id for which you want to upload a market photo.</param>
        /// <returns>Returns object including server upload url.</returns>
        public async Task<Response<ServerInfo>> GetMarketAlbumUploadServer(int groupId)
            => await Request<ServerInfo>("getMarketAlbumUploadServer", new MethodParams {{"group_id", groupId}});

        /// <summary>
        /// Saves a photo after being uploaded.
        /// You can get an address for photo upload with the <see cref="GetMarketUploadServer"/> method.
        /// </summary>
        /// <param name="uploadResponse">Object returned after photo upload.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Photo"/> objects.</returns>
        public async Task<Response<List<Photo>>> SaveMarketPhoto(MarketPhotoUploadResponse uploadResponse)
            => await Request<List<Photo>>("saveMarketPhoto", new MethodParams
            {
                {"group_id", uploadResponse?.GroupId, true},
                {"photo", uploadResponse?.Photo, true},
                {"server", uploadResponse?.Server, true},
                {"hash", uploadResponse?.Hash, true},
                {"crop_data", uploadResponse?.CropData},
                {"crop_hash", uploadResponse?.CropHash}
            });

        /// <summary>
        /// Saves a photo after being uploaded.
        /// You can get an address for photo upload with the <see cref="GetMarketAlbumUploadServer"/> method.
        /// </summary>
        /// <param name="uploadResponse">Object returned after photo upload.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Photo"/> objects.</returns>
        public async Task<Response<List<Photo>>> SaveMarketAlbumPhoto(MarketPhotoUploadResponse uploadResponse)
            => await Request<List<Photo>>("saveMarketAlbumPhoto", new MethodParams
            {
                {"group_id", uploadResponse?.GroupId, true},
                {"photo", uploadResponse?.Photo, true},
                {"server", uploadResponse?.Server, true},
                {"hash", uploadResponse?.Hash, true}
            });

        /// <summary>
        /// Saves a profile or community photo.
        /// Upload URL can be got with the <see cref="GetOwnerPhotoUploadServer"/> method.
        /// </summary>
        /// <param name="uploadResponse">Object returned after photo upload.</param>
        /// <returns>Returns an <see cref="OwnerPhoto"/> object.</returns>
        public async Task<Response<OwnerPhoto>> SaveOwnerPhoto(PhotoUploadResponse uploadResponse)
            => await Request<OwnerPhoto>("saveOwnerPhoto", new MethodParams
            {
                {"server", uploadResponse?.Server, true},
                {"hash", uploadResponse?.Hash, true},
                {"photo", uploadResponse?.Photo, true}
            });

        /// <summary>
        /// Saves a photo to a user's or community's wall after being uploaded.
        /// You can get an address for photo upload with the <see cref="GetWallUploadServer"/> method.
        /// </summary>
        /// <param name="uploadResponse">Object returned after photo upload.</param>
        /// <param name="userId">ID of the user on whose wall the photo will be saved.</param>
        /// <param name="groupId">ID of community on whose wall the photo will be saved.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Photo"/> objects.</returns>
        public async Task<Response<List<Photo>>> SaveWallPhoto(PhotoUploadResponse uploadResponse, int? userId = null,
            int? groupId = null) => await Request<List<Photo>>("saveWallPhoto", new MethodParams
            {
                {"photo", uploadResponse?.Photo, true},
                {"server", uploadResponse?.Server, true},
                {"hash", uploadResponse?.Hash, true},
                {"user_id", userId},
                {"group_id", groupId}
            });

        /// <summary>
        /// Returns the server address for photo upload onto a user's wall.
        /// When uploaded successfully, the photo can be saved using the <see cref="SaveWallPhoto"/> method.
        /// </summary>
        /// <param name="groupId">ID of community to whose wall the photo will be uploaded.</param>
        /// <returns>Returns object including server upload url.</returns>
        public async Task<Response<PhotosServerInfo>> GetWallUploadServer(int? groupId = null)
            => await Request<PhotosServerInfo>("getWallUploadServer", new MethodParams
            {
                {"group_id", groupId?.Abs()}
            });

        /// <summary>
        /// Returns the server address for photo upload in a private message for a user.
        /// When uploaded successfully, the photo can be saved using the <see cref="SaveMessagesPhoto"/> method.
        /// </summary>
        /// <returns>Returns object including server upload url.</returns>
        public async Task<Response<PhotosServerInfo>> GetMessagesUploadServer()
            => await Request<PhotosServerInfo>("getMessagesUploadServer");

        /// <summary>
        /// Saves a photo after being successfully uploaded. URL obtained with <see cref="GetMessagesUploadServer"/> method.
        /// </summary>
        /// <param name="uploadResponse">Object returned after photo upload.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Photo"/> objects.</returns>
        public async Task<Response<List<Photo>>> SaveMessagesPhoto(PhotoUploadResponse uploadResponse)
            => await Request<List<Photo>>("saveMessagesPhoto", new MethodParams
            {
                {"photo", uploadResponse?.Photo, true}
            });

        /// <summary>
        /// Reports (submits a complaint about) a photo.
        /// </summary>
        /// <param name="ownerId">ID of the user or community that owns the photo.</param>
        /// <param name="photoId">Photo ID. </param>
        /// <param name="reason">Reason for the complaint.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Report(int ownerId, int photoId, ReportTypes reason)
            => await Request<bool>("report", new MethodParams
            {
                {"photo_id", photoId, true},
                {"owner_id", ownerId, true},
                {"reason", (int) reason}
            });

        /// <summary>
        /// Reports (submits a complaint about) a comment on a photo. 
        /// </summary>
        /// <param name="ownerId">ID of the user or community that owns the photo.</param>
        /// <param name="commentId">ID of the comment being reported. </param>
        /// <param name="reason">Reason for the complaint.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> ReportComment(int ownerId, int commentId, ReportTypes reason)
            => await Request<bool>("reportComment", new MethodParams
            {
                {"comment_id", commentId, true},
                {"owner_id", ownerId, true},
                {"reason", (int) reason}
            });

        /// <summary>
        /// Returns a list of photos.
        /// </summary>
        /// <param name="q">Search query string. </param>
        /// <param name="coords">Geographical coordinates.</param>
        /// <param name="sortByLikes">Sort order: True - by popularity; False - </param>
        /// <param name="count">Number of photos to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of photos. By default, 0.</param>
        /// <param name="startTime">The start date from which to return photos.</param>
        /// <param name="endTime">The end date which up to return photos.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Photo"/> objects.</returns>
        public async Task<Response<ItemsList<Photo>>> Search(string q, Coordinates coords = null,
            bool sortByLikes = false, int count = 100, int offset = 0, DateTime? startTime = null,
            DateTime? endTime = null)
            => await Request<ItemsList<Photo>>("search", new MethodParams
            {
                {"q", q},
                {"start_time", startTime?.ToUnixTimeStamp()},
                {"end_time", endTime?.ToUnixTimeStamp()},
                {"lat", coords?.Latitude},
                {"long", coords?.Longitude},
                {"sort", sortByLikes},
                {"offset", offset},
                {"count", count, false, new[] {0, 1000}},
                {"radius", coords?.Radius}
            }, true);

        /// <summary>
        /// Saves photos after successful uploading.
        /// </summary>
        /// <param name="uploadResponse">Object returned when photos are uploaded to server.</param>
        /// <param name="albumId">ID of the album to save photos to.</param>
        /// <param name="groupId">ID of the community to save photos to.</param>
        /// <param name="caption">Text describing the photo. 2048 digits max.</param>
        /// <param name="coords">Geo coordinates object.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Photo"/> objects.</returns>
        public async Task<Response<List<Photo>>> Save(AlbumPhotoUploadResponse uploadResponse, int? albumId = null,
            int? groupId = null, string caption = null, Coordinates coords = null)
            => await Request<List<Photo>>("save", new MethodParams
            {
                {"album_id", albumId},
                {"group_id", groupId},
                {"server", uploadResponse?.Server, true},
                {"photos_list", uploadResponse?.PhotosList},
                {"hash", uploadResponse?.Hash},
                {"latitude", coords?.Latitude},
                {"longitude", coords?.Longitude},
                {"caption", caption}
            });

        /// <summary>
        /// Allows to copy a photo to the "Saved photos" album.
        /// </summary>
        /// <param name="ownerId">ID of the user or community that owns the photo.</param>
        /// <param name="photoId">Photo ID.</param>
        /// <param name="accessKey">Special access key for private photos.</param>
        /// <returns>Returns the created photo ID.</returns>
        public async Task<Response<int>> Copy(int ownerId, int photoId, string accessKey)
            => await Request<int>("copy", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"photo_id", photoId, true},
                {"access_key", accessKey}
            });

        /// <summary>
        /// Edits the caption of a photo.
        /// </summary>
        /// <param name="photoId">Photo ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the photo.</param>
        /// <param name="caption">New caption for the photo. If this parameter is not set, it is considered to be equal to an empty string.</param>
        /// <param name="coords">Coordinates object.</param>
        /// <param name="placeStr">Geo place string.</param>
        /// <param name="deletePlace">True - to delete previously added place.</param>
        /// <param name="forsquareId">Foursquare Id.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Edit(int photoId, int? ownerId = null, string caption = null,
            Coordinates coords = null, string placeStr = null, bool deletePlace = false, string forsquareId = null)
            => await Request<bool>("edit", new MethodParams
            {
                {"photo_id", photoId, true},
                {"owner_id", ownerId},
                {"caption", caption},
                {"latitude", coords?.Latitude},
                {"longitude", coords?.Longitude},
                {"place_str", placeStr},
                {"foursquare_id", forsquareId},
                {"delete_place", deletePlace}
            });

        /// <summary>
        /// Moves a photo from one album to another.
        /// </summary>
        /// <param name="photoId">Photo ID.</param>
        /// <param name="targetAlbumId">ID of the album to which the photo will be moved.</param>
        /// <param name="ownerId">ID of the user or community that owns the photo.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Move(int photoId, int targetAlbumId, int? ownerId = null)
            => await Request<bool>("move", new MethodParams
            {
                {"photo_id", photoId, true},
                {"target_album_id", targetAlbumId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Makes a photo into an album cover.
        /// </summary>
        /// <param name="photoId">Photo ID.</param>
        /// <param name="albumId">Album ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the photo.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> MakeCover(int photoId, int? albumId = null, int? ownerId = null)
            => await Request<bool>("makeCover", new MethodParams
            {
                {"photo_id", photoId, true},
                {"owner_id", ownerId},
                {"album_id", albumId}
            });

        /// <summary>
        /// Reorders the album in the list of user albums.
        /// </summary>
        /// <param name="albumId">Album ID. </param>
        /// <param name="ownerId">ID of the user or community that owns the album.</param>
        /// <param name="before">ID of the album before which the album in question shall be placed. </param>
        /// <param name="after">ID of the album after which the album in question shall be placed. </param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> ReorderAlbums(int albumId, int? ownerId = null, int? before = null,
            int? after = null) => await Request<bool>("reorderAlbums", new MethodParams
            {
                {"album_id", albumId, true},
                {"owner_id", ownerId},
                {"before", before},
                {"after", after}
            });

        /// <summary>
        /// Reorders the photo in the list of photos of the user album.
        /// </summary>
        /// <param name="photoId">Photo ID. </param>
        /// <param name="ownerId">ID of the user or community that owns the photo.</param>
        /// <param name="before">ID of the photo before which the photo in question shall be placed. </param>
        /// <param name="after">ID of the photo after which the photo in question shall be placed. </param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> ReorderPhotos(int photoId, int? ownerId = null, int? before = null,
            int? after = null) => await Request<bool>("reorderPhotos", new MethodParams
            {
                {"photo_id", photoId, true},
                {"owner_id", ownerId},
                {"before", before},
                {"after", after}
            });

        /// <summary>
        /// Returns a list of photos belonging to a user or community, in reverse chronological order.
        /// </summary>
        /// <param name="ownerId">ID of a user or community that owns the photos. Use a negative value to designate a community ID.</param>
        /// <param name="extended">True — to return detailed information about photos</param>
        /// <param name="count">Number of photos to return. </param>
        /// <param name="offset">Offset needed to return a specific subset of photos. By default, 0. </param>
        /// <param name="photoSizes">True - to return image sizes in special format.</param>
        /// <param name="noServiceAlbums">True– to return photos only from standard albums; False – to return all photos including those in service albums, e.g., My wall photos(default)</param>
        /// <param name="needHidden">True – to show information about photos being hidden from the block above the wall. </param>
        /// <param name="skepHidden">True – not to return photos being hidden from the block above the wall.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Photo"/> objects.</returns>
        public async Task<Response<ItemsList<Photo>>> GetAll(int? ownerId = null, bool extended = false, int count = 20,
            int offset = 0, bool photoSizes = false, bool noServiceAlbums = false, bool needHidden = false,
            bool skepHidden = false) => await Request<ItemsList<Photo>>("getAll", new MethodParams
            {
                {"owner_id", ownerId},
                {"extended", extended},
                {"offset", offset},
                {"count", count, false, new[] {0, 200}},
                {"photo_sizes", photoSizes},
                {"no_service_albums", noServiceAlbums},
                {"need_hidden", needHidden},
                {"skip_hidden", skepHidden}
            });

        /// <summary>
        /// Returns a list of photos in which a user is tagged.
        /// </summary>
        /// <param name="userId">User ID. </param>
        /// <param name="count">Number of photos to return. Maximum value is 100.</param>
        /// <param name="offset">Offset needed to return a specific subset of photos. By default, 0. </param>
        /// <param name="extended">rue - to return an additional likes field.</param>
        /// <param name="sortByDateReverse">Sort order: True — by date the tag was added in ascending order; False — by date the tag was added in descending order</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Photo"/> objects.</returns>
        public async Task<Response<ItemsList<Photo>>> GetUserPhotos(int? userId = null, int count = 20, int offset = 0,
            bool extended = false, bool sortByDateReverse = false)
            => await Request<ItemsList<Photo>>("getUserPhotos", new MethodParams
            {
                {"user_id", userId},
                {"count", count, false, new[] {0, 1000}},
                {"offset", offset},
                {"extended", extended},
                {"sort", sortByDateReverse}
            });

        /// <summary>
        /// Deletes a photo album belonging to the current user.
        /// </summary>
        /// <param name="albumId">Album ID. </param>
        /// <param name="groupId">ID of the community that owns the album.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DeleteAlbum(int albumId, int? groupId = null)
            => await Request<bool>("deleteAlbum", new MethodParams
            {
                {"album_id", albumId, true},
                {"groupId", groupId}
            });

        /// <summary>
        /// Deletes a photo.
        /// </summary>
        /// <param name="photoId">Photo ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the photo.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Delete(int photoId, int? ownerId = null)
            => await Request<bool>("delete", new MethodParams
            {
                {"photo_id", photoId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Restores a deleted photo.
        /// </summary>
        /// <param name="photoId">Photo ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the photo.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Restore(int photoId, int? ownerId = null)
            => await Request<bool>("restore", new MethodParams
            {
                {"photo_id", photoId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Confirms a tag on a photo.
        /// </summary>
        /// <param name="photoId">Photo ID.</param>
        /// <param name="tagId">Tag ID. </param>
        /// <param name="ownerId">ID of the user or community that owns the photo.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> ConfirmTag(int photoId, int tagId, int? ownerId = null)
            => await Request<bool>("confirmTag", new MethodParams
            {
                {"photo_id", photoId, true},
                {"tag_id", tagId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Returns a list of comments on a photo.
        /// </summary>
        /// <param name="methodParams">A <see cref="PhotosGetCommentsParam"/> object containing params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Comment"/> objects.</returns>
        public async Task<Response<ItemsList<Comment>>> GetComments(PhotosGetCommentsParam methodParams)
            => await Request<ItemsList<Comment>>("getComments", methodParams);

        /// <summary>
        /// Returns a list of comments on a specific photo album or all albums of the user sorted in reverse chronological order.
        /// </summary>
        /// <param name="ownerId">ID of the user or community that owns the album(s).</param>
        /// <param name="albumId">Album ID. If the parameter is not set, comments on all of the user's albums will be returned. </param>
        /// <param name="needLikes">True — to return an additional likes field; False — (default).</param>
        /// <param name="count">Number of comments to return. By default, 20. Maximum value, 100. </param>
        /// <param name="offset">Offset needed to return a specific subset of comments. By default, 0. </param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Comment"/> objects.</returns>
        public async Task<Response<ItemsList<Comment>>> GetAllComments(int? ownerId = null, int? albumId = null,
            bool needLikes = false, int count = 20, int offset = 0)
            => await Request<ItemsList<Comment>>("getAllComments", new MethodParams
            {
                {"owner_id", ownerId},
                {"album_id", albumId},
                {"need_likes", needLikes},
                {"offset", offset},
                {"count", count, false, new[] {0, 100}}
            });

        /// <summary>
        /// Returns the ID of the created comment.
        /// </summary>
        /// <param name="methodParams">A <see cref="PhotosCreateCommentParams"/> object containing params.</param>
        /// <returns></returns>
        public async Task<Response<int>> CreateComment(PhotosCreateCommentParams methodParams)
            => await Request<int>("createComment", methodParams);

        /// <summary>
        /// Deletes a comment on the photo.
        /// </summary>
        /// <param name="commentId">Comment ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the photo. </param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DeleteComment(int commentId, int? ownerId = null)
            => await Request<bool>("deleteComment", new MethodParams
            {
                {"comment_id", commentId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Restores a deleted comment on a photo.
        /// </summary>
        /// <param name="commentId">ID of the deleted comment.</param>
        /// <param name="ownerId">ID of the user or community that owns the photo. </param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> RestoreComment(int commentId, int? ownerId = null)
            => await Request<bool>("restoreComment", new MethodParams
            {
                {"comment_id", commentId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Edits a comment on a photo.
        /// </summary>
        /// <param name="commentId">Comment ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the photo.</param>
        /// <param name="message">New text of the comment.</param>
        /// <param name="attachments">(Required if message is not set.) List of objects attached to the post.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditComment(int commentId, int? ownerId = null, string message = null,
            List<string> attachments = null) => await Request<bool>("editComment", new MethodParams
            {
                {"comment_id", commentId, true},
                {"owner_id", ownerId},
                {"message", message},
                {"attachments", string.Join(",", attachments ?? new List<string>())}
            });

        /// <summary>
        /// Edits a comment on a photo.
        /// </summary>
        /// <param name="commentId">Comment ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the photo.</param>
        /// <param name="message">New text of the comment.</param>
        /// <param name="attachments">(Required if message is not set.) List of objects attached to the post.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditComment(int commentId, int? ownerId = null, string message = null,
            List<IMediaAttachment> attachments = null)
            => await EditComment(commentId, ownerId, message, attachments?.GetCommentAttachments());

        /// <summary>
        /// Returns a list of tags on a photo.
        /// </summary>
        /// <param name="photoId">Photo ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the photo.</param>
        /// <param name="accessKey">Photo access key.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Tag"/> objects.</returns>
        public async Task<Response<List<Tag>>> GetTags(int photoId, int? ownerId = null, string accessKey = null)
            => await Request<List<Tag>>("getTags", new MethodParams
            {
                {"photo_id", photoId, true},
                {"owner_id", ownerId},
                {"access_key", accessKey}
            });

        /// <summary>
        /// Adds a tag on the photo.
        /// </summary>
        /// <param name="photoId">Photo ID. </param>
        /// <param name="userId">ID of the user to be tagged. </param>
        /// <param name="ownerId">ID of the user or community that owns the photo. </param>
        /// <param name="x">Upper left-corner coordinate of the tagged area (as a percentage of the photo's width). </param>
        /// <param name="y">Upper left-corner coordinate of the tagged area (as a percentage of the photo's height). </param>
        /// <param name="x2">Lower right-corner coordinate of the tagged area (as a percentage of the photo's width). </param>
        /// <param name="y2">Lower right-corner coordinate of the tagged area (as a percentage of the photo's height). </param>
        /// <returns>Returns the ID of the created tag.</returns>
        public async Task<Response<int>> PutTag(int photoId, int userId, int? ownerId = null, double x = 0.0,
            double y = 0.0, double x2 = 0.0, double y2 = 0.0) => await Request<int>("putTag", new MethodParams
            {
                {"photo_id", photoId, true},
                {"user_id", userId, true},
                {"owner_id", ownerId},
                {"x", $"{x}"},
                {"y", $"{y}"},
                {"x2", $"{x2}"},
                {"y2", $"{y2}"}
            });

        /// <summary>
        /// Removes a tag from a photo.
        /// </summary>
        /// <param name="photoId">Photo ID. </param>
        /// <param name="tagId">Tag ID. </param>
        /// <param name="ownerId">ID of the user or community that owns the photo.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> RemoveTag(int photoId, int tagId, int? ownerId = null)
            => await Request<bool>("removeTag", new MethodParams
            {
                {"photo_id", photoId, true},
                {"tag_id", tagId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Returns a list of photos with tags that have not been viewed.
        /// </summary>
        /// <param name="count">Number of photos to return. </param>
        /// <param name="offset">Offset needed to return a specific subset of photos.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Photo"/> objects.</returns>
        public async Task<Response<ItemsList<Photo>>> GetNewTags(int count = 20, int offset = 0)
            => await Request<ItemsList<Photo>>("getNewTags", new MethodParams
            {
                {"count", count, false, new[] {0, 100}},
                {"offset", offset}
            });

        #region Upload methods

        /// <summary>
        /// Uploads a photo to the album.
        /// </summary>
        /// <param name="photos">A dictionary of photos where the key is a photo-file name and the value is the photo data.</param>
        /// <param name="albumId">ID of the album to save photos to.</param>
        /// <param name="groupId">ID of the community to save photos to.</param>
        /// <param name="caption">Text describing the photo. 2048 digits max.</param>
        /// <param name="coords">Geo coordinates object.</param>
        /// <exception cref="ArgumentNullException">Thrown when a <c>photos</c> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when a <c>photos</c> is empty.</exception>
        /// <exception cref="InTouchException">Thrown when an exception has occurred while uploading the file.</exception>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Photo"/> objects.</returns>
        public async Task<Response<List<Photo>>> UploadAlbumPhoto(Dictionary<string, byte[]> photos, int? albumId = null,
            int? groupId = null,
            string caption = null, Coordinates coords = null)
        {
            if (photos == null)
            {
                throw new ArgumentNullException(nameof(photos));
            }

            if (!photos.Any())
            {
                throw new ArgumentException("The value cannot be empty.", nameof(photos));
            }

            var filesDict = new List<Tuple<string, byte[], string>>();
            var i = 1;

            foreach (var photo in photos.Where(p => p.Value != null && !string.IsNullOrEmpty(p.Key)).Take(5))
            {
                filesDict.Add($"file{i++}", photo.Value, photo.Key);
            }

            try
            {
                var uplServerResp = await GetUploadServer(albumId, groupId);

                if (uplServerResp.IsError && !API.ThrowExceptionOnResponseError)
                {
                    throw new InTouchResponseErrorException(uplServerResp.Error.Message, uplServerResp.Error);
                }

                var uplRespRawJson = await API.UploadFile(uplServerResp.Data.UploadUrl, filesDict);
                var uplServerData = API.ParseUploadServerResponse<AlbumPhotoUploadResponse>(uplRespRawJson);

                return await Save(uplServerData, albumId, groupId, caption, coords);
            }
            catch (Exception ex)
            {
                throw new InTouchException("An exception has occurred while uploading album photos.", ex);
            }
        }

        /// <summary>
        /// Uploads a photo to the wall.
        /// </summary>
        /// <param name="photo">Photo data.</param>
        /// <param name="fileName">Photo file name.</param>
        /// <param name = "userId" > ID of the user on whose wall the photo will be saved.</param>
        /// <param name="groupId">ID of community on whose wall the photo will be saved.</param>
        /// <exception cref="ArgumentNullException">Thrown when a <c>photo</c> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a <c>fileName</c> is null.</exception>
        /// <exception cref="InTouchException">Thrown when an exception has occurred while uploading the file.</exception>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Photo"/> objects.</returns>
        public async Task<Response<List<Photo>>> UploadWallPhoto(byte[] photo, string fileName, int? groupId = null,
            int? userId = null)
        {
            if (photo == null)
            {
                throw new ArgumentNullException(nameof(photo));
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            try
            {
                var uplServerResp = await GetWallUploadServer(groupId);

                if (uplServerResp.IsError && !API.ThrowExceptionOnResponseError)
                {
                    throw new InTouchResponseErrorException(uplServerResp.Error.Message, uplServerResp.Error);
                }

                var uplRespRawJson = await API.UploadFile(uplServerResp.Data.UploadUrl,
                    new List<Tuple<string, byte[], string>>
                    {
                        {"photo", photo, fileName}
                    });
                var uplServerData = API.ParseUploadServerResponse<PhotoUploadResponse>(uplRespRawJson);

                return await SaveWallPhoto(uplServerData, userId, groupId);
            }
            catch (Exception ex)
            {
                throw new InTouchException("An exception has occurred while uploading wall photo.", ex);
            }
        }

        /// <summary>
        /// Uploads new owner profile photo.
        /// </summary>
        /// <param name="photo">Photo data.</param>
        /// <param name="fileName">Photo file name.</param>
        /// <param name="ownerId">Identifier of a community or current user. Note that community id must be negative.</param>
        /// <param name="squeareCrop">The additional parameter in "x,y,w" format (where x and y are the thumbnail coordinates and w is the square size). In this case a square thumbnail will be prepared for a photo.</param>
        /// <exception cref="ArgumentNullException">Thrown when a <c>photo</c> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a <c>fileName</c> is null.</exception>
        /// <exception cref="InTouchException">Thrown when an exception has occurred while uploading the file.</exception>
        /// <returns>Returns an <see cref="OwnerPhoto"/> object.</returns>
        public async Task<Response<OwnerPhoto>> UploadOwnerPhoto(byte[] photo, string fileName, int? ownerId = null,
            string squeareCrop = null)
        {
            if (photo == null)
            {
                throw new ArgumentNullException(nameof(photo));
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            try
            {
                var uplServerResp = await GetOwnerPhotoUploadServer(ownerId);

                if (uplServerResp.IsError && !API.ThrowExceptionOnResponseError)
                {
                    throw new InTouchResponseErrorException(uplServerResp.Error.Message, uplServerResp.Error);
                }

                var uplRespRawJson =
                    await API.UploadFile(uplServerResp.Data.UploadUrl, new List<Tuple<string, byte[], string>>
                    {
                        {"photo", photo, fileName}
                    }, new Dictionary<string, string>
                    {
                        {"_square_crop", squeareCrop}
                    });
                var uplServerData = API.ParseUploadServerResponse<PhotoUploadResponse>(uplRespRawJson);

                return await SaveOwnerPhoto(uplServerData);

            }
            catch (Exception ex)
            {
                throw new InTouchException("An exception has occurred while uploading owner photo.", ex);
            }
        }

        /// <summary>
        /// Uploads photo to messages.
        /// </summary>
        /// <param name="photo">Photo data.</param>
        /// <param name="fileName">Photo file name.</param>
        /// <exception cref="ArgumentNullException">Thrown when a <c>photo</c> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a <c>fileName</c> is null.</exception>
        /// <exception cref="InTouchException">Thrown when an exception has occurred while uploading the file.</exception>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Photo"/> objects.</returns>
        public async Task<Response<List<Photo>>> UploadMessagesPhoto(byte[] photo, string fileName)
        {
            if (photo == null)
            {
                throw new ArgumentNullException(nameof(photo));
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            try
            {
                var uplServerResp = await GetMessagesUploadServer();

                if (uplServerResp.IsError && !API.ThrowExceptionOnResponseError)
                {
                    throw new InTouchResponseErrorException(uplServerResp.Error.Message, uplServerResp.Error);
                }

                var uplRespRawJson = await API.UploadFile(uplServerResp.Data.UploadUrl,
                    new List<Tuple<string, byte[], string>>
                    {
                        {"photo", photo, fileName}
                    });
                var uplServerData = API.ParseUploadServerResponse<PhotoUploadResponse>(uplRespRawJson);

                return await SaveMessagesPhoto(uplServerData);
            }
            catch (Exception ex)
            {
                throw new InTouchException("An exception has occurred while uploading messages photo.", ex);
            }
        }

        /// <summary>
        /// Uploads new market photo.
        /// </summary>
        /// <param name="photo">Photo data.</param>
        /// <param name="fileName">Photo file name.</param>
        /// <param name="groupId">Group Id for which you want to upload a market photo.</param>
        /// <param name="isMarketAlbumPhoto">True - to upload photo for product section; False - to upload photo for product item.</param>
        /// <param name="mainPhoto">Whether the photo is album cover.</param>
        /// <param name="cropX">X coordinate to crop.</param>
        /// <param name="cropY">Y coordinate to crop.</param>
        /// <param name="cropWidth">The image width after crop.</param>
        /// <exception cref="ArgumentNullException">Thrown when a <c>photo</c> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a <c>fileName</c> is null.</exception>
        /// <exception cref="InTouchException">Thrown when an exception has occurred while uploading the file.</exception>
        /// <returns>Returns object including server upload url.</returns>
        public async Task<Response<List<Photo>>> UploadMarketPhoto(byte[] photo, string fileName, int groupId,
            bool isMarketAlbumPhoto = false, bool mainPhoto = false, int? cropX = null, int? cropY = null,
            int cropWidth = 200)
        {
            if (photo == null)
            {
                throw new ArgumentNullException(nameof(photo));
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            try
            {
                var uplServerResp = await (isMarketAlbumPhoto
                    ? GetMarketAlbumUploadServer(groupId)
                    : GetMarketUploadServer(groupId, mainPhoto, cropX, cropY, cropWidth));

                if (uplServerResp.IsError && !API.ThrowExceptionOnResponseError)
                {
                    throw new InTouchResponseErrorException(uplServerResp.Error.Message, uplServerResp.Error);
                }

                var uplRespRawJson = await API.UploadFile(uplServerResp.Data.UploadUrl,
                    new List<Tuple<string, byte[], string>>
                    {
                        {"file", photo, fileName}
                    });
                var uplServerData = API.ParseUploadServerResponse<MarketPhotoUploadResponse>(uplRespRawJson);

                return await SaveMarketPhoto(uplServerData);
            }
            catch (Exception ex)
            {
                throw new InTouchException("An exception has occurred while uploading market photo.", ex);
            }
        }

        #endregion

        #endregion
    }
}