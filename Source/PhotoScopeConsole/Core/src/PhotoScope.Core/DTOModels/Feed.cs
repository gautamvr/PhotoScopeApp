using System.Collections.ObjectModel;

namespace PhotoScope.Core.DTOModels
{
    /// <summary>
    /// Feed DTO model to be displayed on the UI
    /// </summary>
    public class Feed : BaseModel
    {
        #region Private Properties

        private ObservableCollection<FeedItem> _feedItems;
        private string _resultsTag;

        #endregion

        #region Public Properties

        /// <summary>
        /// Feed items to be viewed on the feed
        /// </summary>
        public ObservableCollection<FeedItem> FeedItems
        {
            get => _feedItems;
            set => SetField(ref _feedItems,value);
        }

        /// <summary>
        /// The tag for which the feed items are generated
        /// </summary>
        public string ResultsTag
        {
            get => _resultsTag;
            set => SetField(ref _resultsTag,value);
        }

        #endregion
    }
}
