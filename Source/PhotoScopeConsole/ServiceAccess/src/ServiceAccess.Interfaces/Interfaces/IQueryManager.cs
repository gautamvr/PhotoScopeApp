using System;
using PhotoScope.Core.DTOModels;

namespace ServiceAccess.Interfaces.Interfaces
{
    /// <summary>
    /// Query manager to manager building the queries
    /// </summary>
    public interface IQueryManager : IDisposable
    {
        /// <summary>
        /// Instance of IQueryBuilder
        /// </summary>
        IQueryBuilder QueryBuilder { set; }

        /// <summary>
        /// Gets Base Address
        /// </summary>
        /// <returns></returns>
        string GetBaseAddress();
        
        /// <summary>
        /// Gets final query generated for Get Image
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="searchConfig"></param>
        /// <returns></returns>
        string GetImageQuery(string apiKey, SearchParameters searchConfig);

        /// <summary>
        /// Final query generation for Get Comments
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="imageId"></param>
        /// <returns></returns>
        string GetCommentsQuery(string apiKey, string imageId);

        /// <summary>
        /// Final query generation for Get Image info
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="imageId"></param>
        /// <returns></returns>
        string GetImageInfoQuery(string apiKey, string imageId);
    }
}