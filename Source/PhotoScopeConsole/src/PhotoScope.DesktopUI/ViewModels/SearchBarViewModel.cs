
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
        private IFeedController _photoFeedHandler;
        private readonly PhotoFeedViewModel _feedViewModel;

        private bool _isValuePresent;

        public bool IsValuePresent
        {
            get { return _isValuePresent; }
            set { SetField(ref _isValuePresent, value); }
        }

        public string SearchWord
        {
            get => _searchWord;
            set
            {
                SetField(ref _searchWord, value);
                IsValuePresent = !string.IsNullOrEmpty(_searchWord) && _searchWord.Length >= 1;
            }
        }

        public ICommand SearchCommand { get; set; }

        public ICommand ResetCommand { get; set; }

        public SearchBarViewModel(IUnityContainer container)
        {
            _photoFeedHandler = container.Resolve<IFeedController>();
            _feedViewModel = container.Resolve<PhotoFeedViewModel>();
            SearchCommand = new Command(OnSearchCommand);
            ResetCommand = new Command(OnResetCommand);
        }

        private void OnResetCommand(object obj)
        {
            SearchWord = "";
            SearchCommand.Execute(null);

        }

        public async void OnSearchCommand(object searchKeyWord)
        {
            try
            {
                _feedViewModel.IsLoading = true;
                await _photoFeedHandler.UpdateFeed();
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
