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

namespace ModernDev.InTouch.Helpers
{
    public class JsonBoolConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue((bool) value ? 1 : 0);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            return reader.Value != null && reader.Value.ToString() != "1";
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (bool);
        } 
    }
}
