using System;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.Core.Interfaces;
using PreviewDisplay.Interfaces;

namespace PreviewDisplay.BusinessLogic
{
    public class PreviewController : IPreviewController
    {
        #region Private Properties

        private IPreviewItemAccessor _previewItemAccessor;
        private IPreviewPopulator _previewPopulator;
        private string _selectedImageId;
        private bool _isDisposed;

        #endregion

        #region Public Methods and events

        public PreviewController(IUnityContainer container)
        {
            _previewItemAccessor = container.Resolve<IPreviewItemAccessor>();
            _previewPopulator = container.Resolve<IPreviewPopulator>();
        }


        public async Task LoadPreview(string imageId)
        {
            try
            {
                _previewPopulator.ClearPreviewItem();
                _previewPopulator.OpenPreviewDisplay(); 
                PreviewLoading?.Invoke(this,EventArgs.Empty);
                _selectedImageId = imageId;
                await _previewItemAccessor.GetPreviewItem(imageId);
                PreviewLoaded?.Invoke(this,EventArgs.Empty);
            }
            catch (Exception)
            {
                ClosePreview();
            }
        }

        public void ClosePreview()
        {
            PreviewClosed?.Invoke(this,EventArgs.Empty);
            _previewPopulator.ClosePreviewDisplay();
            _previewPopulator.ClearPreviewItem();
        }

        public async Task LoadComments()
        {
            var currentPreviewModel = _previewPopulator.GetPreviewModel();
            if (currentPreviewModel.PreviewItem.NumOfComments == 0)
            {
                return;
            }

            var comments = await _previewItemAccessor.GetCommentSection(_selectedImageId);
            _previewPopulator.UpdateComments(comments);
        }
        
        public void PostComment(string comment)
        {
            throw new NotImplementedException();
        }

        public event EventHandler PreviewClosed;

        public event EventHandler PreviewLoading;

        public event EventHandler PreviewLoaded;

        #endregion

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _previewItemAccessor?.Dispose();
                _previewPopulator?.Dispose();
                _previewPopulator = null;
                _previewItemAccessor = null;
                _selectedImageId = "";
                _isDisposed = true;
            }
        }
    }
}
