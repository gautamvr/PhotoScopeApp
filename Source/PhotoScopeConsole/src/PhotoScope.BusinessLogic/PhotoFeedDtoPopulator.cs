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

        public PhotoFeedDtoPopulator(IUnityContainer container)
        {
            FeedDto = new Feed();
            FeedDto.FeedItems = new ObservableCollection<FeedItem>();
        }

        public Feed GetFeedModel()
        {
            return FeedDto;
        }
    }
}
