using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PhotoScope.Utilities.UI.Common;

namespace PhotoScope.DesktopUI.ViewModels
{
    public class SearchBarViewModel : ViewModelBase
    {
        private string _searchWord;

        public string SearchWord
        {
            get => _searchWord;
            set
            {
                _searchWord = value;
                OnPropertyChanged(SearchWord);
            }
        }

        public ICommand SearchCommand { get; set; }

        public SearchBarViewModel()
        {
            SearchCommand = new Command(OnSearchCommand);
        }

        public void OnSearchCommand(object searchKeyWord)
        {
            if (searchKeyWord != null)
            {
                string searchWord = searchKeyWord.ToString();
            }
        }
    }
}
