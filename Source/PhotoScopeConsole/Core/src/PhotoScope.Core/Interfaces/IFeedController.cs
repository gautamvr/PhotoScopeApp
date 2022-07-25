using System;
using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;

namespace PhotoScope.Core.Interfaces
{
    /// <summary>
    /// Interface that is used to control any activity on the feed
    /// </summary>
    public interface IFeedController : IDisposable
    {
        #region Events

        /// <summary>
        /// Event when Feed is loading
        /// </summary>
        event EventHandler FeedLoading;

        /// <summary>
        /// Event when Feed is loaded
        /// </summary>
        event EventHandler FeedLoaded;

        /// <summary>
        /// Event when Feed is cleared
        /// </summary>
        event EventHandler FeedCleared;

        #endregion

        #region Methods

        /// <summary>
        /// Updates the Feed
        /// </summary>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        Task UpdateFeed(SearchParameters searchParams);

        /// <summary>
        /// Clears the feed
        /// </summary>
        void ClearFeed();

        /// <summary>
        /// Refreshes the feed
        /// </summary>
        /// <returns></returns>
        Task RefreshFeed();

        /// <summary>
        /// Selects an image on the feed
        /// </summary>
        /// <param name="imageId"></param>
        void SelectImage(string imageId);
        
        /// <summary>
        /// Load more item to the feed
        /// </summary>
        /// <returns></returns>
        Task LoadMore();

        #endregion

        

    }
}