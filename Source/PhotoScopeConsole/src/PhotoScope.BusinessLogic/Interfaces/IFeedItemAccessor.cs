using System.Collections.Generic;
using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;

namespace PhotoScope.BusinessLogic.Interfaces
{
    public interface IFeedItemAccessor
    {
        Task<IEnumerable<FeedItem>> GetFeedItems(SearchParameters searchConfig);
    }
}