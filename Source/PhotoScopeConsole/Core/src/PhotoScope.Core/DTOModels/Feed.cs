using System.Collections.ObjectModel;

namespace PhotoScope.Core.DTOModels
{
    public class Feed : BaseModel
    {
        private ObservableCollection<FeedItem> _feedItems;
        private string _resultsTag;

        public ObservableCollection<FeedItem> FeedItems
        {
            get => _feedItems;
            set => SetField(ref _feedItems,value);
        }

        public string ResultsTag
        {
            get => _resultsTag;
            set => SetField(ref _resultsTag,value);
        }
    }
}
