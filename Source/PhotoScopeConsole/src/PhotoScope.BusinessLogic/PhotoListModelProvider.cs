
using Microsoft.Practices.Unity;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;

namespace PhotoScope.BusinessLogic
{
    public class PhotoListModelProvider : IModelProvider<Feed>
    {
        private IFeedDtoPopulator _feedDtoPopulator;

        public PhotoListModelProvider(IUnityContainer container)
        {
            _feedDtoPopulator = container.Resolve<IFeedDtoPopulator>();
        }

        public Feed GetInitialModel()
        {
            return _feedDtoPopulator.FeedDto;
        }
    }
}
