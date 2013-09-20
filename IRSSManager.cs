using System.Collections.Generic;

namespace Radio7.Portable.Rss
{
    public interface IRssManager
    {
        IEnumerable<Feed> Feeds { get; }

        void Subscribe(Feed feed);

        void Unsubscribe(Feed feed);
    }
}