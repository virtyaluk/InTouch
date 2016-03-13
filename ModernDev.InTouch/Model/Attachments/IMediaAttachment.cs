using ModernDev.InTouch.Helpers;

namespace ModernDev.InTouch
{
    /// <summary>
    /// An <see cref="IMediaAttachment"/> is a base interface for all kind of attachments.
    /// </summary>
    [APIVersion(Version = 5.45)]
    public interface IMediaAttachment
    {
        int OwnerId { get; set; }
    }
}