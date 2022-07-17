using PhotoScope.Core.DTOModels;

namespace PhotoScope.Core.Interfaces
{
    public interface IFeedDtoPopulator
    {
        FeedItemList FeedItemListDto { get; set; }

        FeedItemList GetPhotoList();
        
    }
}