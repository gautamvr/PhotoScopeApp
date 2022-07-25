using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using PhotoFeed.Utilities.UI.Common;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Exceptions;
using PhotoScope.Core.Interfaces;
using PhotoScope.Utilities.UI.Common;

namespace SearchDashboard.UI.ViewModel
{
    public class SearchDashboardViewModel : ViewModelBase
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
        private bool _isError;
        private string _errorMessage;

        public bool IsValuePresent
        {
            get { return _isValuePresent; }
            set { SetField(ref _isValuePresent, value); }
        }

        public bool IsError
        {
            get => _isError;
            set => SetField(ref _isError, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetField(ref _errorMessage,value);
        }

        public ICommand SearchCommand { get; set; }

        public ICommand ResetParametersCommand { get; set; }
        public ICommand ClearResultsCommand { get; set; }

        public ICommand ResetTextCommand { get; set; }

        public SearchDashboardViewModel(IUnityContainer container)
        {
            _searchController = container.Resolve<ISearchController>();
            _modelProvider = container.Resolve<IModelProvider<SearchParameters>>();

            SearchParameters = _modelProvider.GetInitialModel();
            SearchParameters.PropertyChanged += OnSearchParametersChanged;

            SearchCommand = new Command(OnSearchCommand);
            ResetTextCommand = new Command(OnResetTextCommand);
            ResetParametersCommand = new Command(OnResetParamCommand);
            ClearResultsCommand = new Command(OnClearResultsCommand);
            IsError = false;
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
            catch (IncorrectParameterException e)
            {
                IsError = true;
                ErrorMessage = $"ERROR:{e.Message}";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
