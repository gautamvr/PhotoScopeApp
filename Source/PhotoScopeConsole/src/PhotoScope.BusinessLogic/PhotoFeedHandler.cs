using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.Core.DTOModels;
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

        public async void UpdateFeed(string searchTag)
        {
            var photoList = await _serviceAccessor.GetImages(searchTag);

            ProcessImages(photoList);
        }

        private void ProcessImages(Feed photoList)
        {
            var photoItems = photoList.Photos?.Photo;

            if (photoItems != null)
            {
                foreach (var feedItem in photoItems)
                {
                    _feedPopulator.FeedDto.Photos.Photo.Add(feedItem);
                }
            }
        }
    }
}
