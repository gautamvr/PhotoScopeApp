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
    public class SearchController : ISearchController
    {
        private ISearchParameterStore _searchParameterStore;
        private IFeedController _feedController;

        public SearchController(IUnityContainer container)
        {
            _searchParameterStore = container.Resolve<ISearchParameterStore>();
            _feedController = container.Resolve<IFeedController>();
        }

        public bool RequestUpdateConfig(SearchParameters updatedConfig)
        {
            var isChanged = false;
            if (updatedConfig != null)
            {
                _searchParameterStore.UpdateSearchConfig(updatedConfig);
                isChanged = true;
            }

            return isChanged;
            
        }

        public async Task Search()
        {
            var searchParam = _searchParameterStore.GetSearchConfig();
            await _feedController.UpdateFeed(searchParam);
        }

        public void ResetParameters()
        {
            _searchParameterStore.ResetParameters();
        }

        public void ClearResults()
        {
            _feedController.ClearFeed();
        }
    }
}
