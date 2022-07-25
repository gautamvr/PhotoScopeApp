using System;

namespace PhotoScope.Core.DTOModels
{
    /// <summary>
    /// A Comment Item in the comments List
    /// </summary>
    public class CommentItem : BaseModel
    {
        #region Private Properties

        private string _content;
        private string _authorName;
        private bool _isAuthorDeleted;
        private string _authorIconUrl;
        private DateTime _dateCreated;

        #endregion

        #region Public Properties

        /// <summary>
        /// Content of the comment
        /// </summary>
        public string Content
        {
            get => _content;
            set => SetField(ref _content,value);
        }

        /// <summary>
        /// The Person who commented
        /// </summary>
        public string AuthorName
        {
            get => _authorName;
            set => SetField(ref _authorName, value);
        }

        /// <summary>
        /// If the author's account is deleted
        /// </summary>
        public bool IsAuthorDeleted
        {
            get => _isAuthorDeleted;
            set => SetField(ref _isAuthorDeleted, value);
        }

        /// <summary>
        /// Display picture of the Author
        /// </summary>
        public string AuthorIconUrl
        {
            get => _authorIconUrl;
            set => SetField(ref _authorIconUrl, value);
        }

        /// <summary>
        /// Created date of the comment
        /// </summary>
        public DateTime DateCreated
        {
            get => _dateCreated;
            set => SetField(ref _dateCreated, value);
        }

        #endregion
    }
}
