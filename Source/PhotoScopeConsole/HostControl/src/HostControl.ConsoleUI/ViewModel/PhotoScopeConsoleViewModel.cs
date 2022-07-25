using Microsoft.Practices.Unity;
using PhotoFeed.UI.ViewModel;
using PhotoScope.Utilities.UI.Common;
using PreviewDisplay.UI.ViewModel;
using SearchDashboard.UI.ViewModel;

namespace HostControl.ConsoleUI.ViewModel
{
    /// <summary>
    /// View model for PhotoScope console
    /// </summary>
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
