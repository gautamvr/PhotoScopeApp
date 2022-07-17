using System.Collections.ObjectModel;
using Microsoft.Practices.Unity;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;
using PhotoScope.Utilities.UI.Common;

namespace PhotoScope.DesktopUI.ViewModels
{
    public class PhotoFeedViewModel : ViewModelBase
    {
        private Feed _feed;
        private IModelProvider<Feed> _modelProvider;

        public PhotoFeedViewModel(IUnityContainer container)
        {
            _modelProvider = container.Resolve<IModelProvider<Feed>>();
            _feed = _modelProvider.GetInitialModel();

            GridItems = Feed?.Photos?.Photo;

        }

        public Feed Feed
        {
            get => _feed;
            set => SetField(ref _feed, value);
        }

        private ObservableCollection<FeedItem> _gridItems;

        public ObservableCollection<FeedItem> GridItems
        {
            get => _gridItems;
            set => SetField(ref _gridItems, value);
        }
        
    }
}
