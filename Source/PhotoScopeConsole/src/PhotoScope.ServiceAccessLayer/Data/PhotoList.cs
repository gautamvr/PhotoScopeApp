using System.Collections.Generic;

namespace PhotoScope.ServiceAccessLayer.Data
{
    public class PhotoList
    {
        public IEnumerable<PhotoItem> Photo { get; set; }
    }
}