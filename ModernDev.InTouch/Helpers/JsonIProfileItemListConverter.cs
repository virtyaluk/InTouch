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
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ModernDev.InTouch
{
    public class JsonIProfileItemListConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteNull();
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var res = new List<IProfileItem>();
            var jArray = serializer.Deserialize<JArray>(reader);

            foreach (var jObj in jArray.OfType<JObject>())
            {
                if (((string) jObj["type"]).IsInSet("group", "page", "event"))
                {
                    res.Add(jObj.ToObject<Group>());
                }
                else
                {
                    res.Add(jObj.ToObject<User>());
                }
            }

            return res;
        }
    }
}