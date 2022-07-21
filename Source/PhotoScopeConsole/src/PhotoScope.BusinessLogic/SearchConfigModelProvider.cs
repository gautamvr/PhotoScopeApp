using System;
using PhotoScope.BusinessLogic.Interfaces;
using PhotoScope.Core.DtoModels;
using PhotoScope.Core.Interfaces;

namespace PhotoScope.BusinessLogic
{
    public class SearchConfigModelProvider : IModelProvider<SearchConfig>
    {
        private ISearchConfigStore _searchConfigStore;

        public SearchConfigModelProvider(ISearchConfigStore searchConfigStore)
        {
            _searchConfigStore = searchConfigStore;
        }

        public SearchConfig GetInitialModel()
        {
            return _searchConfigStore.GetSearchConfig();
        }
    }
}
