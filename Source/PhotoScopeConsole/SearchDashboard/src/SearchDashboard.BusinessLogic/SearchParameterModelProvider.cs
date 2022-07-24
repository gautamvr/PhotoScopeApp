using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;
using SearchDashboard.Interfaces;

namespace SearchDashboard.BusinessLogic
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
