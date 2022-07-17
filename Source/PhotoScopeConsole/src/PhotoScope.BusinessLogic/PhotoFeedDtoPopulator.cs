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
    public class PhotoFeedDtoPopulator : IFeedDtoPopulator
    {
        public PhotoList PhotoListDto { get; set; }

        private IServiceAccessor _serviceAccessor;

        public PhotoFeedDtoPopulator(IUnityContainer container)
        {
            _serviceAccessor = container.Resolve<IServiceAccessor>();
            PhotoListDto = new PhotoList();
        }

        public PhotoList GetPhotoList()
        {
            return PhotoListDto;
        }
    }
}
