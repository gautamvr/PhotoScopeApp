using PhotoScope.Core.DTOModels;

namespace PhotoScope.Core.Interfaces
{
    public interface IFeedDtoPopulator
    {
        PhotoList PhotoListDto { get; set; }

        PhotoList GetPhotoList();
        
    }
}