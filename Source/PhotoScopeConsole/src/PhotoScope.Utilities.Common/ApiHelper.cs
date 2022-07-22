using System.Net.Http;
using System.Net.Http.Headers;

namespace PhotoScope.Utilities.Common
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        
        public static void Initialize()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
