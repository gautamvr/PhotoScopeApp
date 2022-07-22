using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;
using PhotoScope.PreviewDisplay.Interfaces;

namespace PhotoScope.PreviewDisplay
{
    public class PreviewModelProvider : IModelProvider<PreviewModel>
    {

        private IPreviewPopulator _previewPopulator;

        public PreviewModelProvider(IPreviewPopulator previewPopulator)
        {
            _previewPopulator = previewPopulator;
        }


        public PreviewModel GetInitialModel()
        {
            return _previewPopulator.GetPreviewModel();
        }
    }
}
