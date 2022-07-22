
using System;
using System.ComponentModel;
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
        private IFeedController _photoFeedHandler;
        private IModelProvider<SearchParameters> _modelProvider;
        private PhotoFeedViewModel _feedViewModel;

        private SearchParameters _searchParameters;

        public SearchParameters SearchParameters
        {
            get { return _searchParameters; }
            set { SetField(ref _searchParameters, value); }
        }

        private bool _isValuePresent;

        public bool IsValuePresent
        {
            get { return _isValuePresent; }
            set { SetField(ref _isValuePresent, value); }
        }

        public ICommand SearchCommand { get; set; }

        public ICommand ResetCommand { get; set; }

        public SearchBarViewModel(IUnityContainer container)
        {
            _photoFeedHandler = container.Resolve<IFeedController>();
            _feedViewModel = container.Resolve<PhotoFeedViewModel>();
            _modelProvider = container.Resolve<IModelProvider<SearchParameters>>();

            SearchParameters = _modelProvider.GetInitialModel();
            SearchParameters.PropertyChanged += OnSearchParametersChanged;

            SearchCommand = new Command(OnSearchCommand);
            ResetCommand = new Command(OnResetCommand);
        }

        private void OnSearchParametersChanged(object sender, PropertyChangedEventArgs e)
        {
            var keyWord = SearchParameters.SearchTag;
            IsValuePresent = !string.IsNullOrEmpty(keyWord) && keyWord.Length > 0;
        }

        private void OnResetCommand(object obj)
        {
            SearchParameters.SearchTag = "";

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
