using PhotoScope.Core.DTOModels;

namespace PhotoScope.Core.DtoModels
{
    public class SearchConfig : ObservableModel
    {
        #region Private Properties

        private string _keyWord;
        private int _itemsPerPage;
        private int _currentPage;

        #endregion

        #region Public Properties

        public string KeyWord
        {
            get => _keyWord;
            set => SetField(ref _keyWord,value);
        }

        public int ItemsPerPage
        {
            get => _itemsPerPage;
            set => SetField(ref _itemsPerPage, value);
        }

        public int CurrentPage
        {
            get => _currentPage;
            set => SetField(ref _currentPage, value);
        }

        #endregion
    }
}
