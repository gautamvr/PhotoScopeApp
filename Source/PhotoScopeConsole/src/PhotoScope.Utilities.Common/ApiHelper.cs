using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PhotoScope.Utilities.Common
{
    public class ApiHelper<T>
    {
        private static HttpClient _apiClient { get; set; }
        
        private string _baseAddress;

        public string BaseAddress
        {
            get { return _baseAddress; }
            set
            {
                _baseAddress = value;
                _apiClient.BaseAddress = new Uri(value);;
            }
        }

        public ApiHelper()
        {
            Initialize();
        }

        public void Initialize()
        {
            _apiClient = new HttpClient();
            _apiClient.DefaultRequestHeaders.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetAsync(string queryRequest)
        {
            using (HttpResponseMessage response = await _apiClient.GetAsync(queryRequest))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<T>();
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
