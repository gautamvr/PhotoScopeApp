using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
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
        private IFeedController _feedController;

        public ICommand ShowMore { get; set; }

        public ICommand SelectItem { get; set; }

        public PhotoFeedViewModel(IUnityContainer container)
        {
            IsLoading = false;
            IsContentLoaded = false;
            _modelProvider = container.Resolve<IModelProvider<Feed>>();
            _feedController = container.Resolve<IFeedController>();

            ShowMore = new Command(OnShowMore);
            SelectItem = new Command(OnItemSelected);

            Feed = _modelProvider.GetInitialModel();
            GridItems = Feed?.FeedItems;

            if (GridItems != null)
            {
                GridItems.CollectionChanged += OnGridItemsChanged;
            }
        }

        private void OnItemSelected(object obj)
        {
            if (obj != null)
            {
                var imageId = obj as string;
                _feedController.SelectImage(imageId);
            }
        }

        private async void OnShowMore(object obj)
        {
            try
            {
                IsLoading = true;
                await _feedController.LoadMore();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                IsLoading = false;
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
