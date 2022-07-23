using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.BusinessLogic.Interfaces;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;

namespace PhotoScope.BusinessLogic
{
    public class FeedController : IFeedController
    {
        private IFeedItemAccessor _feedItemAccessor;
        private IFeedDtoPopulator _feedPopulator;
        private IPreviewController _previewController;

        private SearchParameters _searchParameters;

        public FeedController(IUnityContainer container)
        {
            _feedItemAccessor = container.Resolve<IFeedItemAccessor>();
            _feedPopulator = container.Resolve<IFeedDtoPopulator>();
            _previewController = container.Resolve<IPreviewController>();
        }

        public async Task UpdateFeed(SearchParameters searchParams)
        {
            _searchParameters = searchParams;
            _feedPopulator.ClearFeed();
            FeedLoading?.Invoke(this, EventArgs.Empty);
            var feedItems = await _feedItemAccessor.GetFeedItems(_searchParameters);
            _feedPopulator.ClearFeed();
            _feedPopulator.AddToFeed(feedItems.ToList());
            FeedLoaded?.Invoke(this, EventArgs.Empty);
        }

        public void ClearFeed()
        {
            _feedPopulator.ClearFeed();
            FeedCleared?.Invoke(this, EventArgs.Empty);
        }

        public async Task RefreshFeed()
        {
            await UpdateFeed(_searchParameters);
        }

        public async void SelectImage(string imageId)
        {
            await _previewController.LoadPreview(imageId);
        }

        public async Task LoadMore()
        {
            _searchParameters.CurrentPage += 1;
            var feedItems = await _feedItemAccessor.GetFeedItems(_searchParameters);
            _feedPopulator.AddToFeed(feedItems.ToList());
        }

        public event EventHandler FeedLoading;
        public event EventHandler FeedLoaded;
        public event EventHandler FeedCleared;
    }
}
