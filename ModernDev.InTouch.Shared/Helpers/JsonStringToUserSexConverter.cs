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
    internal class JsonStringToUserSexConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch ((UserSex) value)
            {
                case UserSex.Female:
                    writer.WriteValue(1);
                    break;

                case UserSex.Male:
                    writer.WriteValue(2);
                    break;

                case UserSex.NotSpecified:
                    writer.WriteValue(0);
                    break;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader != null)
            {
                switch (reader.Value.ToString())
                {
                    case "0":
                        return UserSex.NotSpecified;

                    case "1":
                        return UserSex.Female;

                    case "2":
                        return UserSex.Male;
                }
            }

            return UserSex.NotSpecified;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(UserSex);
        }
    }
}
