using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;
using PhotoScope.ServiceAccessLayer.Data;
using PhotoScope.ServiceAccessLayer.Interfaces;

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
            var photoList = await _serviceAccessor.GetImagesAsync(searchTag);

            ProcessImages(photoList);
        }

        private void ProcessImages(PhotoList photoList)
        {
            if (photoList != null)
            {
                foreach (var photoItem in photoList.Photo)
                {
                    var feedItem=CreateFeedItem(photoItem);
                    _feedPopulator.FeedDto.FeedItems.Add(feedItem);
                }
            }
        }

        private FeedItem CreateFeedItem(PhotoItem photo)
        {
            return new FeedItem
            {
                ID = photo.ID,
                Title = photo.Title,
                Url_l = photo.Url_l,
                Url_s = photo.Url_s,
                Url_m = photo.Url_m,
                Url_t = photo.Url_t,
                Owner = photo.Owner
            };
        }
    }
}
