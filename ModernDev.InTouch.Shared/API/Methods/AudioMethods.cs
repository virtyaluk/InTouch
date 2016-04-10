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

namespace ModernDev.InTouch
{
    /// <summary>
    /// A base class for working with audio.
    /// </summary>
    public class AudioMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal AudioMethods(InTouch api) : base(api, "audio") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a list of audio files of a user or community.
        /// </summary>
        /// <param name="ownerId">ID of the user or community that owns the audio file. Use a negative value to designate a community ID. </param>
        /// <param name="albumId">Audio album ID.</param>
        /// <param name="audioIds">IDs of the audio files to return.</param>
        /// <param name="count">Number of audio files to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of audio files.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Audio"/> objects.</returns>
        public async Task<Response<ItemsList<Audio>>> Get(int? ownerId = null, int? albumId = null,
            List<int> audioIds = null, int count = 100, int offset = 0)
            => await Request<ItemsList<Audio>>("get", new MethodParams
            {
                {"owner_id", ownerId},
                {"album_id", albumId},
                {"audio_ids", audioIds},
                {"offset", offset},
                {"count", count, false, new[] {0, 6000}}
            });

        /// <summary>
        /// Returns information about audio files by their IDs.
        /// </summary>
        /// <param name="audios">
        /// Audio file IDs, in the following format:
        /// <code>{owner_id}_{audio_id}</code>
        /// </param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Audio"/> objects.</returns>
        public async Task<Response<List<Audio>>> GetById(List<string> audios)
            => await Request<List<Audio>>("getById", new MethodParams
            {
                {"audios", audios, true}
            });

        /// <summary>
        /// Returns information about audio files by their IDs.
        /// </summary>
        /// <param name="audios">Dictionary of <see cref="KeyValuePair{TKey,TValue}"/> where the value is audio Id and the key is owner Id.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Audio"/> objects.</returns>
        public async Task<Response<List<Audio>>> GetById(Dictionary<int, int> audios)
            => await GetById(audios?.Select(kvp => $"{kvp.Key}_{kvp.Value}").ToList());

        /// <summary>
        /// Returns lyrics associated with an audio file.
        /// </summary>
        /// <param name="lyricsId">Lyrics ID.</param>
        /// <returns>Returns a <see cref="Lyrics"/> object.</returns>
        public async Task<Response<Lyrics>> GetLyrics(int lyricsId) => await Request<Lyrics>("getLyrics",
            new MethodParams
            {
                {"lyrics_id", lyricsId}
            });

        /// <summary>
        /// Returns a list of audio files.
        /// </summary>
        /// <param name="methodParams">A <see cref="AudioSearchParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Audio"/> objects.</returns>
        public async Task<Response<ItemsList<Audio>>> Search(AudioSearchParams methodParams)
            => await Request<ItemsList<Audio>>("search", methodParams);

        /// <summary>
        /// Returns the server address to upload audio files.
        /// </summary>
        /// <returns>Returns a <see cref="ServerInfo"/> object with an target upload url.</returns>
        public async Task<Response<ServerInfo>> GetUploadServer() => await Request<ServerInfo>("getUploadServer");

        /// <summary>
        /// Saves audio files after successful uploading.
        /// </summary>
        /// <param name="uploadResponse">Upload server response.</param>
        /// <param name="artist">The name of the artist. By default, this is obtained from ID3 tags. </param>
        /// <param name="title">The title of the audio file. By default, this is obtained from ID3 tags. </param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Audio"/> objects.</returns>
        public async Task<Response<ItemsList<Audio>>> Save(AudioUploadResponse uploadResponse, string artist = null,
            string title = null) => await Request<ItemsList<Audio>>("save", new MethodParams
            {
                {"server", uploadResponse?.Server, true},
                {"audio", uploadResponse?.Audio, true},
                {"hash", uploadResponse?.Hash, true},
                {"artist", artist},
                {"title", title}
            });

        /// <summary>
        /// Copies an audio file to a user page or community page.
        /// </summary>
        /// <param name="audioId">Audio file ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the audio file.</param>
        /// <param name="groupId">Community ID, needed when adding the audio file to a community.</param>
        /// <param name="albumId">Audio album Id.</param>
        /// <returns>Returns the ID of the created audio file.</returns>
        public async Task<Response<int>> Add(int audioId, int ownerId, int? groupId = null, int? albumId = null)
            => await Request<int>("add", new MethodParams
            {
                {"audio_id", audioId, true},
                {"owner_id", ownerId, true},
                {"group_id", groupId},
                {"album_id", albumId}
            });

