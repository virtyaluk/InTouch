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
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ModernDev.InTouch.Helpers
{
    internal class JsonCoordinatesConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteNull();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var coords =
                ((string) serializer.Deserialize<JToken>(reader)).Trim().Split(' ').Select(double.Parse).ToList();

            return new Coordinates
            {
                Latitude = coords[0],
                Longitude = coords[1]
            };
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
