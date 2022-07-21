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
        public SearchParameters SearchConfig { get; private set; }

        public SearchParameterStore()
        {
            SearchConfig = new SearchParameters
            {
                CurrentPage = 1,
                ItemsPerPage = 10,
                SearchTag = "",
                SearchText = ""
            };
        }

        public void UpdateSearchConfig(SearchParameters searchConfig)
        {
            SearchConfig = searchConfig;
        }

        public SearchParameters GetSearchConfig()
        {
            return SearchConfig;
        }
    }
}
