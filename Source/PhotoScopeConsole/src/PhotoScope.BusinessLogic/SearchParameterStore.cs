using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoScope.BusinessLogic.Interfaces;
using PhotoScope.Core.DTOModels;

namespace PhotoScope.BusinessLogic
{
    public class SearchParameterStore : ISearchParameterStore
    {
        public SearchParameters SearchConfig { get; }

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
    }
}
