using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.AccessControl;

namespace PhotoScope.Core.DTOModels
{
    public class PhotoList : ObservableModel
    {
        public ObservableCollection<PhotoItem> Photos { get; set; }

    }
}
