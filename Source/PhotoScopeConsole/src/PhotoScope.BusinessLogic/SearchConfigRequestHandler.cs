using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.BusinessLogic.Interfaces;
using PhotoScope.Core.DtoModels;
using PhotoScope.Core.Interfaces;

namespace PhotoScope.BusinessLogic
{
    public class SearchConfigRequestHandler : IRequestUpdate
    {
        private ISearchConfigStore _searchConfigStore;

        public SearchConfigRequestHandler(IUnityContainer container)
        {
            _searchConfigStore = container.Resolve<ISearchConfigStore>();
        }

        public bool RequestUpdateConfig(SearchConfig updatedConfig)
        {
            var isChanged = false;
            if (updatedConfig != null)
            {
                _searchConfigStore.UpdateSearchConfig(updatedConfig);
                isChanged = true;
            }

            return isChanged;
            
        }
    }
}
