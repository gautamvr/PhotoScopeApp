using System.Collections.ObjectModel;

namespace PhotoScope.Core.DTOModels
{
    public class PreviewItem : BaseModel
    {
        #region Private Properties

        private string _title;
        private string _imageId;
        private string _imageUrl;
        private string _description;
        private int _views;
        private int _numOfComments;
        private PreviewItemOwner _previewItemOwner;
        private ObservableCollection<CommentItem> _commentsList;

        #endregion

        #region Public Properties

        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }

        public string ImageId
        {
            get => _imageId;
            set => SetField(ref _imageId, value);
        }

        public string ImageUrl
        {
            get => _imageUrl;
            set => SetField(ref _imageUrl, value);
        }

        public string Description
        {
            get => _description;
            set => SetField(ref _description, value);
        }

        public int Views
        {
            get => _views;
            set => SetField(ref _views, value);
        }

        public int NumOfComments
        {
            get => _numOfComments;
            set => SetField(ref _numOfComments, value);
        }

        public PreviewItemOwner PreviewItemOwner
        {
            get => _previewItemOwner;
            set => SetField(ref _previewItemOwner, value);
        }

        public ObservableCollection<CommentItem> CommentsList
        {
            get => _commentsList;
            set => SetField(ref _commentsList, value);
        }

        #endregion
    }
}
