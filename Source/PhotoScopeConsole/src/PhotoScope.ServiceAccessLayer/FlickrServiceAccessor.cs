using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.Core.DTOModels;
using PhotoScope.ServiceAccessLayer.Data;
using PhotoScope.ServiceAccessLayer.Interfaces;
using PhotoScope.Utilities.Common;

namespace PhotoScope.ServiceAccessLayer
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

        public Task<PhotoList> GetCommentsAsync(string imageId)
        {
            throw new NotImplementedException();
        }

        public async Task<PhotoList> GetImagesAsync(SearchParameters keyword)
        {
            var query = _queryManager.GetImageQuery(_apiKey, keyword);

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(query))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<ResultModel>();
                    return result.Photos;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }
        }
    }
}
