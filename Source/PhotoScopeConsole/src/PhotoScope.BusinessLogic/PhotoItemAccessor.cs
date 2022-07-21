using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.BusinessLogic.Interfaces;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;
using PhotoScope.ServiceAccessLayer.Data;
using PhotoScope.ServiceAccessLayer.Interfaces;

namespace PhotoScope.BusinessLogic
{
    internal class PhotoItemAccessor : IFeedItemAccessor
    {
        private IServiceAccessor _serviceAccessor;

        public PhotoItemAccessor(IUnityContainer container)
        {
            _serviceAccessor = container.Resolve<IServiceAccessor>();

            var configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            
            var apiKey  = configuration.AppSettings.Settings["APIKey"].Value;
            _serviceAccessor.SetApiKey(apiKey);
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
            return new PhotoItem()
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
