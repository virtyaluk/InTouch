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
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ModernDev.InTouch.Helpers
{
    public class JsonAttachmentsConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteNull();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var list = new List<IMediaAttachment>();
            var jArray = serializer.Deserialize<JArray>(reader);

            foreach (var obj in jArray.OfType<JObject>())
            {
                switch ((string) obj["type"])
                {
                    case "album":
                        list.Add(obj["album"].ToObject<Album>());
                        break;

                    case "app":
                        list.Add(obj["app"].ToObject<App>());
                        break;

                    case "audio":
                        list.Add(obj["audio"].ToObject<Audio>());
                        break;

                    case "wall_reply":
                        list.Add(obj["wall_reply"].ToObject<Comment>());
                        break;

                    case "doc":
                        list.Add(obj["doc"].ToObject<Doc>());
                        break;

                    case "gift":
                        list.Add(obj["gift"].ToObject<Gift>());
                        break;

                    case "graffiti":
                        list.Add(obj["graffiti"].ToObject<Graffiti>());
                        break;

                    case "link":
                        list.Add(obj["link"].ToObject<Link>());
                        break;

                    case "note":
                        list.Add(obj["note"].ToObject<Note>());
                        break;

                    case "page":
                        list.Add(obj["page"].ToObject<Page>());
                        break;

                    case "photo":
                        list.Add(obj["photo"].ToObject<Photo>());
                        break;

                    case "poll":
                        list.Add(obj["poll"].ToObject<Poll>());
                        break;

                    case "wall":
                        list.Add(obj["wall"].ToObject<Post>());
                        break;

                    case "sticker":
                        list.Add(obj["sticker"].ToObject<Sticker>());
                        break;

                    case "video":
                        list.Add(obj["video"].ToObject<Video>());
                        break;
                }
            }

            return list.AsReadOnly();
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
