using System;
using PhotoScope.BusinessLogic.Interfaces;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;

namespace PhotoScope.BusinessLogic
{
    public class SearchParameterModelProvider : IModelProvider<SearchParameters>
    {
        private ISearchParameterStore _searchConfigStore;

        public SearchParameterModelProvider(ISearchParameterStore searchConfigStore)
        {
            _searchConfigStore = searchConfigStore;
        }

        public SearchParameters GetInitialModel()
        {
            return _searchConfigStore.GetSearchConfig();
        }
    }
}
