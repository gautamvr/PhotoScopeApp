
using Microsoft.Practices.Unity;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;

namespace PhotoScope.BusinessLogic
{
    public class PhotoListModelProvider : IModelProvider<PhotoList>
    {
        private IFeedDtoPopulator _feedDtoPopulator;

        public PhotoListModelProvider(IUnityContainer container)
        {
            _feedDtoPopulator = container.Resolve<IFeedDtoPopulator>();
        }

        public PhotoList GetInitialModel()
        {
            return _feedDtoPopulator.PhotoListDto;
        }
    }
}
