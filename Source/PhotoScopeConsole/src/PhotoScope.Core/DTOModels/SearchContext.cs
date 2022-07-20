using System.Security.AccessControl;

namespace PhotoScope.Core.DTOModels
{
    public class SearchConfigurations : ObservableModel
    {
        public string KeyWord { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }
    }
}
