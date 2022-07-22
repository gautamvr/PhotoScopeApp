using System.Collections.ObjectModel;

namespace PhotoScope.Core.DTOModels
{
    public class Feed : BaseModel
    {
        private ObservableCollection<FeedItem> _feedItems;

        public ObservableCollection<FeedItem> FeedItems
        {
            get => _feedItems;
            set => SetField(ref _feedItems,value);
        }
    }
}
