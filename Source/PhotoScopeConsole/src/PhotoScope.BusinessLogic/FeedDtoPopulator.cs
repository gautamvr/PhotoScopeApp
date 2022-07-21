using System.Collections.Generic;
using System.Collections.ObjectModel;
using PhotoScope.BusinessLogic.Interfaces;
using PhotoScope.Core.DTOModels;

namespace PhotoScope.BusinessLogic
{
    public class FeedDtoPopulator : IFeedDtoPopulator
    {
        public Feed FeedDto { get; set; }

        public FeedDtoPopulator()
        {
            FeedDto = new Feed
            {
                FeedItems = new ObservableCollection<FeedItem>()
            };
        }

        public void AddToFeed(List<FeedItem> items)
        {
            if (items != null)
            {
                foreach (var feedItem in items)
                {
                    FeedDto.FeedItems.Add(feedItem);
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
