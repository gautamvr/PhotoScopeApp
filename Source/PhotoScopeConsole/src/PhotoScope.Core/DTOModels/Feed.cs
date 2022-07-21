using System.Collections.ObjectModel;

namespace PhotoScope.Core.DTOModels
{
    public class Feed : BaseModel
    {
        private ObservableCollection<FeedItem> _feedItems;
        private int _currentPage;

        public ObservableCollection<FeedItem> FeedItems
        {
            get => _feedItems;
            set => SetField(ref _feedItems,value);
        }

        public int CurrentPage
        {
            get => _currentPage;
            set => SetField(ref _currentPage,value);
        }
    }
}
