using PhotoScope.Core.DTOModels;

namespace PhotoScope.ServiceAccessLayer.Interfaces
{
    public interface IQueryManager
    {
        IQueryBuilder QueryBuilder { set; }

        string GetBaseAddress();
        
        string GetImageQuery(string apiKey, SearchParameters searchConfig);

        string GetCommentsQuery(string apiKey, string imageId);

        string GetImageInfoQuery(string apiKey, string imageId);
    }
}