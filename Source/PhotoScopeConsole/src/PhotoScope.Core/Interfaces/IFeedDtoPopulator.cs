using PhotoScope.Core.DTOModels;

namespace PhotoScope.Core.Interfaces
{
    public interface IFeedDtoPopulator
    {
        Feed FeedDto { get; set; }

        Feed GetPhotoList();
        
    }
}