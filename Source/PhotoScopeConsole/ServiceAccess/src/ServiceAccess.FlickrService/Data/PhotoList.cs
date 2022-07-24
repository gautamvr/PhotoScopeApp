using System.Collections.Generic;

namespace ServiceAccess.FlickrService.Data
{
    public class PhotoList
    {
        public IEnumerable<PhotoModel> Photo { get; set; }
    }
}