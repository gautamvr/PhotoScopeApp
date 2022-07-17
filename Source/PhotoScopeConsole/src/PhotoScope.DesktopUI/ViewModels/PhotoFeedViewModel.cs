using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;
using PhotoScope.Utilities.UI.Common;

namespace PhotoScope.DesktopUI.ViewModels
{
    public class PhotoFeedViewModel : ViewModelBase
    {
        private PhotoList _photoList;

        public PhotoList PhotoList
        {
            get { return _photoList; }
            set
            {
                SetField(ref _photoList, value);
            }
        }

        private ObservableCollection<PhotoItem> _gridItems;

        public ObservableCollection<PhotoItem> GridItems
        {
            get { return _gridItems; }
            set { _gridItems = value; }
        }


        public PhotoFeedViewModel()
        {
            GridItems = new ObservableCollection<PhotoItem>();
            GridItems.Add(new PhotoItem{ ImageUri = ""});
            GridItems.Add(new PhotoItem{ ImageUri = ""});
            GridItems.Add(new PhotoItem{ ImageUri = ""});
            GridItems.Add(new PhotoItem{ ImageUri = ""});
            GridItems.Add(new PhotoItem{ ImageUri = ""});
            GridItems.Add(new PhotoItem{ ImageUri = ""});

        }
    }
}
