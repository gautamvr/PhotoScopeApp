using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoFeed.UI.ViewModel;
using PhotoFeed.Utilities.UI.Common;
using PhotoScope.Utilities.UI.Common;
using PreviewDisplay.UI.ViewModel;
using SearchDashboard.UI.ViewModel;

namespace HostControl.ConsoleUI.ViewModel
{
    public class PhotoScopeConsoleViewModel : ViewModelBase
    {
        public SearchDashboardViewModel SearchDashboardViewModel { get; set; }

        public PhotoFeedViewModel PhotoFeedViewModel { get; set; }

        public PreviewDisplayViewModel PreviewViewModel { get; set; }

        public PhotoScopeConsoleViewModel(IUnityContainer container)
        {
            PhotoFeedViewModel = container.Resolve<PhotoFeedViewModel>();
            SearchDashboardViewModel = container.Resolve<SearchDashboardViewModel>();
            PreviewViewModel = container.Resolve<PreviewDisplayViewModel>();
        }
    }
}
