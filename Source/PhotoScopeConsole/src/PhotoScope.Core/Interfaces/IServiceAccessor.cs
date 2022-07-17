using PhotoScope.Core.DTOModels;

namespace PhotoScope.Core.Interfaces
{
    public interface IServiceAccessor
    {
        FeedItemList GetImages(string keyword);
    }
}