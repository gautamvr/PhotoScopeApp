using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;

namespace PhotoFeed.Interfaces
{
    /// <summary>
    /// Interface for Feed item accessor
    /// </summary>
    public interface IFeedItemAccessor : IDisposable
    {
        /// <summary>
        /// Gets the Feed Item
        /// </summary>
        /// <param name="searchConfig"></param>
        /// <returns></returns>
        Task<IEnumerable<FeedItem>> GetFeedItems(SearchParameters searchConfig);
    }
}