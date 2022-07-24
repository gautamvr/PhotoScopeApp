using System.Collections.Generic;
using System.Collections.ObjectModel;
using PhotoScope.BusinessLogic.Interfaces;
using PhotoScope.Core.DTOModels;

namespace PhotoScope.BusinessLogic
{
    public class FeedDtoPopulator : IFeedDtoPopulator
    {
        public Feed FeedDto { get; }

        public FeedDtoPopulator()
        {
            FeedDto = new Feed
            {
                FeedItems = new ObservableCollection<FeedItem>()
            };
        }

        public void AddToFeed(IList<FeedItem> items)
        {
            if (items != null)
            {
                foreach (var feedItem in items)
                {
                    if (feedItem != null)
                    {
                        FeedDto.FeedItems.Add(feedItem);
                    }
                }
            }
        }

        public void ClearFeed()
        {
            FeedDto.FeedItems.Clear();
        }

        public Feed GetDtoModel()
        {
            return FeedDto;
        }
    }
}
