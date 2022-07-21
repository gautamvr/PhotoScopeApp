using PhotoScope.Core.DTOModels;

namespace PhotoScope.BusinessLogic.Interfaces
{
    public interface ISearchParameterStore
    {
        void UpdateSearchConfig(SearchParameters searchConfig);

        SearchParameters GetSearchConfig();
    }
}