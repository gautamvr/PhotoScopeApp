using PhotoScope.Core.DTOModels;

namespace ServiceAccess.Interfaces.Interfaces
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