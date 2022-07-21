using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.BusinessLogic.Interfaces;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;

namespace PhotoScope.BusinessLogic
{
    public class SearchParameterRequestHandler : IRequestUpdate
    {
        private ISearchParameterStore _searchConfigStore;

        public SearchParameterRequestHandler(IUnityContainer container)
        {
            _searchConfigStore = container.Resolve<ISearchParameterStore>();
        }

        public bool RequestUpdateConfig(SearchParameters updatedConfig)
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
