using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;

namespace PhotoScope.Core.Interfaces
{
    public interface IServiceAccessor
    {
        Task<Feed> GetImages(string keyword);
    }
}