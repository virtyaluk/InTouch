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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="Message"/> class describes a private message.
    /// </summary>
    [DebuggerDisplay("Message {Id}, {Title}")]
    [DataContract]
    public partial class Message
    {
        #region Properties

        /// <summary>
        /// Message ID. (Not returned for forwarded messages.) 
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// For an incoming message, the user ID of the author. For an outgoing message, the user ID of the receiver. 
        /// </summary>
        [DataMember]
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("from_id")]
        public int FromId { get; set; }

        /// <summary>
        /// Date when the message was sent. 
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Message status (False — not read, True — read). (Not returned for forwarded messages.) 
        /// </summary>
        [DataMember]
        [JsonProperty("read_state")]
        [JsonConverter(typeof(JsonBoolConverter))]
        public bool IsRead { get; set; }

        /// <summary>
        /// Message type (False — received, True — sent). (Not returned for forwarded messages.)
        /// </summary>
        [DataMember]
        [JsonProperty("out")]
        [JsonConverter(typeof(JsonBoolConverter))]
        public bool IsSent { get; set; }

        /// <summary>
        /// Title of message or chat.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Body of the message. 
        /// </summary>
        [DataMember]
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("geo")]
        public Geo Geo { get; set; }

        /// <summary>
        /// Array of media-attachments.
        /// </summary>
        [DataMember]
        [JsonProperty("attachments")]
        [JsonConverter(typeof(JsonAttachmentsConverter))]
        public ReadOnlyCollection<IMediaAttachment> Attachments { get; set; }

        /// <summary>
        /// Array of forwarded messages (if any).
        /// </summary>
        [DataMember]
        [JsonProperty("fwd_messages")]
        public List<Message> ForwardedMessages { get; set; }

        /// <summary>
        /// Whether the message contains smiles (False — no, True — yes). 
        /// </summary>
        [DataMember]
        [JsonProperty("emoji")]
        [JsonConverter(typeof(JsonBoolConverter))]
        public bool HasEmoji { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("important")]
        [JsonConverter(typeof(JsonBoolConverter))]
        public bool IsImportant { get; set; }

        /// <summary>
        /// Whether the message is deleted (False — no, True — yes). 
        /// </summary>
        [DataMember]
        [JsonProperty("deleted")]
        [JsonConverter(typeof(JsonBoolConverter))]
        public bool IsDeleted { get; set; }

        #region Multidialog Properties

        /// <summary>
        /// Chat ID. 
        /// </summary>
        [DataMember]
        [JsonProperty("chat_id")]
        public int ChatId { get; set; }

        /// <summary>
        /// User IDs of chat participants. 
        /// </summary>
        [DataMember]
        [JsonProperty("chat_active")]
        public List<int> ChatActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("push_settings")]
        public PushSettings PushSettings { get; set; }

        /// <summary>
        /// Number of chat participants. 
        /// </summary>
        [DataMember]
        [JsonProperty("users_count")]
        public int UsersCount { get; set; }

        /// <summary>
        /// ID of user who started the chat. 
        /// </summary>
        [DataMember]
        [JsonProperty("admin_id")]
        public int AdminId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("action")]
        [JsonConverter(typeof (StringEnumConverter))]
        public ChatActions Action { get; set; } = ChatActions.None;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("action_mid")]
        public int ActionMId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("action_email")]
        public string ActionEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("action_text")]
        public string ActionText { get; set; }

        /// <summary>
        /// URL of chat image with width size of 50px. 
        /// </summary>
        [DataMember]
        [JsonProperty("photo_50")]
        public string Photo50 { get; set; }

        /// <summary>
        /// URL of chat image with width size of 100px. 
        /// </summary>
        [DataMember]
        [JsonProperty("photo_100")]
        public string Photo100 { get; set; }

        /// <summary>
        /// URL of chat image with width size of 200px. 
        /// </summary>
        [DataMember]
        [JsonProperty("photo_200")]
        public string Photo200 { get; set; }

        #endregion

        #region Extra fields

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("random_id")]
        public int RandomId { get; set; }

        #endregion

        #endregion
    }
}
