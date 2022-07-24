using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.Core.DTOModels;
using PhotoScope.Utilities.Common;
using ServiceAccess.FlickrService.Data;
using ServiceAccess.FlickrService.Interfaces;
using ServiceAccess.Interfaces.Interfaces;

namespace ServiceAccess.FlickrService
{
    public class FlickrServiceAccessor : IServiceAccessor
    {
        private IQueryManager _queryManager;
        private string _apiKey;
        
        public FlickrServiceAccessor(IUnityContainer container)
        {
            _queryManager = container.Resolve<IQueryManager>();
            var baseAddress = _queryManager.GetBaseAddress();

            ApiHelper.Initialize();
            ApiHelper.ApiClient.BaseAddress = new Uri(baseAddress);
        }

        public void SetApiKey(string apiKey)
        {
            _apiKey = apiKey;
        }

        public string GetBuddyIconUrl(string farmId, string serverId, string nsid)
        {
            string iconUrl;
            ;
            if (int.TryParse(serverId,out int serverNum) && serverNum > 0)
            {
                iconUrl = $"http://farm{farmId}.staticflickr.com/{serverId}/buddyicons/{nsid}.jpg";
            }
            else
            {
                iconUrl = "https://www.flickr.com/images/buddyicon.gif";
            }

            return iconUrl;
        }

        public string GetImageUrl(string serverId, string imageId, string secret)
        {
            return $"https://live.staticflickr.com/{serverId}/{imageId}_{secret}.jpg";
        }

        public async Task<Comments> GetCommentsAsync(string imageId)
        {
            var query = _queryManager.GetCommentsQuery(_apiKey, imageId);

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(query))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<CommentsResultModel>();
                    return result.Comments;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }
        }

        public async Task<PhotoList> GetImagesAsync(SearchParameters keyword)
        {
            var query = _queryManager.GetImageQuery(_apiKey, keyword);

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(query))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<FeedResultModel>();
                    return result.Photos;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }
        }

        public async Task<PhotoInfo> GetPhotoInfoAsync(string imageId)
        {
            var query = _queryManager.GetImageInfoQuery(_apiKey, imageId);

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(query))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<PhotoInfoResultModel>();
                    return result.Photo;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }
        }
    }
}
