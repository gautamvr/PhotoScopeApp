using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoFeed.Interfaces;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;

namespace PhotoFeed.BusinessLogic
{
    /// <summary>
    /// Controller class for the Feed 
    /// </summary>
    public class FeedController : IFeedController
    {
        #region Private Properties

        private IFeedItemAccessor _feedItemAccessor;
        private IFeedDtoPopulator _feedPopulator;
        private IPreviewController _previewController;

        private SearchParameters _searchParameters;
        private bool _isDisposed;

        #endregion

        #region Public Methods and events

        public FeedController(IUnityContainer container)
        {
            _feedItemAccessor = container.Resolve<IFeedItemAccessor>();
            _feedPopulator = container.Resolve<IFeedDtoPopulator>();
            _previewController = container.Resolve<IPreviewController>();
        }

        /// <summary>
        /// Update the feed
        /// </summary>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        public async Task UpdateFeed(SearchParameters searchParams)
        {
            _searchParameters = searchParams;
            _feedPopulator.ClearFeed();
            
            FeedLoading?.Invoke(this, EventArgs.Empty);
            var feedItems = await _feedItemAccessor.GetFeedItems(_searchParameters);
            _feedPopulator.ClearFeed();
            _feedPopulator.UpdateResultsTag(_searchParameters.SearchTag);
            _feedPopulator.AddToFeed(feedItems.ToList());
            FeedLoaded?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Clears the feed
        /// </summary>
        public void ClearFeed()
        {
            _feedPopulator.ClearFeed();
            _previewController.ClosePreview();
            FeedCleared?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Refreshes the feed
        /// </summary>
        /// <returns></returns>
        public async Task RefreshFeed()
        {
            await UpdateFeed(_searchParameters);
        }

        /// <summary>
        /// Selects the image on the feed
        /// </summary>
        /// <param name="imageId"></param>
        public async void SelectImage(string imageId)
        {
            await _previewController.LoadPreview(imageId);
        }

        /// <summary>
        /// Load more images to the feed
        /// </summary>
        /// <returns></returns>
        public async Task LoadMore()
        {
            _searchParameters.CurrentPage += 1;
            var feedItems = await _feedItemAccessor.GetFeedItems(_searchParameters);
            _feedPopulator.AddToFeed(feedItems.ToList());
        }

        public event EventHandler FeedLoading;
        public event EventHandler FeedLoaded;
        public event EventHandler FeedCleared;

        #endregion

        /// <summary>
        /// Dispose 
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
            {
                _feedItemAccessor = null;
                _feedPopulator = null;
                _previewController = null;
                _searchParameters = null;
               _isDisposed = true;
            }
        }
    }
}
