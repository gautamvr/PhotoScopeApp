using PhotoScope.Core.DTOModels;
using SearchDashboard.Interfaces;

namespace SearchDashboard.BusinessLogic
{
    public class SearchParameterStore : ISearchParameterStore
    {
        private bool _isDisposed;

        #region Public Methods

        public SearchParameters SearchConfig { get; private set; }

        public SearchParameterStore()
        {
            SearchConfig = new SearchParameters
            {
                CurrentPage = 1,
                ItemsPerPage = 30,
                SearchTag = "",
                SearchText = ""
            };
        }

        public void UpdateSearchConfig(SearchParameters searchConfig)
        {
            SearchConfig.CurrentPage = searchConfig.CurrentPage;
            SearchConfig.ItemsPerPage = searchConfig.ItemsPerPage;
            SearchConfig.SearchTag = searchConfig.SearchTag;
            SearchConfig.SearchText = searchConfig.SearchText;
        }

        public void ResetParameters()
        {
            SearchConfig.CurrentPage = 1;
            SearchConfig.ItemsPerPage = 30;
            SearchConfig.SearchTag = "";
            SearchConfig.SearchText = "";
        }

        public SearchParameters GetSearchConfig()
        {
            return SearchConfig;
        }

        #endregion

        public void Dispose()
        {
            if (!_isDisposed)
            {
                ResetParameters();
                SearchConfig.ItemsPerPage = 0;
                SearchConfig.CurrentPage = 0;
                SearchConfig = null;
                _isDisposed = true;
            }
        }
    }
}
