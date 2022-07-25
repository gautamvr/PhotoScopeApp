using System;
using System.Collections.Generic;

namespace ServiceAccess.Interfaces.Interfaces
{
    /// <summary>
    /// Builder interface that has necessary build functions to build a query
    /// </summary>
    public interface IQueryBuilder : IDisposable
    {
        void AddGetImageMethodQuery();

        void AddGetCommentsMethodQuery();

        void AddGetImageInfoMethodQuery();

        void AddNoJsonCallBack();

        void SetExtras(string extras);

        void SetFormat(string format);

        void SetApiKey(string apiKey);

        void SetPhotoId(string imageId);

        void SetSearchTags(List<string> tags);

        void SetSearchText(string text);

        void SetItemsPerPageQuery(int itemsPerPage);

        void SetCurrentPageQuery(int currentPage);
        
        void SetSafeSearchQuery(int id);

        string Build();

        void Reset();
    }
}