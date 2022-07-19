using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;
using PhotoScope.ServiceAccessLayer.Data;

namespace PhotoScope.ServiceAccessLayer.Interfaces
{
    public interface IServiceAccessor
    {
        Task<PhotoList> GetImagesAsync(string keyword);
        PhotoList GetImages(string keyword);
    }
}