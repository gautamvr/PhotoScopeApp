using System.Collections.Generic;
using System.Collections.ObjectModel;
using PhotoScope.Core.DTOModels;
using PreviewDisplay.Interfaces;

namespace PreviewDisplay.BusinessLogic
{
    public class PreviewPopulator : IPreviewPopulator
    {
        private bool _isDisposed;

        #region Public Methods

        public PreviewModel PreviewDtoModel { get; private set; }

        public PreviewPopulator()
        {
            PreviewDtoModel = new PreviewModel()
            {
                PreviewItem = new PreviewItem()
                {
                    CommentsList = new ObservableCollection<CommentItem>(),
                    PreviewItemOwner = new PreviewItemOwner()
                },
                IsPreviewOpen = false
                
            };
        }

        public void ClosePreviewDisplay()
        {
            PreviewDtoModel.IsPreviewOpen = false;
        }

        public void UpdatePreviewItem(PreviewItem previewItem)
        {
            if (previewItem != null)
            {
                PreviewDtoModel.PreviewItem = previewItem;
            }
        }

        public void UpdatePreviewImageUrl(string imageUrl)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                PreviewDtoModel.PreviewItem.ImageUrl = imageUrl;
            }
        }

        public void UpdateComments(IEnumerable<CommentItem> comments)
        {
            if (comments != null)
            {
                foreach (var comment in comments)
                {
                    if (comment != null)
                    {
                        PreviewDtoModel.PreviewItem.CommentsList.Add(comment);
                    }
                }
            }
            
        }
        
        public PreviewModel GetPreviewModel()
        {
            return PreviewDtoModel;
        }

        public void ClearPreviewItem()
        {
            if (PreviewDtoModel?.PreviewItem != null)
            {
                PreviewDtoModel.PreviewItem.CommentsList.Clear();
                PreviewDtoModel.PreviewItem.Title = "";
                PreviewDtoModel.PreviewItem.ImageUrl = "";
                PreviewDtoModel.PreviewItem.NumOfComments = 0;
                PreviewDtoModel.PreviewItem.ImageId = "";
                PreviewDtoModel.PreviewItem.Views = 0;
                PreviewDtoModel.PreviewItem.Description = "";

                if (PreviewDtoModel.PreviewItem.PreviewItemOwner!= null) 
                {
                    PreviewDtoModel.PreviewItem.PreviewItemOwner.DisplayPhotoUrl = "";
                    PreviewDtoModel.PreviewItem.PreviewItemOwner.FullName = "";
                    PreviewDtoModel.PreviewItem.PreviewItemOwner.Location = "";
                    PreviewDtoModel.PreviewItem.PreviewItemOwner.UserName = "";
                    PreviewDtoModel.PreviewItem.PreviewItemOwner = null;
                }
                
            }

        }

        public void OpenPreviewDisplay()
        {
            PreviewDtoModel.IsPreviewOpen = true;
        }

        #endregion

        public void Dispose()
        {
            if (!_isDisposed)
            {
                ClearPreviewItem();
                PreviewDtoModel = null;
                _isDisposed = true;
            }
        }
    }
}
