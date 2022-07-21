using System.Collections.Generic;

namespace PhotoScope.ServiceAccessLayer.Data
{
    public class PhotoList
    {
        public IEnumerable<PhotoModel> Photo { get; set; }
    }
}