using System.Collections.Generic;
using System.Threading.Tasks;
using PhotoScope.Core.DtoModels;
using PhotoScope.Core.DTOModels;

namespace PhotoScope.Core.Interfaces
{
    public interface IFeedItemAccessor
    {
        Task<IEnumerable<FeedItem>> GetFeedItems(SearchConfig searchConfig);
    }
}