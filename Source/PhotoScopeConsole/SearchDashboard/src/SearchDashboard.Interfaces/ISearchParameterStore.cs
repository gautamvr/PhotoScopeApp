using System;
using PhotoScope.Core.DTOModels;

namespace SearchDashboard.Interfaces
{
    /// <summary>
    /// Stores the Search Parameter DTO model
    /// </summary>
    public interface ISearchParameterStore : IDisposable
    {
        /// <summary>
        /// Updates the Search Parameter
        /// </summary>
        /// <param name="searchConfig"></param>
        void UpdateSearchConfig(SearchParameters searchConfig);

        /// <summary>
        /// Gets the Search Config
        /// </summary>
        /// <returns></returns>
        SearchParameters GetSearchConfig();

        /// <summary>
        /// Resets the Parameters
        /// </summary>
        void ResetParameters();
    }
}