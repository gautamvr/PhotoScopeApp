using System.Collections.ObjectModel;
using PhotoScope.Core.DTOModels;
using PhotoScope.Utilities.UI.Common;

namespace PhotoScope.DesktopUI.ViewModels
{
    public class PhotoFeedViewModel : ViewModelBase
    {
        private FeedItemList _photoList;

        public FeedItemList PhotoList
        {
            get => _photoList;
            set => SetField(ref _photoList, value);
        }

        private ObservableCollection<FeedItem> _gridItems;

        public ObservableCollection<FeedItem> GridItems
        {
            get => _gridItems;
            set => SetField(ref _gridItems, value);
        }


        public PhotoFeedViewModel()
        {
            GridItems = new ObservableCollection<FeedItem>();
            GridItems.Add(new FeedItem{ ImageUri = ""});
            GridItems.Add(new FeedItem{ ImageUri = ""});
            GridItems.Add(new FeedItem{ ImageUri = ""});
            GridItems.Add(new FeedItem{ ImageUri = ""});
            GridItems.Add(new FeedItem{ ImageUri = ""});
            GridItems.Add(new FeedItem{ ImageUri = ""});

        }
    }
}
