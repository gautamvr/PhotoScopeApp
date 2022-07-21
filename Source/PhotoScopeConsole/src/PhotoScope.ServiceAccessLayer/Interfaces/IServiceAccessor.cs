using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;
using PhotoScope.ServiceAccessLayer.Data;

namespace PhotoScope.ServiceAccessLayer.Interfaces
{
    public interface IServiceAccessor
    {
        void SetApiKey(string apiKey);

        Task<PhotoList> GetImagesAsync(SearchParameters keyword);

        Task<PhotoList> GetCommentsAsync(string imageId);
    }
}