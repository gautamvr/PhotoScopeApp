
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;
using PhotoScope.Utilities.UI.Common;

namespace PhotoScope.DesktopUI.ViewModels
{
    public class SearchBarViewModel : ViewModelBase
    {
        private string _searchWord;
        private IPhotoFeedHandler _photoFeedHandler;

        public string SearchWord
        {
            get => _searchWord;
            set => SetField(ref _searchWord, value);
        }

        public ICommand SearchCommand { get; set; }

        public SearchBarViewModel(IUnityContainer container)
        {
            _photoFeedHandler = container.Resolve<IPhotoFeedHandler>();
            SearchCommand = new Command(OnSearchCommand);
        }

        public void OnSearchCommand(object searchKeyWord)
        {
            if (SearchWord != null && !string.IsNullOrEmpty(SearchWord))
            {
                _photoFeedHandler.UpdateFeed(SearchWord);
            }
            
        }
    }
}
