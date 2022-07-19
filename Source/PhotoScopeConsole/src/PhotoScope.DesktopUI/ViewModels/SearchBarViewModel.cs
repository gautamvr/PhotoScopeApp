
using System;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly PhotoFeedViewModel _feedViewModel;


        public string SearchWord
        {
            get => _searchWord;
            set => SetField(ref _searchWord, value);
        }

        public ICommand SearchCommand { get; set; }

        public SearchBarViewModel(IUnityContainer container)
        {
            _photoFeedHandler = container.Resolve<IPhotoFeedHandler>();
            _feedViewModel = container.Resolve<PhotoFeedViewModel>();
            SearchCommand = new Command(OnSearchCommand);
        }

        public async void OnSearchCommand(object searchKeyWord)
        {
            if (SearchWord != null && !string.IsNullOrEmpty(SearchWord))
            {
                try
                {
                    _feedViewModel.IsLoading = true;
                    await _photoFeedHandler.UpdateFeed(SearchWord);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    _feedViewModel.IsLoading = false;
                }
                
            }
            
        }
    }
}
