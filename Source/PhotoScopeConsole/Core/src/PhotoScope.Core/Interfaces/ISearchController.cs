using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;

namespace PhotoScope.Core.Interfaces
{
    /// <summary>
    /// Interface to control any action performed on search dashboard
    /// </summary>
    public interface ISearchController
    { 
        bool RequestUpdateConfig(SearchParameters updatedConfig);

        Task Search();

        void ResetParameters();

        void ClearResults();
    }
}