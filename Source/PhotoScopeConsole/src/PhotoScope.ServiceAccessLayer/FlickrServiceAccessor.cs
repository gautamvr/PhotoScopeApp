using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;

namespace PhotoScope.ServiceAccessLayer
{
    public class FlickrServiceAccessor : IServiceAccessor
    {
        public static HttpClient ApiClient { get; set; }

        public FlickrServiceAccessor()
        {
            Initialize();
        }

        public void Initialize()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.BaseAddress = new Uri("https://api.flickr.com/services/");
        }

        public async Task<Feed> GetImages(string keyword)
        {
            Feed feed = await GetImagesFromApi(keyword);
            return feed;
        }

        public async Task<Feed> GetImagesFromApi(string keyword)
        {
            using (HttpResponseMessage response = await ApiClient.GetAsync($"rest/?method=flickr.photos.search&api_key=c3b8bebd6bca6ec55ffc09e58dca6e10&tags={keyword}&format=json&nojsoncallback=1&per_page=30"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<Feed>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                    
                }
            }
            
        }
    }
}
