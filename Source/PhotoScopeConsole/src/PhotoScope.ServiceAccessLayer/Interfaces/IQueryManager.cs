using PhotoScope.Core.DtoModels;

namespace PhotoScope.ServiceAccessLayer.Interfaces
{
    public interface IQueryManager
    {
        IQueryBuilder QueryBuilder { set; }

        string GetBaseAddress();

        void UpdateQueryBuilder(IQueryBuilder queryBuilder);

        string GetImageQuery(string apiKey, SearchConfig searchConfig);

        string GetCommentsQuery(string apiKey, SearchConfig searchConfig);
    }
}