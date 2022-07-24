using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoScope.ServiceAccessLayer.Data
{
    public class OwnerInfo
    {
        public string Nsid { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Location { get; set; }
        public string IconServer { get; set; }
        public string IconFarm { get; set; }

    }
}
