using System;

namespace PhotoScope.Core.DTOModels
{
    public class CommentItem : BaseModel
    {
        private string _content;
        private string _authorName;
        private bool _isAuthorDeleted;
        private string _authorIconUrl;
        private DateTime _dateCreated;

        public string Content
        {
            get => _content;
            set => SetField(ref _content,value);
        }

        public string AuthorName
        {
            get => _authorName;
            set => SetField(ref _authorName, value);
        }

        public bool IsAuthorDeleted
        {
            get => _isAuthorDeleted;
            set => SetField(ref _isAuthorDeleted, value);
        }

        public string AuthorIconUrl
        {
            get => _authorIconUrl;
            set => SetField(ref _authorIconUrl, value);
        }

        public DateTime DateCreated
        {
            get => _dateCreated;
            set => SetField(ref _dateCreated, value);
        }
    }
}
