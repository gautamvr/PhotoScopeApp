using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoFeed.Interfaces;
using PhotoScope.Core.DTOModels;
using ServiceAccess.FlickrService.Data;
using ServiceAccess.FlickrService.Interfaces;

namespace PhotoFeed.BusinessLogic
{
    internal class PhotoItemAccessor : IFeedItemAccessor
    {
        private IServiceAccessor _serviceAccessor;

        public PhotoItemAccessor(IUnityContainer container)
        {
            _serviceAccessor = container.Resolve<IServiceAccessor>();
        }

        public async Task<IEnumerable<FeedItem>> GetFeedItems(SearchParameters searchConfig)
        {
            var photos = await _serviceAccessor.GetImagesAsync(searchConfig);
            return ProcessImages(photos);
        }

        private IEnumerable<FeedItem> ProcessImages(PhotoList photoList)
        {
            if (photoList != null)
            {
                foreach (var photoItem in photoList.Photo)
                {
                    if (photoItem != null)
                    {
                        yield return CreatePhotoItem(photoItem);
                    }
                }
            }
        }

        private PhotoItem CreatePhotoItem(PhotoModel photo)
        {
            return new PhotoItem
            {
                ItemId = photo.ID,
                Title = photo.Title,
                UrlLarge = photo.Url_l,
                UrlSmall = photo.Url_s,
                UrlMedium = photo.Url_m,
                Url = photo.Url_t,
                Owner = photo.Owner
            };
        }
    }
}
