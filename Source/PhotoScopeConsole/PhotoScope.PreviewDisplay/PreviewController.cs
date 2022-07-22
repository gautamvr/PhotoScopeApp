using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.Core.Interfaces;
using PhotoScope.PreviewDisplay.Interfaces;

namespace PhotoScope.PreviewDisplay
{
    public class PreviewController : IPreviewController
    {
        private IPreviewItemAccessor _previewItemAccessor;
        private IPreviewPopulator _previewPopulator;
        private string _selectedImageId;

        public PreviewController(IUnityContainer container)
        {
            _previewItemAccessor = container.Resolve<IPreviewItemAccessor>();
            _previewPopulator = container.Resolve<IPreviewPopulator>();
        }


        public async Task LoadPreview(string imageId,string imageUrl)
        {
            _selectedImageId = imageId;
            var previewModel = await _previewItemAccessor.GetPreviewItem(imageId);
            if (previewModel != null)
            {
                _previewPopulator.UpdatePreviewImageUrl(imageUrl);
                _previewPopulator.UpdatePreviewItem(previewModel);
            }
            
        }

        public void ClosePreview()
        {
            PreviewClosed?.Invoke(this,EventArgs.Empty);
        }

        public async Task LoadComments()
        {
            var currentPreviewModel = _previewPopulator.GetPreviewModel();
            if (currentPreviewModel.NumOfComments == 0)
            {
                return;
            }

            var comments = await _previewItemAccessor.GetCommentSection(_selectedImageId);
        }
        
        public void PostComment(string comment)
        {
            throw new NotImplementedException();
        }

        public event EventHandler PreviewClosed;
    }
}
