using PhotoScope.Core.DTOModels;

namespace SearchDashboard.Interfaces
{
    public interface ISearchParameterStore
    {
        void UpdateSearchConfig(SearchParameters searchConfig);

        SearchParameters GetSearchConfig();

        void ResetParameters();
    }
}