using ModernDev.InTouch.Helpers;

namespace ModernDev.InTouch
{
    /// <summary>
    /// An <see cref="IMediaAttachment"/> is a base interface for all kind of attachments.
    /// </summary>
    public interface IMediaAttachment
    {
        /// <summary>
        /// Item owner Id.
        /// </summary>
        int OwnerId { get; set; }
    }
}