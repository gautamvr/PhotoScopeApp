using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.Core.DtoModels;
using PhotoScope.ServiceAccessLayer.Interfaces;

namespace PhotoScope.ServiceAccessLayer
{
    public class FlickrQueryManager : IQueryManager
    {
        private IQueryBuilder _queryBuilder;
        private readonly string _baseAddress;

        public IQueryBuilder QueryBuilder
        {
            set => _queryBuilder = value;
        }

        public FlickrQueryManager(IUnityContainer container)
        {
            QueryBuilder = container.Resolve<IQueryBuilder>();
            _baseAddress = "https://api.flickr.com/services/rest/?";
        }


        public string GetBaseAddress()
        {
            return _baseAddress;
        }

        public void UpdateQueryBuilder(IQueryBuilder queryBuilder)
        {
            QueryBuilder = queryBuilder;
        }

        public string GetImageQuery(string apiKey, SearchConfig searchConfig)
        {
            _queryBuilder.SetApiKey(apiKey);
            _queryBuilder.AddGetImageMethodQuery();
            _queryBuilder.SetSearchTags(new List<string>{searchConfig.KeyWord});
            _queryBuilder.SetItemsPerPageQuery(searchConfig.ItemsPerPage);
            _queryBuilder.SetItemsPerPageQuery(searchConfig.CurrentPage);
            _queryBuilder.SetSafeSearchQuery(1);
            _queryBuilder.SetExtras("url_t,url_s,url_l,url_m");
            _queryBuilder.SetFormat("json");
            _queryBuilder.AddNoJsonCallBack();

            return _queryBuilder.Build();

        }

        public string GetCommentsQuery(string apiKey, SearchConfig searchConfig)
        {
            _queryBuilder.SetApiKey(apiKey);
            _queryBuilder.AddGetCommentsMethodQuery();
            _queryBuilder.SetPhotoId("");
            _queryBuilder.SetFormat("json");
            _queryBuilder.AddNoJsonCallBack();

            return _queryBuilder.Build();
        }
    }
}
