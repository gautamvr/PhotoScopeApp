using PhotoScope.Core.DTOModels;

namespace PhotoScope.ServiceAccessLayer.Interfaces
{
    public interface IQueryManager
    {
        IQueryBuilder QueryBuilder { set; }

        string GetBaseAddress();

        void UpdateQueryBuilder(IQueryBuilder queryBuilder);

        string GetImageQuery(string apiKey, SearchParameters searchConfig);

        string GetCommentsQuery(string apiKey, SearchParameters searchConfig);
    }
}