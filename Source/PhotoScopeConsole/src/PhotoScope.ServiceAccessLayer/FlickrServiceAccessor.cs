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
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://www.flickr.com/services/feeds/photos_public.gne");

        }

        public FeedItemList GetImages(string keyword)
        {
            FeedItemList photoList = GetImagesFromApi(keyword).Result;
            return photoList;
        }

        public async Task<FeedItemList> GetImagesFromApi(string keyword)
        {
            ApiClient.DefaultRequestHeaders.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await ApiClient.GetAsync("api/Department/1");

            FeedItemList photoList = new FeedItemList();


            return photoList;
        }
    }
}
