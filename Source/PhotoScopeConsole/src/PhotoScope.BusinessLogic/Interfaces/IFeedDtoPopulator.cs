using System.Collections.Generic;
using PhotoScope.Core.DTOModels;

namespace PhotoScope.BusinessLogic.Interfaces
{
    public interface IFeedDtoPopulator
    {
        Feed FeedDto { get; set; }

        Feed GetDtoModel();

        void AddToFeed(IList<FeedItem> item);

        void ClearFeed();
    }
}