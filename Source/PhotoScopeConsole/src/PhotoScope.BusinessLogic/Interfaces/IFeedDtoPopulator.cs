using System.Collections.Generic;
using PhotoScope.Core.DTOModels;

namespace PhotoScope.BusinessLogic.Interfaces
{
    public interface IFeedDtoPopulator
    {
        Feed FeedDto { get; set; }

        Feed GetDtoModel();

        void AddToFeed(List<FeedItem> item);

        void ClearFeed();
    }
}