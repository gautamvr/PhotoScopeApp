namespace PhotoScope.Core.DTOModels
{
    /// <summary>
    /// Owner details of the preview item
    /// </summary>
    public class PreviewItemOwner : BaseModel
    {
        #region Private Properties

        private string _userName;
        private string _location;
        private string _fullName;
        private string _displayPhotoUrl;

        #endregion


        #region Public properties

        public string FullName
        {
            get => _fullName;
            set => SetField(ref _fullName,value);
        }
        
        public string UserName
        {
            get => _userName;
            set => SetField(ref _userName, value);
        }
        
        public string Location
        {
            get => _location;
            set => SetField(ref _location, value);
        }

        public string DisplayPhotoUrl
        {
            get => _displayPhotoUrl;
            set => SetField(ref _displayPhotoUrl, value);
        }

        #endregion
    }
}
