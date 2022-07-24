using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;
using PreviewDisplay.Interfaces;

namespace PreviewDisplay.BusinessLogic
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
