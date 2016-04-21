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
    public class JsonUsersListConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteNull();
        }

        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var res = new List<object>();
            var jArray = serializer.Deserialize<JArray>(reader);

            foreach (var item in jArray)
            {
                if (item.Type == JTokenType.Integer)
                {
                    res.Add(item.ToObject<int>());
                }
                else if (item.Type == JTokenType.Object)
                {
                    res.Add(item.ToObject<User>());
                }
            }

            return res;
        }
    }
}