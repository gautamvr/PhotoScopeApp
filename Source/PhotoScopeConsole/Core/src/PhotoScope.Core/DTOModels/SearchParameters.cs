namespace PhotoScope.Core.DTOModels
{
    /// <summary>
    /// Search Parameters based on the users input
    /// </summary>
    public class SearchParameters : ObservableModel
    {
        #region Private Properties

        private string _searchTag;
        private string _searchText;
        private int _itemsPerPage;
        private int _currentPage;

        #endregion

        #region Public Properties

        public string SearchTag
        {
            get => _searchTag;
            set => SetField(ref _searchTag,value);
        }

        public string SearchText
        {
            get => _searchText;
            set => SetField(ref _searchText, value);
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
