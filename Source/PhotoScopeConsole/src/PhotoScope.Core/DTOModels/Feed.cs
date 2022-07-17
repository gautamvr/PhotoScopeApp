using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoScope.Core.DTOModels
{
    public class Feed : ObservableModel
    {
        public FeedItemList Photos { get; set; }
    }
}
