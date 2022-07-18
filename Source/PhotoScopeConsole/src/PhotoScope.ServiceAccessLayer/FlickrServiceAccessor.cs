using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;
using PhotoScope.Utilities.Common;

namespace PhotoScope.ServiceAccessLayer
{
    public class FlickrServiceAccessor : IServiceAccessor
    {
        private ApiHelper<Feed> _apiHelper;

        public FlickrServiceAccessor()
        {
            _apiHelper = new ApiHelper<Feed>
            {
                BaseAddress = "https://api.flickr.com/services/"
            };
        }

        public async Task<Feed> GetImages(string keyword)
        {
            Feed feed = await GetImagesFromApi(keyword);
            return feed;
        }

        public async Task<Feed> GetImagesFromApi(string keyword)
        {
            return await _apiHelper.GetAsync(
                $"rest/?method=flickr.photos.search&api_key=c3b8bebd6bca6ec55ffc09e58dca6e10&tags={keyword}&format=json&nojsoncallback=1&per_page=30&safe_search=1&extras=url_t,url_s,url_l,url_m");
        }
    }
}
