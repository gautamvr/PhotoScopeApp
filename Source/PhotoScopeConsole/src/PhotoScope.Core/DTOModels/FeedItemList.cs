using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.AccessControl;

namespace PhotoScope.Core.DTOModels
{
    public class FeedItemList : ObservableModel
    {
        public ObservableCollection<FeedItem> Photo { get; set; }

    }
}
