using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;

namespace PhotoScope.BusinessLogic
{
    public class PhotoFeedDtoPopulator : IFeedDtoPopulator
    {
        public Feed FeedDto { get; set; }

        private IServiceAccessor _serviceAccessor;

        public PhotoFeedDtoPopulator(IUnityContainer container)
        {
            _serviceAccessor = container.Resolve<IServiceAccessor>();

            FeedDto = new Feed();
            FeedDto.Photos = new FeedItemList();
            FeedDto.Photos.Photo = new ObservableCollection<FeedItem>();
        }

        public Feed GetPhotoList()
        {
            return FeedDto;
        }
    }
}
