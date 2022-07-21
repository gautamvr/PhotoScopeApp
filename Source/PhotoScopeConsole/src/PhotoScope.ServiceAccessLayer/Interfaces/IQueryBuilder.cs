﻿using System.Collections.Generic;
using System.Data;

namespace PhotoScope.ServiceAccessLayer.Interfaces
{
    public interface IQueryBuilder
    {
        void AddGetImageMethodQuery();

        void AddGetCommentsMethodQuery();

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