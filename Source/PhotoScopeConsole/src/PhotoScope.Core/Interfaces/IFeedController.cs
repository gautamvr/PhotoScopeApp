using System.Threading.Tasks;

namespace PhotoScope.Core.Interfaces
{
    public interface IFeedController
    {
        Task UpdateFeed();
        void ClearFeed();
        Task RefreshFeed();

        void SelectImage(string imageId);
        
        Task LoadMore();
        
    }
}