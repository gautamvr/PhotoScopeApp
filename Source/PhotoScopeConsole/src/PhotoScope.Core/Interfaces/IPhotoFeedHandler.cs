using System.Threading.Tasks;

namespace PhotoScope.Core.Interfaces
{
    public interface IPhotoFeedHandler
    {
        Task UpdateFeedAsync(string searchTag);
        
    }
}