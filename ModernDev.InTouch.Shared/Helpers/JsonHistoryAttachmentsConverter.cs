using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ModernDev.InTouch.Helpers
{
    internal class JsonHistoryAttachmentsConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteNull();
        }

        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var list = new List<IMessageAttachment>();
            var jArray = serializer.Deserialize<JArray>(reader);

            foreach (var obj in jArray.OfType<JObject>())
            {
                IMessageAttachment attachment;
                var attObj = obj["attachment"];

                switch ((string) attObj["type"])
                {
                    case "photo":
                        attachment = attObj["photo"].ToObject<Photo>();
                        break;

                    case "video":
                        attachment = attObj["video"].ToObject<Video>();
                        break;

                    case "audio":
                        attachment = attObj["audio"].ToObject<Audio>();
                        break;

                    case "doc":
                        attachment = attObj["doc"].ToObject<Doc>();
                        break;

                    case "link":
                        attachment = attObj["link"].ToObject<Link>();
                        break;

                    default:
                        attachment = null;
                        break;
                }

                if (attachment != null)
                {
                    attachment.MessageId = obj["message_id"].ToObject<int>();
                }

                list.Add(attachment);
            }

            return new ReadOnlyCollection<IMessageAttachment>(list);
        }
    }
}