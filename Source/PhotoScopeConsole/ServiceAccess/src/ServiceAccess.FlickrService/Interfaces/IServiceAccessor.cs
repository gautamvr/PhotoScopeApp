using System;
using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;
using ServiceAccess.FlickrService.Data;

namespace ServiceAccess.FlickrService.Interfaces
{
    /// <summary>
    /// Interface for accessing service
    /// </summary>
    public interface IServiceAccessor : IDisposable
    {
        /// <summary>
        /// Sets the API key
        /// </summary>
        /// <param name="apiKey"></param>
        void SetApiKey(string apiKey);

        /// <summary>
        /// Sets up Cache store with capacity
        /// </summary>
        /// <param name="isCacheEnabled"></param>
        /// <param name="capacity"></param>
        void SetupCacheStore(bool isCacheEnabled,int capacity);

        /// <summary>
        /// Gets images
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        Task<PhotoList> GetImagesAsync(SearchParameters keyword);

        /// <summary>
        /// Gets Comments
        /// </summary>
        /// <param name="imageId"></param>
        /// <returns></returns>
        Task<Comments> GetCommentsAsync(string imageId);

        /// <summary>
        /// Gets Photo info
        /// </summary>
        /// <param name="imageId"></param>
        /// <returns></returns>
        Task<PhotoInfo> GetPhotoInfoAsync(string imageId);

        /// <summary>
        /// Gets photo icon URL
        /// </summary>
        /// <param name="farmId"></param>
        /// <param name="serverId"></param>
        /// <param name="nsid"></param>
        /// <returns></returns>
        string GetBuddyIconUrl(string farmId, string serverId, string nsid);

        /// <summary>
        /// Gets Image URL
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="imageId"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        string GetImageUrl(string serverId, string imageId, string secret);
    }
}