using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoScope.BusinessLogic.Interfaces;
using PhotoScope.Core.DtoModels;

namespace PhotoScope.BusinessLogic
{
    public class SearchConfigStore : ISearchConfigStore
    {
        public SearchConfig SearchConfig { get; private set; }

        public SearchConfigStore()
        {
            SearchConfig = new SearchConfig
            {
                CurrentPage = 1,
                ItemsPerPage = 30,
                KeyWord = ""
            };
        }

        public void UpdateSearchConfig(SearchConfig searchConfig)
        {
            SearchConfig = searchConfig;
        }

        public SearchConfig GetSearchConfig()
        {
            return SearchConfig;
        }
    }
}
