using PhotoScope.Core.DTOModels;

namespace PhotoScope.Core.Interfaces
{
    public interface IServiceAccessor
    {
        PhotoList GetImages(string keyword);
    }
}