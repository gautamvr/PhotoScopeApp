﻿using System;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.Core.Interfaces;
using PreviewDisplay.Interfaces;

namespace PreviewDisplay.BusinessLogic
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


        public async Task LoadPreview(string imageId)
        {
            try
            {
                _previewPopulator.ClearPreviewItem();
                PreviewLoading?.Invoke(this,EventArgs.Empty);
                _selectedImageId = imageId;
                var previewModel = await _previewItemAccessor.GetPreviewItem(imageId);
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
    }
}