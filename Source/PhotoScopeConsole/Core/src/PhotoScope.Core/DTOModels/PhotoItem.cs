namespace PhotoScope.Core.DTOModels
{
    /// <summary>
    /// A Photo item that it to be displayed on the feed
    /// </summary>
    public class PhotoItem : FeedItem
    {
        #region Private Properties

        private string _url;
        private string _urlSmall;
        private string _urlLarge;
        private string _urlMedium;

        #endregion

        #region Public properties

        public new string Url
        {
            get => _url;
            set => SetField(ref _url, value);
        }

        public string UrlSmall
        {
            get => _urlSmall;
            set => SetField(ref _urlSmall, value);
        }
        public string UrlMedium
        {
            get => _urlMedium;
            set => SetField(ref _urlMedium, value);
        }

        public string UrlLarge
        {
            get => _urlLarge;
            set => SetField(ref _urlLarge, value);
        }

        #endregion
    }
}
