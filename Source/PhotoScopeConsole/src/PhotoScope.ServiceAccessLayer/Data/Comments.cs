using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace PhotoScope.ServiceAccessLayer.Data
{
    public class Comments
    {
        public string Photo_Id { get; set; }

        public IList<Comment> Comment { get; set; }
    }
}
