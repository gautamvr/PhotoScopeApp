using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.Core.Interfaces;

namespace PhotoScope.BusinessLogic
{
    public class PhotoFeedHandler :IPhotoFeedHandler
    {
        private IUnityContainer _container;
        private IServiceAccessor _serviceAccessor;
        private IFeedDtoPopulator _feedPopulator;

        public PhotoFeedHandler(IUnityContainer container)
        {
            _container = container;
            _serviceAccessor = _container.Resolve<IServiceAccessor>();
            _feedPopulator = _container.Resolve<IFeedDtoPopulator>();
        }

        public void UpdateFeed(string searchTag)
        {
            var photoList = _serviceAccessor.GetImages(searchTag);
            _feedPopulator.PhotoListDto = photoList;
        }
    }
}
