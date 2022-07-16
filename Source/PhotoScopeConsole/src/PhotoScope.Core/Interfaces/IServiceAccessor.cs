using PhotoScope.Core.DTOs;

namespace PhotoScope.Core.Interfaces
{
    public interface IServiceAccessor
    {
        PhotoList GetImages(SearchTag keyword);
    }
}