using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;

namespace PhotoScope.Core.Interfaces
{
    public interface ISearchController
    { 
        bool RequestUpdateConfig(SearchParameters updatedConfig);

        Task Search();

        void ResetParameters();

        void ClearResults();
    }
}