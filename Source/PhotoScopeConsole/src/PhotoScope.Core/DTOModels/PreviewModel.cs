using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoScope.Core.DTOModels
{
    public class PreviewModel : BaseModel
    {
        private PreviewItem _previewItem;

        public PreviewItem PreviewItem
        {
            get => _previewItem;
            set => SetField(ref _previewItem,value);
        }
    }
}
