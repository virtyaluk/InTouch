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
using System.Net.Http;
using System.Threading.Tasks;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A base class for working with videos.
    /// </summary>
    public class VideoMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        public VideoMethods(InTouch api) : base(api, "video") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns detailed information about videos.
        /// </summary>
        /// <param name="ownerId">ID of the user or community that owns the video(s).</param>
        /// <param name="videos">
        /// Video IDs, in the following format:
        /// <example>[owner_id_media_id,owner_id_media_id]</example>
        /// Use a negative value to designate a community ID. 
        /// </param>
        /// <param name="albumId">ID of the album containing the video(s). </param>
        /// <param name="count">Number of videos to return. </param>
        /// <param name="offset">Offset needed to return a specific subset of videos.</param>
        /// <param name="extended">True — to return an extended response with additional fields.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Video"/> objects.</returns>
        public async Task<Response<ItemsList<Video>>> Get(int? ownerId = null, List<string> videos = null,
            int? albumId = null, int count = 100, int offset = 0, bool extended = false)
            => await Request<ItemsList<Video>>("get", new MethodParams
            {
                {"owner_id", ownerId},
                {"videos", videos},
                {"album_id", albumId},
                {"count", count, false, new[] {0, 200}},
                {"offset", offset},
                {"extended", extended}
            });

        /// <summary>
        /// Edits information about a video on a user or community page.
        /// </summary>
        /// <param name="methodParams">A <see cref="VideoEditParams"/> object with the params.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Edit(VideoEditParams methodParams)
            => await Request<bool>("edit", methodParams);

        /// <summary>
        /// Adds a video to a user or community page.
        /// </summary>
        /// <param name="videoId">Video ID. </param>
        /// <param name="ownerId">ID of the user or community that owns the video(s).</param>
        /// <param name="targetId">Identifier of a user or community to add a video to. Use a negative value to designate a community ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Add(int videoId, int ownerId, int? targetId = null)
            => await Request<bool>("add", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"video_id", videoId, true},
                {"target_id", targetId}
            });

        /// <summary>
        /// Returns a server address (required for upload) and video data.
        /// </summary>
        /// <param name="methodParams">A <see cref="VideoSaveParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="VideoServerInfo"/> object containing upload server data.</returns>
        public async Task<Response<VideoServerInfo>> Save(VideoSaveParams methodParams)
            => await Request<VideoServerInfo>("save", methodParams);

        /// <summary>
        /// Deletes a video from a user or community page.
        /// </summary>
        /// <param name="videoId">Video ID. </param>
        /// <param name="ownerId">ID of the user or community that owns the video(s).</param>
        /// <param name="targetId">Identifier of a user or community to add a video to. Use a negative value to designate a community ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Delete(int videoId, int? ownerId = null, int? targetId = null)
            => await Request<bool>("delete", new MethodParams
            {
                {"owner_id", ownerId},
                {"video_id", videoId, true},
                {"target_id", targetId}
            });

        /// <summary>
        /// Restores a previously deleted video.
        /// </summary>
        /// <param name="videoId">Video ID. </param>
        /// <param name="ownerId">ID of the user or community that owns the video(s).</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Restore(int videoId, int? ownerId = null)
            => await Request<bool>("restore", new MethodParams
            {
                {"owner_id", ownerId},
                {"video_id", videoId, true}
            });

        /// <summary>
        /// Returns a list of videos under the set search criterion.
        /// </summary>
        /// <param name="methodParams">A <see cref="VideoSearchParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Video"/> objects.</returns>
        public async Task<Response<ItemsList<Video>>> Search(VideoSearchParams methodParams)
            => await Request<ItemsList<Video>>("search", methodParams);


        /// <summary>
        /// Returns list of videos in which the user is tagged.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="count">Number of videos to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of videos.</param>
        /// <param name="extended">True — to return an extended response with additional fields.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Video"/> objects.</returns>
        public async Task<Response<ItemsList<Video>>> GetUserVideos(int? userId = null, int count = 20, int offset = 0,
            bool extended = false) => await Request<ItemsList<Video>>("getUserVideos", new MethodParams
            {
                {"user_id", userId},
                {"count", count, false, new[] {0, 100}},
                {"offset", offset},
                {"extended", extended}
            });

        /// <summary>
        /// Returns a list of video albums owned by a user or community.
        /// </summary>
        /// <param name="ownerId">ID of the user or community that owns the video album(s).</param>
        /// <param name="count">Number of video albums to return. </param>
        /// <param name="offset">Offset needed to return a specific subset of video albums.</param>
        /// <param name="extended">True — to return an extended response with additional fields.</param>
        /// <param name="needSystem">Whether the system albums needs to be returned.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="VideoAlbum"/> objects.</returns>
        public async Task<Response<ItemsList<VideoAlbum>>> GetAlbums(int? ownerId = null, int count = 50, int offset = 0,
            bool extended = false, bool needSystem = false)
            => await Request<ItemsList<VideoAlbum>>("getAlbums", new MethodParams
            {
                {"owner_id", ownerId},
                {"count", count, false, new[] {0, 100}},
                {"offset", offset},
                {"extended", extended},
                {"need_system", needSystem}
            });

        /// <summary>
        /// Returns video album info.
        /// </summary>
        /// <param name="albumId">Album ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the video album(s).</param>
        /// <returns>Returns a <see cref="VideoAlbum"/> object containing album info.</returns>
        public async Task<Response<VideoAlbum>> GetAlbumById(int albumId, int? ownerId = null)
            => await Request<VideoAlbum>("getAlbumById", new MethodParams
            {
                {"album_id", albumId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Creates an empty album for videos.
        /// </summary>
        /// <param name="title">Album title.</param>
        /// <param name="groupId">Community ID (if the album will be created in a community). </param>
        /// <param name="privacy">New access permissions for the album.</param>
        /// <returns>Returns the ID of the created album.</returns>
        public async Task<Response<int>> AddAlbum(string title, int? groupId = null, List<string> privacy = null)
            => await Request<int>("addAlbum", new MethodParams
            {
                {"group_id", groupId},
                {"title", title, true},
                {"privacy", privacy}
            }, false, "album_id");

        /// <summary>
        /// Edits the title of a video album.
        /// </summary>
        /// <param name="albumId">Album ID.</param>
        /// <param name="title">New album title.</param>
        /// <param name="groupId">Community ID (if the album edited is owned by a community).</param>
        /// <param name="privacy">New access permissions for the album.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditAlbum(int albumId, string title, int? groupId = null,
            List<string> privacy = null) => await Request<bool>("editAlbum", new MethodParams
            {
                {"album_id", albumId, true},
                {"title", title, true},
                {"group_id", groupId},
                {"privacy", privacy}
            });

        /// <summary>
        /// Deletes a video album.
        /// </summary>
        /// <param name="albumId">Album ID.</param>
        /// <param name="groupId">Community ID (if the album edited is owned by a community).</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DeleteAlbum(int albumId, int? groupId = null)
            => await Request<bool>("deleteAlbum", new MethodParams
            {
                {"album_id", albumId, true},
                {"group_id", groupId}
            });

        /// <summary>
        /// Reorders the album in the list of user video albums.
        /// </summary>
        /// <param name="albumId">Album ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the video album(s).</param>
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
        /// Reorders the video in the video album.
        /// </summary>
        /// <param name="methodParams">A <see cref="VideoReorderVideosParams"/> object with the params.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> ReorderVideos(VideoReorderVideosParams methodParams)
            => await Request<bool>("reorderVideos", methodParams);

        /// <summary>
        /// Adds the video to the album.
        /// </summary>
        /// <param name="videoId">Video ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the video(s).</param>
        /// <param name="albumId">Album ID.</param>
        /// <param name="targetId">Album owner Id.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> AddToAlbum(int videoId, int ownerId, int albumId, int? targetId = null)
            => await Request<bool>("addToAlbum", new MethodParams
            {
                {"video_id", videoId, true},
                {"owner_id", ownerId, true},
                {"album_id", albumId, true},
                {"target_id", targetId}
            });

        /// <summary>
        /// Adds the videos to the album.
        /// </summary>
        /// <param name="videoId">Video ID. </param>
        /// <param name="ownerId">ID of the user or community that owns the video(s).</param>
        /// <param name="albumIds">Album Ids.</param>
        /// <param name="targetId">Album owner Id.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> AddToAlbum(int videoId, int ownerId, List<int> albumIds, int? targetId = null)
            => await Request<bool>("addToAlbum", new MethodParams
            {
                {"video_id", videoId, true},
                {"owner_id", ownerId, true},
                {"album_id", string.Join(",", albumIds ?? new List<int>()), true},
                {"target_id", targetId}
            });

        /// <summary>
        /// Removes the video to the album.
        /// </summary>
        /// <param name="videoId">Video ID. </param>
        /// <param name="ownerId">ID of the user or community that owns the video(s).</param>
        /// <param name="albumId">Album ID.</param>
        /// <param name="targetId">Album owner Id.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> RemoveFromAlbum(int videoId, int ownerId, int albumId, int? targetId = null)
            => await Request<bool>("removeFromAlbum", new MethodParams
            {
                {"video_id", videoId, true},
                {"owner_id", ownerId, true},
                {"album_id", albumId, true},
                {"target_id", targetId}
            });

        /// <summary>
        /// Removes the videos to the album.
        /// </summary>
        /// <param name="videoId">Video ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the video(s).</param>
        /// <param name="albumIds">Album Ids.</param>
        /// <param name="targetId">Album owner Id.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> RemoveFromAlbum(int videoId, int ownerId, List<int> albumIds, int? targetId = null)
            => await Request<bool>("removeFromAlbum", new MethodParams
            {
                {"video_id", videoId, true},
                {"owner_id", ownerId, true},
                {"album_id", string.Join(",", albumIds ?? new List<int>()), true},
                {"target_id", targetId}
            });

        /// <summary>
        /// Returns a list of albums that contains the video.
        /// </summary>
        /// <param name="videoId">Video ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the video(s).</param>
        /// <param name="targetId">Album owner Id.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="VideoAlbum"/> objects.</returns>
        public async Task<Response<ItemsList<VideoAlbum>>> GetAlbumsByVideo(int videoId, int ownerId,
            int? targetId = null) => await Request<ItemsList<VideoAlbum>>("getAlbumsByVideo", new MethodParams
            {
                {"video_id", videoId, true},
                {"owner_id", ownerId, true},
                {"target_id", targetId},
                {"extended", true}
            });

        /// <summary>
        /// Returns a list of comments on a video.
        /// </summary>
        /// <param name="methodParams">A <see cref="VideoGetCommentsParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Comment"/> objects.</returns>
        public async Task<Response<ItemsList<Comment>>> GetComments(VideoGetCommentsParams methodParams)
            => await Request<ItemsList<Comment>>("getComments", methodParams);

        /// <summary>
        /// Adds a new comment on a video.
        /// </summary>
        /// <param name="methodParams">A <see cref="VideoCreateCommentParams"/> object with the params.</param>
        /// <returns>Returns the ID of the created comment.</returns>
        public async Task<Response<int>> CreateComment(VideoCreateCommentParams methodParams)
            => await Request<int>("createComment", methodParams);

        /// <summary>
        /// Deletes a comment on a video.
        /// </summary>
        /// <param name="commentId">ID of the comment to be deleted.</param>
        /// <param name="ownerId">ID of the user or community that owns the video. </param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DeleteComment(int commentId, int? ownerId = null)
            => await Request<bool>("deleteComment", new MethodParams
            {
                {"comment_id", commentId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Restores a previously deleted comment on a video.
        /// </summary>
        /// <param name="commentId">ID of the deleted comment.</param>
        /// <param name="ownerId">ID of the user or community that owns the video. </param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> RestoreComment(int commentId, int? ownerId = null)
            => await Request<bool>("restoreComment", new MethodParams
            {
                {"comment_id", commentId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Edits the text of a comment on a video.
        /// </summary>
        /// <param name="commentId">Comment ID. </param>
        /// <param name="ownerId">ID of the user or community that owns the video.</param>
        /// <param name="message">New comment text.</param>
        /// <param name="attachments">
        /// List of objects attached to the comment, in the following format:
        /// <example>[TypeOwnerId_MmediaId,TypeOwnerId_MediaId>]</example>
        /// Example:
        /// <example>photo100172_166443618,photo66748_265827614</example>
        /// </param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditComment(int commentId, int? ownerId = null, string message = null,
            List<string> attachments = null) => await Request<bool>("editComment", new MethodParams
            {
                {"comment_id", commentId, true},
                {"owner_id", ownerId},
                {"message", message},
                {"attachments", attachments}
            });

        /// <summary>
        /// Edits the text of a comment on a video.
        /// </summary>
        /// <param name="commentId">Comment ID. </param>
        /// <param name="ownerId">ID of the user or community that owns the video.</param>
        /// <param name="message">New comment text.</param>
        /// <param name="attachments">List of objects attached to the comment.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditComment(int commentId, int? ownerId = null, string message = null,
            List<IMediaAttachment> attachments = null)
            => await EditComment(commentId, ownerId, message, attachments.GetCommentAttachments());

        /// <summary>
        /// Returns a list of tags on a video.
        /// </summary>
        /// <param name="videoId">Video ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the video(s).</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Tag"/> objects.</returns>
        public async Task<Response<List<Tag>>> GetTags(int videoId, int? ownerId = null)
            => await Request<List<Tag>>("getTags", new MethodParams
            {
                {"video_id", videoId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Adds a tag on a video.
        /// </summary>
        /// <param name="videoId">Video ID.</param>
        /// <param name="userId">User ID</param>
        /// <param name="ownerId">ID of the user or community that owns the video(s).</param>
        /// <param name="taggedName">Tag text.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> PutTag(int videoId, int userId, int? ownerId = null, string taggedName = null)
            => await Request<bool>("putTag", new MethodParams
            {
                {"video_id", videoId, true},
                {"user_id", userId, true},
                {"owner_id", ownerId},
                {"tagged_name", taggedName}
            });

        /// <summary>
        /// Removes a tag from a video.
        /// </summary>
        /// <param name="videoId">Video ID.</param>
        /// <param name="tagId">Tag ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the video. </param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> RemoveTag(int videoId, int tagId, int? ownerId = null)
            => await Request<bool>("removeTag", new MethodParams
            {
                {"video_id", videoId},
                {"tag_id", tagId},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Returns a list of videos with tags that have not been viewed.
        /// </summary>
        /// <param name="count">Number of videos to return. </param>
        /// <param name="offset">Offset needed to return a specific subset of videos.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Video"/> objects.</returns>
        public async Task<Response<ItemsList<Video>>> GetNewTags(int count = 20, int offset = 0)
            => await Request<ItemsList<Video>>("getNewTags", new MethodParams
            {
                {"offset", offset},
                {"count", count, false, new[] {0, 100}}
            });

        /// <summary>
        /// Reports (submits a complaint about) a video.
        /// </summary>
        /// <param name="videoId">Video ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the video(s).</param>
        /// <param name="reason">Reason for the complaint.</param>
        /// <param name="comment">Comment describing the complaint.</param>
        /// <param name="searchQuery">(If the video was found in search results.) Search query string.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Report(int videoId, int ownerId, ReportTypes reason, string comment = null,
            string searchQuery = null) => await Request<bool>("report", new MethodParams
            {
                {"video_id", videoId, true},
                {"owner_id", ownerId, true},
                {"reason", (int) reason},
                {"comment", comment},
                {"search_query", searchQuery}
            });

        /// <summary>
        /// Reports (submits a complaint about) a comment on a video.
        /// </summary>
        /// <param name="commentId">ID of the comment being reported.</param>
        /// <param name="ownerId">ID of the user or community that owns the video. </param>
        /// <param name="reason">Reason for the complaint.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> ReportComment(int commentId, int ownerId, ReportTypes reason)
            => await Request<bool>("reportComment", new MethodParams
            {
                {"comment_id", commentId, true},
                {"owner_id", ownerId},
                {"reason", (int) reason}
            });

        /// <summary>
        /// Returns video catalog.
        /// </summary>
        /// <param name="count">Number of catalog blocks to return.</param>
        /// <param name="itemsCount">Number of videos in each block.</param>
        /// <param name="from">Parameter for requesting the next results page. Value for transmitting here is returned in the <see cref="VideoCatalog.Next"/> field in a reply.</param>
        /// <param name="extended">True — to return an extended response with additional fields.</param>
        /// <param name="filters">List of requested catalog sections.</param>
        /// <returns>Returns a <see cref="VideoCatalog"/> object that contains info about video catalog blocks.</returns>
        public async Task<Response<VideoCatalog>> GetCatalog(int count = 10, int itemsCount = 10, string from = null,
            bool extended = false, List<VideoCatalogFilterTypes> filters = null)
            => await Request<VideoCatalog>("getCatalog", new MethodParams
            {
                {"count", count, false, new[] {0, 16}},
                {"items_count", itemsCount, false, new[] {0, 16}},
                {"from", from},
                {"extended", extended},
                {"filters", filters}
            });

        /// <summary>
        /// Returns a separate catalog section.
        /// </summary>
        /// <param name="sectionId"><see cref="VideoCatalogBlock.Id"/> value returned with a block by the <see cref="GetCatalog"/> method.</param>
        /// <param name="from"><see cref="VideoCatalogBlock.Next"/> value returned with a block by the <see cref="GetCatalog"/> method. </param>
        /// <param name="count">Number of blocks to return.</param>
        /// <param name="extended">True — to return an extended response with additional fields.</param>
        /// <returns>Returns a mixed list of <see cref="Video"/> and <see cref="VideoAlbum"/> objects.</returns>
        public async Task<Response<VideoCatalogBlock>> GetCatalogSection(string sectionId, string from, int count = 10,
            bool extended = false) => await Request<VideoCatalogBlock>("getCatalogSection", new MethodParams
            {
                {"section_id", sectionId, true},
                {"from", from, true},
                {"count", count, false, new[] {0, 16}},
                {"extended", extended}
            });

        /// <summary>
        /// Hides a video catalog section from a user.
        /// </summary>
        /// <param name="sectionId"><see cref="VideoCatalogBlock.Id"/> value returned with a block to hide by the <see cref="GetCatalog"/> method.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> HideCatalogSection(string sectionId)
            => await Request<bool>("hideCatalogSection", new MethodParams
            {
                {"section_id", sectionId, true}
            });

        #region Upload methods

        /// <summary>
        /// Uploads the video.
        /// </summary>
        /// <param name="videoData">Video data.</param>
        /// <param name="fileName">Video file name.</param>
        /// <param name="saveParams">A <see cref="VideoSaveParams"/> object with the params.</param>
        /// <exception cref="ArgumentNullException">Thrown when a <c>videoData</c> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a <c>fileName</c> is null.</exception>
        /// <exception cref="InTouchException">Thrown when an exception has occurred while uploading the file.</exception>
        /// <returns>Returns a <see cref="VideoServerInfo"/> object containing upload server data.</returns>
        public async Task<Video> UploadVideo(byte[] videoData, string fileName,
            VideoSaveParams saveParams = null)
        {
            if (videoData == null)
            {
                throw new ArgumentNullException(nameof(videoData));
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            try
            {
                var res = await UploadVideo(videoData, fileName, saveParams, false);

                return (Video)res;
            }
            catch (Exception ex)
            {
                throw new InTouchException("An exception has occurred while uploading video file.", ex);
            }
        }

        /// <summary>
        /// Adds video by given external link.
        /// </summary>
        /// <param name="saveParams">A <see cref="VideoSaveParams"/> object with the params.</param>
        /// <exception cref="ArgumentNullException">Thrown when a <c>saveParams</c> is null.</exception>
        /// <exception cref="NullReferenceException">Thrown when a <see cref="VideoSaveParams.Link"/> is null.</exception>
        /// <exception cref="InTouchException">Thrown when an exception has occurred while uploading the file.</exception>
        /// <returns>Returns a <see cref="VideoServerInfo"/> object containing upload server data.</returns>
        public async Task<Tuple<bool, VideoServerInfo>> UploadVideo(VideoSaveParams saveParams)
        {
            if (saveParams == null)
            {
                throw new ArgumentNullException(nameof(saveParams));
            }

            if (string.IsNullOrEmpty(saveParams.Link))
            {
                throw new NullReferenceException("Video link cannot be null or empty.");
            }

            try
            {
                var res = await UploadVideo(null, null, saveParams, true);

                return (Tuple<bool, VideoServerInfo>)res;
            }
            catch (Exception ex)
            {
                throw new InTouchException("An exception has occurred while adding video by link.", ex);
            }
        }

        private async Task<object> UploadVideo(object videoObj, string fileName, VideoSaveParams saveParams, bool byLink)
        {
            var uplServerResp = await Save(saveParams);

            if (uplServerResp.IsError && !API.ThrowExceptionOnResponseError)
            {
                throw new InTouchResponseErrorException(uplServerResp.Error.Message, uplServerResp.Error);
            }

            if (byLink)
            {
                var uplRespRawJson = await new HttpClient().GetStringAsync(uplServerResp.Data.UploadUrl);
                var resp = API.ParseUploadServerResponse<bool>(uplRespRawJson, "response");

                return Tuple.Create(resp, uplServerResp.Data);
            }
            else
            {
                var uplRespRawJson = await API.UploadFile(uplServerResp.Data.UploadUrl,
                    new List<Tuple<string, byte[], string>>
                    {
                        {"video_file", (byte[]) videoObj, fileName}
                    });
                var resp = API.ParseUploadServerResponse<VideoUploadResponse>(uplRespRawJson);

                return resp.GetVideo(uplServerResp.Data);
            }
        }

        #endregion

        #endregion
    }
}