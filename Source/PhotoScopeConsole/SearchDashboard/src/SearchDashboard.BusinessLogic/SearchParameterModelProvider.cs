using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;
using SearchDashboard.Interfaces;

namespace SearchDashboard.BusinessLogic
{
    /// <summary>
    /// Model provider for Search Parameters
    /// </summary>
    public class SearchParameterModelProvider : IModelProvider<SearchParameters>
    {
        private ISearchParameterStore _searchConfigStore;
        private bool _isDispose;

        public SearchParameterModelProvider(ISearchParameterStore searchConfigStore)
        {
            _searchConfigStore = searchConfigStore;
        }

        /// <summary>
        /// Gets the initial model
        /// </summary>
        /// <returns></returns>
        public SearchParameters GetInitialModel()
        {
            return _searchConfigStore.GetSearchConfig();
        }

        public void Dispose()
        {
            if (!_isDispose)
            {
                _searchConfigStore?.Dispose();
                _isDispose = true;
            }
        }
    }
}