        /// <summary>
        /// Deletes an audio file from a user page or community page.
        /// </summary>
        /// <param name="audioId">Audio file ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the audio file.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Delete(int audioId, int ownerId) => await Request<bool>("delete",
            new MethodParams
            {
                {"audio_id", audioId},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Edits an audio file on a user or community page.
        /// </summary>
        /// <param name="methodParams">A <see cref="AudioEditParams"/> object with the params.</param>
        /// <returns>If lyrics were entered by the user, returns lyrics Id. Otherwise, returns 0.</returns>
        public async Task<Response<int>> Edit(AudioEditParams methodParams) => await Request<int>("edit", methodParams);

        /// <summary>
        /// Reorders an audio file, placing it between other specified audio files.
        /// </summary>
        /// <param name="audioId">Audio file ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the audio file.</param>
        /// <param name="before">ID of the audio file before which to place the audio file.</param>
        /// <param name="after">ID of the audio file after which to place the audio file.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Reorder(int audioId, int? ownerId = null, int? before = null, int? after = null)
            => await Request<bool>("reorder", new MethodParams
            {
                {"audio_id", audioId, true},
                {"owner_id", ownerId},
                {"before", before},
                {"after", after}
            });

        /// <summary>
        /// Restores a deleted audio file.
        /// </summary>
        /// <param name="audioId">Audio file ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the audio file.</param>
        /// <returns>Returns an <see cref="Audio"/> object.</returns>
        public async Task<Response<Audio>> Restore(int audioId, int? ownerId = null)
            => await Request<Audio>("restore", new MethodParams
            {
                {"audio_id", audioId, true},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Returns a list of audio albums of a user or community.
        /// </summary>
        /// <param name="ownerId">ID of the user or community that owns the audio file.</param>
        /// <param name="count">Number of albums to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of albums.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="AudioAlbum"/> objects.</returns>
        public async Task<Response<ItemsList<AudioAlbum>>> GetAlbums(int? ownerId = null, int count = 50, int offset = 0)
            => await Request<ItemsList<AudioAlbum>>("getAlbums", new MethodParams
            {
                {"owner_id", ownerId},
                {"offset", offset},
                {"count", count, false, new[] {0, 100}}
            });

        /// <summary>
        /// Creates an empty audio album.
        /// </summary>
        /// <param name="title">Album title.</param>
        /// <param name="groupId">Community ID (if the album will be created in a community).</param>
        /// <returns>Returns the ID of the created album.</returns>
        public async Task<Response<int>> AddAlbum(string title, int? groupId = null)
            => await Request<int>("addAlbum", new MethodParams
            {
                {"title", title, true},
                {"group_id", groupId}
            });

        /// <summary>
        /// Edits the title of an audio album.
        /// </summary>
        /// <param name="albumId">Album ID.</param>
        /// <param name="title">New album title.</param>
        /// <param name="groupId">ID of the community where the album is located.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditAlbum(int albumId, string title, int? groupId = null)
            => await Request<bool>("editAlbum", new MethodParams
            {
                {"album_id", albumId, true},
                {"title", title, true},
                {"group_id", groupId}
            });

        /// <summary>
        /// Deletes an audio album.
        /// </summary>
        /// <param name="albumId">Album ID.</param>
        /// <param name="groupId">ID of the community where the album is located.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DeleteAlbum(int albumId, int? groupId = null)
            => await Request<bool>("deleteAlbum", new MethodParams
            {
                {"album_id", albumId, true},
                {"group_id", groupId}
            });

        /// <summary>
        /// Moves audio files to an album.
        /// </summary>
        /// <param name="audioIds">IDs of the audio files to be moved.</param>
        /// <param name="albumId">ID of the album to which the audio files will be moved.</param>
        /// <param name="groupId">ID of the community where the audio files are located. By default, current user ID. </param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> MoveToAlbum(List<int> audioIds, int? albumId = null, int? groupId = null)
            => await Request<bool>("moveToAlbum", new MethodParams
            {
                {"audio_ids", audioIds, true},
                {"album_id", albumId},
                {"group_id", groupId}
            });

        /// <summary>
        /// Activates an audio broadcast to the status of a user or community.
        /// </summary>
        /// <param name="audio">ID of the audio file to be shown in status (e.g., 1_190442705). If the parameter is not set, the audio status of given communities and user will be deleted. </param>
        /// <param name="targetIds">IDs of communities and user whose statuses will be included in the broadcast. Use a negative value to designate a community ID. By default, current user ID.</param>
        /// <returns>Returns a <see cref="List{T}"/> of user Ids.</returns>
        public async Task<Response<List<int>>> SetBroadcast(string audio, List<int> targetIds)
            => await Request<List<int>>("setBroadcast", new MethodParams
            {
                {"audio", audio},
                {"target_ids", targetIds}
            });

        /// <summary>
        /// Returns a list of the user's friends that are broadcasting music in their statuses.
        /// </summary>
        /// <param name="active">True — to return only friends that are broadcasting at the moment.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<List<User>>> GetFriendsBroadcastList(bool active = true)
            => await Request<List<User>>("getBroadcastList", new MethodParams
            {
                {"active", active},
                {"filter", "friends"}
            });

        /// <summary>
        /// Returns a list of the communities that are broadcasting music in their statuses.
        /// </summary>
        /// <param name="active">True — to return only communities that are broadcasting at the moment.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Group"/> objects.</returns>
        public async Task<Response<List<Group>>> GetGroupsBroadcastList(bool active = true)
            => await Request<List<Group>>("getBroadcastList", new MethodParams
            {
                {"active", active},
                {"filter", "groups"}
            });

        /// <summary>
        /// Returns a list of suggested audio files based on a user's playlist or a particular audio file.
        /// </summary>
        /// <param name="targetAudio">Use to get recommendations based on a particular audio file. The ID of the user or community that owns an audio file and that audio file's ID, separated by an underscore.</param>
        /// <param name="userId">Use to get recommendations based on a user's playlist. User ID. By default, the current user ID.</param>
        /// <param name="count">Number of audio files to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of audio files.</param>
        /// <param name="shuffle">True - shuffle on.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Audio"/> objects.</returns>
        public async Task<Response<ItemsList<Audio>>> GetRecommendations(string targetAudio = null, int? userId = null,
            int count = 100, int offset = 0, bool shuffle = true)
            => await Request<ItemsList<Audio>>("getRecommendations", new MethodParams
            {
                {"target_audio", targetAudio},
                {"user_id", userId},
                {"offset", offset},
                {"count", count, false, new[] {0, 1000}},
                {"shuffle", shuffle}
            });

        /// <summary>
        /// Returns a list of audio files from the "Popular".
        /// </summary>
        /// <param name="onlyEng">True - to return only foreign audio files; False — to return all audio files.</param>
        /// <param name="genre">Genre.</param>
        /// <param name="count">Number of audio files to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of audio files.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Audio"/> objects.</returns>
        public async Task<Response<List<Audio>>> GetPopular(bool onlyEng = true, AudioGenres genre = AudioGenres.Other,
            int count = 100, int offset = 0) => await Request<List<Audio>>("getPopular", new MethodParams
            {
                {"only_eng", onlyEng},
                {"genre_id", (int) genre},
                {"count", count, false, new[] {0, 1000}},
                {"offset", offset}
            });

        /// <summary>
        /// Returns the total number of audio files on a user or community page.
        /// </summary>
        /// <param name="ownerId">ID of the user or community that owns the audio files. By default, current user ID.</param>
        /// <returns></returns>
        public async Task<Response<int>> GetCount(int ownerId) => await Request<int>("getCount",
            new MethodParams
            {
                {"owner_id", ownerId, true}
            });

        #region Upload methods

        public async Task<Response<ItemsList<Audio>>> UploadAudio(byte[] audio, string fileName, string artist = null,
            string title = null)
        {
            if (audio == null)
            {
                throw new ArgumentNullException(nameof(audio));
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            try
            {
                var uplServerResp = await GetUploadServer();

                if (uplServerResp.IsError && !API.ThrowExceptionOnResponseError)
                {
                    throw new InTouchResponseErrorException(uplServerResp.Error.Message, uplServerResp.Error);
                }

                var uplRespRawJson = await API.UploadFile(uplServerResp.Data.UploadUrl,
                    new List<Tuple<string, byte[], string>>
                    {
                        {"file", audio, fileName}
                    });
                var uplServerData = API.ParseUploadServerResponse<AudioUploadResponse>(uplRespRawJson);

                //System.Net.WebUtility.UrlDecode
                return await Save(uplServerData, artist, title);
            }
            catch (Exception ex)
            {
                throw new InTouchException("An exception has occurred while uploading audio file.", ex);
            }
        }

        #endregion

        #endregion
    }
}