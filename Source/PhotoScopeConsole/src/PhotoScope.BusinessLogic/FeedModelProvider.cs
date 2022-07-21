
using Microsoft.Practices.Unity;
using PhotoScope.BusinessLogic.Interfaces;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;

namespace PhotoScope.BusinessLogic
{
    public class FeedModelProvider : IModelProvider<Feed>
    {
        private IFeedDtoPopulator _feedDtoPopulator;

        public FeedModelProvider(IUnityContainer container)
        {
            _feedDtoPopulator = container.Resolve<IFeedDtoPopulator>();
        }

        public Feed GetInitialModel()
        {
            return _feedDtoPopulator.GetDtoModel();
        }
    }
}
