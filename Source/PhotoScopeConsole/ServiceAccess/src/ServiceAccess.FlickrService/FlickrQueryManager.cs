using System.Collections.Generic;
using Microsoft.Practices.Unity;
using PhotoScope.Core.DTOModels;
using ServiceAccess.Interfaces.Interfaces;

namespace ServiceAccess.FlickrService
{
    public class FlickrQueryManager : IQueryManager
    {
        #region Private Properties

        private IQueryBuilder _queryBuilder;
        private readonly string _baseAddress;
        private bool _isDisposed;

        #endregion

        #region Public methods

        public IQueryBuilder QueryBuilder
        {
            set => _queryBuilder = value;
        }

        public FlickrQueryManager(IUnityContainer container)
        {
            QueryBuilder = container.Resolve<IQueryBuilder>();
            _baseAddress = "https://api.flickr.com/services/";
        }


        public string GetBaseAddress()
        {
            return _baseAddress;
        }
        

        public string GetImageQuery(string apiKey, SearchParameters searchConfig)
        {
            _queryBuilder.SetApiKey(apiKey);
            _queryBuilder.AddGetImageMethodQuery();
            _queryBuilder.SetSearchTags(new List<string>{searchConfig.SearchTag});
            _queryBuilder.SetSearchText(searchConfig.SearchText);
            _queryBuilder.SetItemsPerPageQuery(searchConfig.ItemsPerPage);
            _queryBuilder.SetCurrentPageQuery(searchConfig.CurrentPage);
            _queryBuilder.SetSafeSearchQuery(1);
            _queryBuilder.SetExtras("url_t,url_s,url_l,url_m");
            _queryBuilder.SetFormat("json");
            _queryBuilder.AddNoJsonCallBack();

            return _queryBuilder.Build();

        }

        public string GetCommentsQuery(string apiKey, string imageId)
        {
            _queryBuilder.SetApiKey(apiKey);
            _queryBuilder.AddGetCommentsMethodQuery();
            _queryBuilder.SetPhotoId(imageId);
            _queryBuilder.SetFormat("json");
            _queryBuilder.AddNoJsonCallBack();

            return _queryBuilder.Build();
        }

        public string GetImageInfoQuery(string apiKey, string imageId)
        {
            _queryBuilder.SetApiKey(apiKey);
            _queryBuilder.AddGetImageInfoMethodQuery();
            _queryBuilder.SetPhotoId(imageId);
            _queryBuilder.SetFormat("json");
            _queryBuilder.AddNoJsonCallBack();

            return _queryBuilder.Build();

        }

        #endregion


        #region Dispose Pattern

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _queryBuilder.Dispose();
                _isDisposed = true;
            }

        }

        #endregion
    }
}
