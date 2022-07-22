using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PhotoScope.ServiceAccessLayer.Data
{
    public class PhotoInfo
    {
        public string Id { get; set; }

        public string Secret { get; set; }
        public string Server { get; set; }
        public int Farm { get; set; }

        public string DateUploaded { get; set; }

        public OwnerInfo Owner { get; set; }

        public Content Title { get; set; }

        public Content Description { get; set; }

        public int Views { get; set; }

        
        public Content Comments { get; set; }
        
    }
}
