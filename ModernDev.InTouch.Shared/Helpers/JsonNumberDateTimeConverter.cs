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
using Newtonsoft.Json;
using static ModernDev.InTouch.Helpers.Utils;

namespace ModernDev.InTouch.Helpers
{
    internal class JsonNumberDateTimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime) value).ToUnixTimeStamp());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.Value != null)
            {
                return UnixTimeStampToDateTime((long) reader.Value);
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (DateTime);
        }
    }
}