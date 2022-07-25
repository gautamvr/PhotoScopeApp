using System;
using System.Collections.Generic;
using PhotoScope.Core.DTOModels;

namespace PhotoFeed.Interfaces
{
    /// <summary>
    /// Pupulator for Feed dto
    /// </summary>
    public interface IFeedDtoPopulator : IDisposable
    {
        /// <summary>
        /// Gets the DTO Model
        /// </summary>
        /// <returns></returns>
        Feed GetDtoModel();

        /// <summary>
        /// Add items to the model
        /// </summary>
        /// <param name="item"></param>
        void AddToFeed(IList<FeedItem> item);

        /// <summary>
        /// Clears the items in the list
        /// </summary>
        void ClearFeed();

        //Updates the Search result tag
        void UpdateResultsTag(string resultTag);
    }
}