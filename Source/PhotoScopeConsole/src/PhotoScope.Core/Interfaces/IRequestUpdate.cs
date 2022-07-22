using PhotoScope.Core.DTOModels;

namespace PhotoScope.Core.Interfaces
{
    public interface IRequestUpdate
    { 
        bool RequestUpdateConfig(SearchParameters updatedConfig);
    }
}