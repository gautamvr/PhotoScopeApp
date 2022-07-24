namespace PhotoScope.Core.DTOModels
{
    public class FeedItem : BaseModel
    {
        #region Private Properties

        private string _url;
        private string _itemId;
        private string _title;
        private string _owner;
        #endregion


        #region Public Properties

        public string Url
        {
            get => _url;
            set => SetField(ref _url,value);
        }

        public string ItemId
        {
            get => _itemId;
            set => SetField(ref _itemId,value);
        }

        public string Title
        {
            get => _title;
            set => SetField(ref _title,value);
        }

        public string Owner
        {
            get => _owner;
            set => SetField(ref _owner,value);
        }

        #endregion
    }
}
