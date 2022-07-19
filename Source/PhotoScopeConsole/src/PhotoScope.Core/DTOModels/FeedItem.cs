using System.CodeDom;
using System.Security.AccessControl;

namespace PhotoScope.Core.DTOModels
{
    public class FeedItem : ObservableModel
    {
        public string Url_s { get; set; }
        public string Url_m { get; set; }
        public string Url_l { get; set; }
        public string Url_t { get; set; }

        public string ID { get; set; }

        public string Title { get; set; }
        public string Owner { get; set; }
    }
}
