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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ModernDev.InTouch.Helpers
{
    public class JsonNotificationItemsConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteNull();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var notifications = new List<NotificationItem>();
            var jArr = serializer.Deserialize<JArray>(reader);

            foreach (var jObj in jArr.OfType<JObject>())
            {
                var type = (string) jObj["type"];

                switch (type)
                {
                    case "follow":
                        notifications.Add(jObj.ToObject<FollowNotification>());
                        break;

                    case "friend_accepted":
                        notifications.Add(jObj.ToObject<FriendAcceptedNotification>());
                        break;

                    case "mention":
                        notifications.Add(jObj.ToObject<MentionNotification>());
                        break;

                    case "mention_comments":
                        notifications.Add(jObj.ToObject<MentionCommentsNotification>());
                        break;

                    case "wall":
                        notifications.Add(jObj.ToObject<WallNotification>());
                        break;

                    case "wall_publish":
                        notifications.Add(jObj.ToObject<WallPublishNotification>());
                        break;

                    case "comment_post":
                        notifications.Add(jObj.ToObject<CommentPostNotification>());
                        break;

                    case "comment_photo":
                        notifications.Add(jObj.ToObject<CommentPhotoNotification>());
                        break;

                    case "comment_video":
                        notifications.Add(jObj.ToObject<CommentVideoNotification>());
                        break;

                    case "reply_comment":
                        notifications.Add(jObj.ToObject<ReplyCommentNotification>());
                        break;

                    case "reply_comment_photo":
                        notifications.Add(jObj.ToObject<ReplyCommentPhotoNotification>());
                        break;

                    case "reply_comment_video":
                        notifications.Add(jObj.ToObject<ReplyCommentVideoNotification>());
                        break;

                    case "reply_comment_market":
                        notifications.Add(jObj.ToObject<ReplyCommentMarketNotification>());
                        break;

                    case "reply_topic":
                        notifications.Add(jObj.ToObject<ReplyTopicNotification>());
                        break;

                    case "like_post":
                        notifications.Add(jObj.ToObject<LikePostNotification>());
                        break;

                    case "like_comment":
                        notifications.Add(jObj.ToObject<LikeCommentNotification>());
                        break;

                    case "like_photo":
                        notifications.Add(jObj.ToObject<LikePhotoNotification>());
                        break;

                    case "like_video":
                        notifications.Add(jObj.ToObject<LikeVideoNotification>());
                        break;

                    case "like_comment_photo":
                        notifications.Add(jObj.ToObject<LikeCommentPhotoNotification>());
                        break;

                    case "like_comment_video":
                        notifications.Add(jObj.ToObject<LikeCommentVideoNotification>());
                        break;

                    case "like_comment_topic":
                        notifications.Add(jObj.ToObject<LikeCommentTopicNotification>());
                        break;

                    case "copy_post":
                        notifications.Add(jObj.ToObject<CopyPostNotification>());
                        break;

                    case "copy_photo":
                        notifications.Add(jObj.ToObject<CopyPhotoNotification>());
                        break;

                    case "copy_video":
                        notifications.Add(jObj.ToObject<CopyVideoNotification>());
                        break;

                    case "mention_comment_photo":
                        notifications.Add(jObj.ToObject<MentionCommentPhotoNotification>());
                        break;

                    case "mention_comment_video":
                        notifications.Add(jObj.ToObject<MentionCommentVideoNotification>());
                        break;
                }
            }

            return notifications;
        }

        public override bool CanConvert(Type objectType) => true;
    }
}