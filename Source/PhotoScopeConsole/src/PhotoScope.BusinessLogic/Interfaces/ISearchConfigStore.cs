using PhotoScope.Core.DtoModels;

namespace PhotoScope.BusinessLogic.Interfaces
{
    public interface ISearchConfigStore
    {
        void UpdateSearchConfig(SearchConfig searchConfig);

        SearchConfig GetSearchConfig();
    }
}