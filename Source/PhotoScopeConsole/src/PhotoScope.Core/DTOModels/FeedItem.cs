using System.CodeDom;
using System.Security.AccessControl;

namespace PhotoScope.Core.DTOModels
{
    public class FeedItem
    {
        private string _imageUri;

        public string ImageUri
        {
            get
            {
                _imageUri = $"https://live.staticflickr.com/{Server}/{ID}_{Secret}_s.jpg";
                return _imageUri;
            }
            set { _imageUri = value; }
        }

        public string ID { get; set; }

        public string Owner { get; set; }

        public string Secret { get; set; }

        public string Server { get; set; }
        public string Farm { get; set; }

        public string Title { get; set; }

    }
}
