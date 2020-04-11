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
using Newtonsoft.Json.Linq;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A base class for working with dialogs\chats.
    /// </summary>
    public class MessagesMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagesMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal MessagesMethods(InTouch api) : base(api, "messages") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a list of the current user's incoming or outgoing private messages.
        /// </summary>
        /// <param name="methodParams">A <see cref="MessagesGetParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Message"/> objects.</returns>
        public async Task<Response<ItemsList<Message>>> Get(MessagesGetParams methodParams)
            => await Request<ItemsList<Message>>("get", methodParams);

        /// <summary>
        /// Returns a list of the current user's conversations.
        /// </summary>
        /// <param name="methodParams">A <see cref="MessagesGetDialogsParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="DialogsList"/> object containing dialogs.</returns>
        public async Task<Response<DialogsList>> GetDialogs(MessagesGetDialogsParams methodParams)
            => await Request<DialogsList>("getDialogs", methodParams);

        /// <summary>
        /// Returns messages by their IDs.
        /// </summary>
        /// <param name="messageIds">Message IDs.</param>
        /// <param name="previewLength">Number of characters after which to truncate a previewed message. To preview the full message, specify 0.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Message"/> objects.</returns>
        public async Task<Response<ItemsList<Message>>> GetById(List<int> messageIds, int previewLength = 0)
            => await Request<ItemsList<Message>>("getById", new MethodParams
            {
                {"message_ids", messageIds, true},
                {"preview_length", previewLength}
            });

        /// <summary>
        /// Returns a list of the current user's private messages that match search criteria.
        /// </summary>
        /// <param name="query">Search query string. </param>
        /// <param name="previewLength">Number of characters after which to truncate a previewed message. To preview the full message, specify 0.</param>
        /// <param name="count">Number of messages to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of messages.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Message"/> objects.</returns>
        public async Task<Response<ItemsList<Message>>> Search(string query, int previewLength = 0, int count = 20,
            int offset = 0) => await Request<ItemsList<Message>>("search", new MethodParams
            {
                {"q", query, true},
                {"preview_length", previewLength},
                {"offset", offset},
                {"count", count, false, new[] {0, 200}}
            });

        /// <summary>
        /// Returns message history for the specified user or group chat.
        /// </summary>
        /// <param name="methodParams">A <see cref="MessagesGetHistoryParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="Dialog"/> object containing messages history.</returns>
        public async Task<Response<Dialog>> GetHistory(MessagesGetHistoryParams methodParams)
            => await Request<Dialog>("getHistory", methodParams);

        /// <summary>
        /// Returns media files from the dialog or group chat.
        /// </summary>
        /// <param name="methodParams">A <see cref="MessagesGetHistoryAttachmentsParams"/> object with the params.</param>
        /// <returns>Returns an <see cref="AttachmentsHistory"/> object containing attachments history.</returns>
        public async Task<Response<AttachmentsHistory>> GetHistoryAttachments(
            MessagesGetHistoryAttachmentsParams methodParams)
            => await Request<AttachmentsHistory>("getHistoryAttachments", methodParams);

        /// <summary>
        /// Sends a message.
        /// </summary>
        /// <param name="methodParams">A <see cref="MessagesSendParams"/> object with the params.</param>
        /// <returns>Returns ID of the sent message.</returns>
        public async Task<Response<int>> Send(MessagesSendParams methodParams) => await Request<int>("send", methodParams);

        /// <summary>
        /// Sends a sticker.
        /// </summary>
        /// <param name="stickerId">Sticker ID.</param>
        /// <param name="userId">User ID.</param>
        /// <param name="domain">User's domain.</param>
        /// <param name="peerId">Peer ID.</param>
        /// <param name="chatId">Chat ID.</param>
        /// <returns>Returns ID of the sent message.</returns>
        public async Task<Response<int>> SendSticker(int stickerId, int? userId = null, string domain = null,
            int? peerId = null, int? chatId = null) => await Request<int>("sendSticker", new MethodParams
            {
                {"random_id", new Random().Next(10000, 99999)},
                {"sticker_id", stickerId, true},
                {"user_id", userId},
                {"domain", domain},
                {"peer_id", peerId},
                {"chat_id", chatId}
            });

        /// <summary>
        /// Deletes one or more messages.
        /// </summary>
        /// <param name="messageIds">Message IDs.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Delete(List<int> messageIds)
            => await Request<bool>("delete", new MethodParams
            {
                {"message_ids", messageIds}
            });

        /// <summary>
        /// Deletes all private messages in a conversation.
        /// </summary>
        /// <param name="userId">User ID. To clear a chat history use chat_id.</param>
        /// <param name="peerId">
        /// Peer id:
        /// - user_id for user;
        /// - 2000000000 + chat_id for chat;
        /// - -group_id for groups
        /// </param>
        /// <param name="count">Number of messages to delete.</param>
        /// <param name="offset">Offset needed to return a specific subset of messages.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DeleteDialog(int? userId = null, int? peerId = null, int count = 1,
            int offset = 0) => await Request<bool>("deleteDialog", new MethodParams
            {
                {"user_id", userId},
                {"peer_id", peerId},
                {"offset", offset},
                {"count", count, false, new[] {0, 10000}}
            });

        /// <summary>
        /// Restores a deleted message.
        /// </summary>
        /// <param name="messageId">ID of a previously-deleted message to restore.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Restore(int messageId)
            => await Request<bool>("restore", new MethodParams
            {
                {"message_id", messageId}
            });

        /// <summary>
        /// Marks messages as read.
        /// </summary>
        /// <param name="messageIds">Message IDs.</param>
        /// <param name="peerId">
        /// Peer id:
        /// - user_id for user;
        /// - 2000000000 + chat_id for chat;
        /// - -group_id for groups
        /// </param>
        /// <param name="startMessageId">Message Id from which mark messages.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> MarkAsRead(List<int> messageIds = null, int? peerId = null,
            int? startMessageId = null) => await Request<bool>("markAsRead", new MethodParams
            {
                {"message_ids", messageIds},
                {"peer_id", peerId},
                {"start_message_id", startMessageId}
            });

        /// <summary>
        /// Marks and unmarks messages as important (starred).
        /// </summary>
        /// <param name="messageIds">Message IDs.</param>
        /// <param name="important">True � to add a star (mark as important). False � to remove the star.</param>
        /// <returns>Return a list of IDs for successfully marked messages.</returns>
        public async Task<Response<List<int>>> MarkAsImportant(List<int> messageIds, bool important = true)
            => await Request<List<int>>("markAsImportant", new MethodParams
            {
                {"message_ids", messageIds, true},
                {"important", important}
            });

        /// <summary>
        /// Marks and unmarks dialog as important.
        /// </summary>
        /// <param name="peerId">Dialog Id.</param>
        /// <param name="important">True - to mark as important.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> MarkAsImportantDialog(int peerId, bool important)
            => await Request<bool>("markAsImportantDialog", new MethodParams
            {
                {"peer_id", peerId, true},
                {"important", important, true}
            });

        /// <summary>
        /// Marks and unmarks dialog as answered.
        /// </summary>
        /// <param name="peerId">Dialog Id.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> MarkAsAnsweredDialog(int peerId)
            => await Request<bool>("markAsAnsweredDialog", new MethodParams
            {
                {"peer_id", peerId, true}
            });

        /// <summary>
        /// Returns data required for connection to a Long Poll server.
        /// With Long Poll connection, you can immediately know about incoming messages and other events.
        /// </summary>
        /// <param name="needPTS">True � to return the pts field, needed for the <see cref="GetLongPollHistory"/> method. </param>
        /// <param name="groupId">Group ID (for community messages with a user access token). </param>
        /// <param name="lpVersion">Long Poll version. </param>
        /// <returns>Returns a <see cref="LongPollServerData"/> object. With such data you can connect to an instant message server to immediately receive incoming messages and other events.</returns>
        public async Task<Response<LongPollServerData>> GetLongPollServer(bool needPTS = false, int? groupId = null, int lpVersion = 0)
            => await Request<LongPollServerData>("getLongPollServer", new MethodParams
            {
                {"need_pts", needPTS},
                {"group_id", groupId},
                {"lp_version", lpVersion}
            });

        /// <summary>
        /// Returns updates in user's private messages.
        /// To speed up handling of private messages, it can be useful to cache previously loaded messages on a user's mobile device/desktop, to prevent re-receipt at each call. With this method, you can synchronize a local copy of the message list with the actual version.
        /// </summary>
        /// <param name="methodParams">A <see cref="MessagesGetLongPollHistoryParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="LongPollHistory"/> object containing updates in user's private messages.</returns>
        public async Task<Response<LongPollHistory>> GetLongPollHistory(MessagesGetLongPollHistoryParams methodParams)
            => await Request<LongPollHistory>("getLongPollHistory", methodParams);

        /// <summary>
        /// Returns information about a chat.
        /// </summary>
        /// <param name="chatId">Chat ID.</param>
        /// <param name="fields">Profile fields to return.</param>
        /// <param name="nameCase">Case for declension of user name and surname.</param>
        /// <returns>Returns a <see cref="Chat"/> object.</returns>
        public async Task<Response<Chat>> GetChat(int chatId, List<UserProfileFields> fields = null,
            NameCases nameCase = NameCases.Nominative) => await Request<Chat>("getChat", new MethodParams
            {
                {"chat_id", chatId},
                {
                    "fields",
                    fields == null || !fields.Any() ? new List<UserProfileFields> {UserProfileFields.Nickname} : fields
                },
                {"name_case", Utils.ToEnumString(nameCase)}
            });

        /// <summary>
        /// Returns information about a chat.
        /// </summary>
        /// <param name="chatIds">Chat IDs.</param>
        /// <param name="fields">Profile fields to return.</param>
        /// <param name="nameCase">Case for declension of user name and surname.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Chat"/> objects.</returns>
        public async Task<Response<List<Chat>>> GetChat(List<int> chatIds, List<UserProfileFields> fields = null,
            NameCases nameCase = NameCases.Nominative) => await Request<List<Chat>>("getChat", new MethodParams
            {
                {"chat_ids", chatIds},
                {
                    "fields",
                    fields == null || !fields.Any() ? new List<UserProfileFields> {UserProfileFields.Nickname} : fields
                },
                {"name_case", Utils.ToEnumString(nameCase)}
            });

        /// <summary>
        /// Creates a chat with several participants.
        /// </summary>
        /// <param name="userIds">IDs of the users to be added to the chat.</param>
        /// <param name="title">Chat title.</param>
        /// <returns>Returns the ID of the created chat.</returns>
        public async Task<Response<int>> CreateChat(List<int> userIds, string title = null)
            => await Request<int>("createChat", new MethodParams
            {
                {"user_ids", userIds, true},
                {"title", title}
            });

        /// <summary>
        /// Edits the title of a chat.
        /// </summary>
        /// <param name="chatId">Chat ID.</param>
        /// <param name="title">New title of the chat.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> EditChat(int chatId, string title)
            => await Request<bool>("editChat", new MethodParams
            {
                {"chat_id", chatId, true},
                {"title", title, true}
            });

        /// <summary>
        /// Returns a list of IDs of users participating in a chat.
        /// </summary>
        /// <param name="chatId">Chat ID.</param>
        /// <param name="fields">Profile fields to return.</param>
        /// <param name="nameCase">Case for declension of user name and surname.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="User"/> objects.</returns>
        public async Task<Response<List<User>>> GetChatUsers(int chatId, List<UserProfileFields> fields = null,
            NameCases nameCase = NameCases.Nominative) => await Request<List<User>>("getChatUsers", new MethodParams
            {
                {"chat_id", chatId, true},
                {
                    "fields",
                    fields == null || !fields.Any() ? new List<UserProfileFields> {UserProfileFields.Nickname} : fields
                },
                {"name_case", Utils.ToEnumString(nameCase)}
            });

        /// <summary>
        /// Changes the status of a user as typing in a conversation.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="peerId">
        /// Peer id:
        /// - user_id for user;
        /// - 2000000000 + chat_id for chat;
        /// - -group_id for groups
        /// </param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> SetActivity(int? userId = null, int? peerId = null)
            => await Request<bool>("setActivity", new MethodParams
            {
                {"user_id", userId},
                {"peer_id", peerId},
                {"type", "typing"}
            });

        /// <summary>
        /// Returns a list of the current user's conversations that match search criteria.
        /// </summary>
        /// <param name="query">Search query string.</param>
        /// <param name="limit">The number of dialogs to return.</param>
        /// <param name="fields">Profile fields to return.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="IChatable"/> objects.</returns>
        public async Task<Response<List<IChatable>>> SearchDialogs(string query = null, int limit = 20,
            List<UserProfileFields> fields = null)
        {
            var res = new List<IChatable>();
            var response = await Request<JArray>("searchDialogs", new MethodParams
            {
                {"q", query},
                {"limit", limit},
                {
                    "fields",
                    fields == null || !fields.Any() ? new List<UserProfileFields> {UserProfileFields.Nickname} : fields
                }
            });

            if (!response.IsError)
            {
                foreach (var jObj in response.Data.OfType<JObject>())
                {
                    var type = (string) jObj["type"];

                    if (type == "profile")
                    {
                        res.Add(jObj.ToObject<User>());
                    } else if (type == "page")
                    {
                        res.Add(jObj.ToObject<Group>());
                    } else if (type == "chat")
                    {
                        res.Add(jObj.ToObject<Chat>());
                    }
                }
            }

            return new Response<List<IChatable>>(response.Error, res, response.Raw);
        }

        /// <summary>
        /// Adds a new user to a chat.
        /// </summary>
        /// <param name="chatId">Chat ID.</param>
        /// <param name="userId">ID of the user to be added to the chat.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> AddChatUser(int chatId, int userId)
            => await Request<bool>("addChatUser", new MethodParams
            {
                {"chat_id", chatId, true},
                {"user_id", userId, true}
            });

        /// <summary>
        /// Allows the current user to leave a chat or, if the current user started the chat, allows the user to remove another user from the chat.
        /// </summary>
        /// <param name="chatId">Chat ID.</param>
        /// <param name="userId">ID of the user to be removed from the chat.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> RemoveChatUser(int chatId, int userId)
            => await Request<bool>("removeChatUser", new MethodParams
            {
                {"chat_id", chatId, true},
                {"user_id", userId, true}
            });

        /// <summary>
        /// Returns a user's current status and date of last activity.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <returns>Returns <see cref="LastActivity"/> object containing user's current status and date of the user's last activity.</returns>
        public async Task<Response<LastActivity>> GetLastActivity(int userId)
            => await Request<LastActivity>("getLastActivity", new MethodParams
            {
                {"user_id", userId}
            });

        /// <summary>
        /// Sets a previously-uploaded picture as the cover picture of a chat.
        /// To upload the picture, use <see cref="PhotosMethods.GetChatUploadServer"/>.
        /// </summary>
        /// <param name="uploadServerResponse">Upload URL from the response field returned by the <see cref="PhotosMethods.GetChatUploadServer"/> method upon successfully uploading an image. </param>
        /// <returns>Returns <see cref="NewChatPhoto"/> object containing Id of the system message sent and a <see cref="Chat"/> object.</returns>
        public async Task<Response<NewChatPhoto>> SetChatPhoto(string uploadServerResponse)
            => await Request<NewChatPhoto>("setChatPhoto", new MethodParams
            {
                {"file", uploadServerResponse, true}
            });

        /// <summary>
        /// Deletes a chat's cover picture.
        /// </summary>
        /// <param name="chatId">Chat ID.</param>
        /// <returns>Returns <see cref="NewChatPhoto"/> object containing Id of the system message sent and a <see cref="Chat"/> object.</returns>
        public async Task<Response<NewChatPhoto>> DeleteChatPhoto(int chatId)
            => await Request<NewChatPhoto>("deleteChatPhoto", new MethodParams
            {
                {"chat_id", chatId}
            });

        /// <summary>
        /// Denies sending message from community to the current user.
        /// </summary>
        /// <param name="groupId">Community ID.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> DenyMessagesFromGroup(int groupId)
            => await Request<bool>("denyMessagesFromGroup", new MethodParams
            {
                {"group_id", groupId, true}
            });

        /// <summary>
        /// Allows sending messages from community to the current user.
        /// </summary>
        /// <param name="groupId">Community ID.</param>
        /// <param name="key">Random string, can be used for the user identification. It returns with message_allow event in Callback API. </param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> AllowMessagesFromGroup(int groupId, string key = null)
            => await Request<bool>("allowMessagesFromGroup", new MethodParams
            {
                {"group_id", groupId, true},
                {"key", key}
            });

        /// <summary>
        /// Returns information whether sending messages from the community to current user is allowed.
        /// </summary>
        /// <param name="groupId">Community ID.</param>
        /// <param name="userId">User ID.</param>
        /// <returns>Returns True if messages are allowed and False if not.</returns>
        public async Task<Response<bool>> IsMessagesFromGroupAllowed(int groupId, int userId)
            => await Request<bool>("isMessagesFromGroupAllowed", new MethodParams
            {
                {"group_id", groupId, true},
                {"user_id", userId, true}
            }, false, "is_allowed");

        #region Upload methods

        /// <summary>
        /// Uploads the new chat photo.
        /// </summary>
        /// <param name="photo">Photo data.</param>
        /// <param name="fileName">Photo file name.</param>
        /// <param name="chatId">ID of the chat for which you want to upload a cover photo.</param>
        /// <param name="cropX">X coordinate to crop.</param>
        /// <param name="cropY">Y coordinate to crop.</param>
        /// <param name="cropWidth">Width (in pixels) of the photo after cropping</param>
        /// <exception cref="ArgumentNullException">Thrown when a <c>photo</c> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a <c>fileName</c> is null.</exception>
        /// <exception cref="InTouchException">Thrown when an exception has occurred while uploading the file.</exception>
        /// <returns>Returns <see cref="NewChatPhoto"/> object containing Id of the system message sent and a <see cref="Chat"/> object.</returns>
        public async Task<Response<NewChatPhoto>> UploadChatPhoto(byte[] photo, string fileName, int chatId,
            int? cropX = null, int? cropY = null,
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
                var uplServerResp = await API.Photos.GetChatUploadServer(chatId, cropX, cropY, cropWidth);

                if (uplServerResp.IsError && !API.ThrowExceptionOnResponseError)
                {
                    throw new InTouchResponseErrorException(uplServerResp.Error.Message, uplServerResp.Error);
                }

                var uplRespRawJson = await API.UploadFile(uplServerResp.Data.UploadUrl,
                    new List<Tuple<string, byte[], string>>
                    {
                        {"file", photo, fileName}
                    });
                var uplServerData = API.ParseUploadServerResponse<string>(uplRespRawJson, "response");

                return await SetChatPhoto(uplServerData);
            }
            catch (Exception ex)
            {
                throw new InTouchException("An exception has occurred while uploading chat photo.", ex);
            }
        }

        #endregion

        #endregion
    }
}