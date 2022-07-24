﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        private ObservableCollection<FeedItem> _gridItems;
        private bool _isLoading;
        private bool _isContentLoaded;

        public ICommand ShowMore { get; set; }

        public ICommand SelectItem { get; set; }
        
        public bool IsLoading
        {
            get => _isLoading;
            set => SetField(ref _isLoading, value);
        }

        public bool IsContentLoaded
        {
            get => _isContentLoaded;
            set => SetField(ref _isContentLoaded, value);
        }

        public Feed Feed
        {
            get => _feed;
            set => SetField(ref _feed, value);
        }

        public ObservableCollection<FeedItem> GridItems
        {
            get => _gridItems;
            set => SetField(ref _gridItems, value);
        }

        public PhotoFeedViewModel(IUnityContainer container)
        {
            IsLoading = false;
            IsContentLoaded = false;
            _modelProvider = container.Resolve<IModelProvider<Feed>>();
            _feedController = container.Resolve<IFeedController>();
            _feedController.FeedLoading += OnFeedLoading;
            _feedController.FeedLoaded += OnFeedLoaded;
            _feedController.FeedCleared += OnFeedCleared;

            ShowMore = new Command(OnShowMore);
            SelectItem = new Command(OnItemSelected);

            Feed = _modelProvider.GetInitialModel();
            GridItems = Feed?.FeedItems;
        }

        private void OnFeedCleared(object sender, EventArgs e)
        {
            IsContentLoaded = false;
        }

        private void OnFeedLoaded(object sender, EventArgs e)
        {
            IsLoading = false;
            IsContentLoaded = true;
        }

        private void OnFeedLoading(object sender, EventArgs e)
        {
            IsLoading = true;
            IsContentLoaded = false;
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
                IsContentLoaded = false;
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
                IsContentLoaded = true;
            }
        }
    }
}
