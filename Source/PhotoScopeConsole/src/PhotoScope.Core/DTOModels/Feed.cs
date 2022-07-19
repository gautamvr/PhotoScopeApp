using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.AccessControl;

namespace PhotoScope.Core.DTOModels
{
    public class Feed : ObservableModel
    {
        public ObservableCollection<FeedItem> FeedItems { get; set; }

    }
}
