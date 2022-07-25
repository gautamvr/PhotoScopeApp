using Microsoft.Practices.Unity;
using PhotoFeed.Interfaces;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;

namespace PhotoFeed.BusinessLogic
{
    public class FeedModelProvider : IModelProvider<Feed>
    {
        private IFeedDtoPopulator _feedDtoPopulator;
        private bool _isDisposed;

        public FeedModelProvider(IUnityContainer container)
        {
            _feedDtoPopulator = container.Resolve<IFeedDtoPopulator>();
        }

        public Feed GetInitialModel()
        {
            return _feedDtoPopulator.GetDtoModel();
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _feedDtoPopulator?.Dispose();
                _feedDtoPopulator = null;
                _isDisposed = true;
            }
            
        }
    }
}
