using System;
using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;

namespace PhotoScope.Core.Interfaces
{
    public interface IFeedController
    {
        Task UpdateFeed(SearchParameters searchParams);

        void ClearFeed();

        Task RefreshFeed();

        void SelectImage(string imageId);
        
        Task LoadMore();

        event EventHandler FeedLoading;

        event EventHandler FeedLoaded;

        event EventHandler FeedCleared;

    }
}