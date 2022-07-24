using Microsoft.Practices.Unity;
using PhotoFeed.Interfaces;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;

namespace PhotoFeed.BusinessLogic
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
