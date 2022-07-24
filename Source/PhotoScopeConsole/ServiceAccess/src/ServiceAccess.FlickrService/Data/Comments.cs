using System.Collections.Generic;

namespace ServiceAccess.FlickrService.Data
{
    public class Comments
    {
        public string Photo_Id { get; set; }

        public IList<Comment> Comment { get; set; }
    }
}
