
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
        private ISearchController _searchController;
        private IModelProvider<SearchParameters> _modelProvider;

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

        public ICommand ResetParametersCommand { get; set; }
        public ICommand ClearResultsCommand { get; set; }

        public ICommand ResetTextCommand { get; set; }

        public SearchBarViewModel(IUnityContainer container)
        {
            _searchController = container.Resolve<ISearchController>();
            _modelProvider = container.Resolve<IModelProvider<SearchParameters>>();

            SearchParameters = _modelProvider.GetInitialModel();
            SearchParameters.PropertyChanged += OnSearchParametersChanged;

            SearchCommand = new Command(OnSearchCommand);
            ResetTextCommand = new Command(OnResetTextCommand);
            ResetParametersCommand = new Command(OnResetParamCommand);
            ClearResultsCommand = new Command(OnClearResultsCommand);
        }

        private void OnResetTextCommand(object obj)
        {
            SearchParameters.SearchTag = "";
        }

        private void OnClearResultsCommand(object obj)
        {
            _searchController.ClearResults();
        }

        private void OnSearchParametersChanged(object sender, PropertyChangedEventArgs e)
        {
            var keyWord = SearchParameters.SearchTag;
            IsValuePresent = !string.IsNullOrEmpty(keyWord) && keyWord.Length > 0;
        }

        private void OnResetParamCommand(object obj)
        {
            _searchController.ResetParameters();
        }

        public async void OnSearchCommand(object obj)
        {
            try
            {
                await _searchController.Search();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
