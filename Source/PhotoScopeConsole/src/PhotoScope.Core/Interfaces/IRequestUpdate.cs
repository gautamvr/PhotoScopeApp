using PhotoScope.Core.DtoModels;

namespace PhotoScope.Core.Interfaces
{
    public interface IRequestUpdate
    { 
        bool RequestUpdateConfig(SearchConfig updatedConfig);
    }
}