using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;
using PreviewDisplay.Interfaces;

namespace PreviewDisplay.BusinessLogic
{
    public class PreviewModelProvider : IModelProvider<PreviewModel>
    {
        private IPreviewPopulator _previewPopulator;
        private bool _isDisposed;

        public PreviewModelProvider(IPreviewPopulator previewPopulator)
        {
            _previewPopulator = previewPopulator;
        }


        public PreviewModel GetInitialModel()
        {
            return _previewPopulator.GetPreviewModel();
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                _previewPopulator.Dispose();
                _previewPopulator = null;
                _isDisposed = true;
            }
        }
    }
}
