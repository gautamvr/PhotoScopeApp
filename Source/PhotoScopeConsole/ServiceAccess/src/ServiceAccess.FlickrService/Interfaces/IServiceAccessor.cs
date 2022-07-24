using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;
using ServiceAccess.FlickrService.Data;

namespace ServiceAccess.FlickrService.Interfaces
{
    public interface IServiceAccessor
    {
        void SetApiKey(string apiKey);

        Task<PhotoList> GetImagesAsync(SearchParameters keyword);

        Task<Comments> GetCommentsAsync(string imageId);

        Task<PhotoInfo> GetPhotoInfoAsync(string imageId);

        string GetBuddyIconUrl(string farmId, string serverId, string nsid);

        string GetImageUrl(string serverId, string imageId, string secret);
    }
}