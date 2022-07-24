using System.Collections.Generic;
using PhotoScope.Core.DTOModels;

namespace PhotoFeed.Interfaces
{
    public interface IFeedDtoPopulator
    {
        Feed GetDtoModel();

        void AddToFeed(IList<FeedItem> item);

        void ClearFeed();

        void UpdateResultsTag(string resultTag);
    }
}