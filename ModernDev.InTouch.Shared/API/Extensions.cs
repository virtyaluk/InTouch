using System;
using System.Collections.Generic;

namespace ModernDev.InTouch
{
    public static class Extensions
    {
        public static void Add(this IList<Tuple<string, byte[], string>> @this, string item1, byte[] item2, string item3)
        {
            @this.Add(Tuple.Create(item1, item2, item3));
        }

        public static int Abs(this int @this) => Math.Abs(@this);

        public static List<string> GetCommentAttachments(this List<IMediaAttachment> @this)
        {
            var res = new List<string>();

            foreach (var att in @this)
            {
                if (att is Photo)
                {
                    res.Add($"photo{att.OwnerId}_{((Photo) att).PhotoId}");
                }
                else if (att is Video)
                {
                    res.Add($"video{att.OwnerId}_{((Video) att).Id}");
                }
                else if (att is Audio)
                {
                    res.Add($"audio{att.OwnerId}_{((Audio) att).Id}");
                }
                else if (att is Doc)
                {
                    res.Add($"doc{att.OwnerId}_{((Doc) att).Id}");
                }
            }

            return res;
        }

        public static List<string> GetMessageAttachments(this List<IMediaAttachment> @this)
        {
            var res = new List<string>();

            foreach (var att in @this)
            {
                if (att is Photo)
                {
                    res.Add($"photo{att.OwnerId}_{((Photo)att).PhotoId}");
                }
                else if (att is Video)
                {
                    res.Add($"video{att.OwnerId}_{((Video)att).Id}");
                }
                else if (att is Audio)
                {
                    res.Add($"audio{att.OwnerId}_{((Audio)att).Id}");
                }
                else if (att is Doc)
                {
                    res.Add($"doc{att.OwnerId}_{((Doc)att).Id}");
                }
                else if (att is Post)
                {
                    res.Add($"album{att.OwnerId}_{((Post)att).Id}");
                }
            }

            return res;
        }

        public static List<string> GetPostAttachments(this List<IMediaAttachment> @this)
        {
            var res = new List<string>();

            foreach (var att in @this)
            {
                if (att is Photo)
                {
                    res.Add($"photo{att.OwnerId}_{((Photo) att).PhotoId}");
                }
                else if (att is Video)
                {
                    res.Add($"video{att.OwnerId}_{((Video) att).Id}");
                }
                else if (att is Audio)
                {
                    res.Add($"audio{att.OwnerId}_{((Audio) att).Id}");
                }
                else if (att is Doc)
                {
                    res.Add($"doc{att.OwnerId}_{((Doc) att).Id}");
                }
                else if (att is Page)
                {
                    res.Add($"page{att.OwnerId}_{((Page) att).Id}");
                }
                else if (att is Note)
                {
                    res.Add($"note{att.OwnerId}_{((Note) att).Id}");
                }
                else if (att is Poll)
                {
                    res.Add($"poll{att.OwnerId}_{((Poll) att).Id}");
                }
                else if (att is Album)
                {
                    res.Add($"album{att.OwnerId}_{((Album) att).Id}");
                }
            }

            return res;
        }
    }
}