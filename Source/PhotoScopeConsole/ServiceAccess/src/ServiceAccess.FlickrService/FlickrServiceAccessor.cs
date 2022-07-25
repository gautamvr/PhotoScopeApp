using System;
using System.Collections.Generic;
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
        #region Private Properties

        private IQueryManager _queryManager;
        private LRUCache<string,FeedResultModel> _feedResultCacheStore;
        private LRUCache<string, PhotoInfoResultModel> _previewItemCacheStore;
        private LRUCache<string,CommentsResultModel> _commentsCacheStore;
        private bool _isCacheEnabled;
        private string _apiKey;
        private bool _isDisposed;

        #endregion

        #region Public Methods

        public FlickrServiceAccessor(IUnityContainer container)
        {
            _queryManager = container.Resolve<IQueryManager>();
            var baseAddress = _queryManager.GetBaseAddress();
            _isCacheEnabled = false;

            ApiHelper.Initialize();
            ApiHelper.ApiClient.BaseAddress = new Uri(baseAddress);
        }

        public void SetApiKey(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void SetupCacheStore(bool isCacheEnabled,int capacity)
        {
            _isCacheEnabled = isCacheEnabled;;
            _feedResultCacheStore = new LRUCache<string,FeedResultModel>(capacity);
            _previewItemCacheStore = new LRUCache<string, PhotoInfoResultModel>(capacity);
            _commentsCacheStore = new LRUCache<string,CommentsResultModel>(capacity);
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

            if (_isCacheEnabled)
            {
                var storedVal = _commentsCacheStore.Get(query);
                if (storedVal != null)
                {
                    return storedVal.Comments;
                }
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(query))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<CommentsResultModel>();

                    if (_isCacheEnabled)
                    {
                        _commentsCacheStore.Put(query, result);
                    }

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

            if (_isCacheEnabled)
            {
                var storedVal = _feedResultCacheStore.Get(query);
                if (storedVal != null)
                {
                    return storedVal.Photos;
                }
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(query))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<FeedResultModel>();

                    if (_isCacheEnabled)
                    {
                        _feedResultCacheStore.Put(query, result);
                    }

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

            if (_isCacheEnabled)
            {
                var storedVal = _previewItemCacheStore.Get(query);
                if (storedVal != null)
                {
                    return storedVal.Photo;
                }
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(query))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<PhotoInfoResultModel>();

                    if (_isCacheEnabled)
                    {
                        _previewItemCacheStore.Put(query,result);
                    }

                    return result.Photo;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }
        }
        

        #endregion

        #region Dispose pattern

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _queryManager.Dispose();
                    _queryManager = null;
                    _feedResultCacheStore.Dispose();
                    _previewItemCacheStore.Dispose();
                    _commentsCacheStore.Dispose();
                    _feedResultCacheStore = null;
                    _previewItemCacheStore = null;
                    _commentsCacheStore = null;
                }

                _isDisposed = true;
            }
        }

        ~FlickrServiceAccessor()
        {
            Dispose(false);
        }

        #endregion
    }
}
