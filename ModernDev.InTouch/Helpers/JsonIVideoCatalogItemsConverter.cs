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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ModernDev.InTouch.Helpers
{
    public class JsonIVideoCatalogItemsConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteNull();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var res = new List<IVideoCatalogItem>();
            var jArr = serializer.Deserialize<JArray>(reader);

            foreach (var jObj in jArr)
            {
                var type = (string) jObj["type"];

                if (type == "album")
                {
                    res.Add(jObj.ToObject<VideoAlbum>());
                }
                else if (type == "video")
                {
                    res.Add(jObj.ToObject<Video>());
                }
            }

            return res;
        }

        public override bool CanConvert(Type objectType) => true;
    }
}