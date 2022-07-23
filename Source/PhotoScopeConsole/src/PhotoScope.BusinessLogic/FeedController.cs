using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.BusinessLogic.Interfaces;
using PhotoScope.Core.Interfaces;

namespace PhotoScope.BusinessLogic
{
    public class FeedController : IFeedController
    {
        private IFeedItemAccessor _feedItemAccessor;
        private IFeedDtoPopulator _feedPopulator;
        private ISearchParameterStore _searchConfigStore;
        private IPreviewController _previewController;

        public FeedController(IUnityContainer container)
        {
            _feedItemAccessor = container.Resolve<IFeedItemAccessor>();
            _feedPopulator = container.Resolve<IFeedDtoPopulator>();
            _searchConfigStore = container.Resolve<ISearchParameterStore>();
            //_previewController = container.Resolve<IPreviewController>();
        }

        public async Task UpdateFeed()
        {
            _feedPopulator.ClearFeed();
            var searchConfig = _searchConfigStore.GetSearchConfig();
            var feedItems = await _feedItemAccessor.GetFeedItems(searchConfig);
            _feedPopulator.ClearFeed();
            _feedPopulator.AddToFeed(feedItems.ToList());
        }

        public void ClearFeed()
        {
            _feedPopulator.ClearFeed();
        }

        public async Task RefreshFeed()
        {
            await UpdateFeed();
        }

        public async void SelectImage(string imageId)
        {
            var isPreviewLoaded = false;
            isPreviewLoaded = await _previewController.LoadPreview(imageId);
        }

        public async Task LoadMore()
        {
            var searchConfig = _searchConfigStore.GetSearchConfig();
            searchConfig.CurrentPage += 1;
            var feedItems = await _feedItemAccessor.GetFeedItems(searchConfig);
            _feedPopulator.AddToFeed(feedItems.ToList());
        }
    }
}
