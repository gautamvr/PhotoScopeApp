using System.Security.AccessControl;

namespace PhotoScope.Core.DTOModels
{
    public class SearchParameter : ObservableModel
    {
        public string KeyWord { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }
    }
}
