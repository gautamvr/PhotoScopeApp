using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Microsoft.Practices.Unity;
using PhotoScope.Core.DtoModels;
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
            IsLoading = false;
            IsContentLoaded = false;
            _modelProvider = container.Resolve<IModelProvider<Feed>>();
            Feed = _modelProvider.GetInitialModel();
            GridItems = Feed?.FeedItems;

            if (GridItems != null)
            {
                GridItems.CollectionChanged += OnGridItemsChanged;
            }
        }

        private void OnGridItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            IsContentLoaded = _gridItems?.Count > 0;
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                SetField(ref _isLoading, value);
            }
        }

        private bool _isContentLoaded;

        public bool IsContentLoaded
        {
            get { return _isContentLoaded; }
            set { SetField(ref _isContentLoaded, value); }
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
            set
            {
                SetField(ref _gridItems, value);
                
            }
        }
    }
}
