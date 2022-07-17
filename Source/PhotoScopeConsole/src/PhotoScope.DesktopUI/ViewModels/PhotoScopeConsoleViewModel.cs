using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.Utilities.UI.Common;

namespace PhotoScope.DesktopUI.ViewModels
{
    public class PhotoScopeConsoleViewModel : ViewModelBase
    {

        public SearchBarViewModel SearchBarViewModel { get; set; }

        public PhotoFeedViewModel FeedViewModel { get; set; }

        public PhotoScopeConsoleViewModel(IUnityContainer container)
        {
            SearchBarViewModel = container.Resolve<SearchBarViewModel>();
            FeedViewModel = container.Resolve<PhotoFeedViewModel>();

        }
    }
}
