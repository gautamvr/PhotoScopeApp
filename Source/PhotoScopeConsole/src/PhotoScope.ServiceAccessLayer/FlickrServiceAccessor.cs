using System;
using System.Net.Http;
using System.Threading.Tasks;
using PhotoScope.ServiceAccessLayer.Data;
using PhotoScope.ServiceAccessLayer.Interfaces;
using PhotoScope.Utilities.Common;

namespace PhotoScope.ServiceAccessLayer
{
    public class FlickrServiceAccessor : IServiceAccessor
    {
        public FlickrServiceAccessor()
        {
            ApiHelper.Initialize();
            ApiHelper.ApiClient.BaseAddress = new Uri("https://api.flickr.com/services/");
        }

        public PhotoList GetImages(string keyword)
        {
            return new PhotoList();
        }

        public async Task<PhotoList> GetImagesAsync(string keyword)
        {
            PhotoList feed = await GetImagesFromApi(keyword);
            return feed;
        }

        public async Task<PhotoList> GetImagesFromApi(string keyword)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(
                       $"rest/?method=flickr.photos.search&api_key=c3b8bebd6bca6ec55ffc09e58dca6e10&tags={keyword}&format=json&nojsoncallback=1&per_page=30&safe_search=1&extras=url_t,url_s,url_l,url_m"))
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
