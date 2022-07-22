using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;
using PhotoScope.PreviewDisplay.Interfaces;

namespace PhotoScope.PreviewDisplay
{
    public class PreviewPopulator : IPreviewPopulator
    {
        public PreviewModel PreviewDtoModel { get; set; }

        public PreviewPopulator()
        {
            PreviewDtoModel = new PreviewModel
            {
                
                CommentsList = new ObservableCollection<CommentItem>(),
                PreviewItemOwner = new PreviewItemOwner()
            };
        }

        public void UpdatePreviewItem(PreviewModel previewItem)
        {
            if (previewItem != null)
            {
                PreviewDtoModel = previewItem;
            }
        }

        public void UpdatePreviewImageUrl(string imageUrl)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                PreviewDtoModel.ImageUrl = imageUrl;
            }
        }

        public void UpdateComments(IList<CommentItem> comments)
        {
            if (comments != null)
            {
                foreach (var comment in comments)
                {
                    if (comment != null)
                    {
                        PreviewDtoModel.CommentsList.Add(comment);
                    }
                }
            }
            
        }
        
        public PreviewModel GetPreviewModel()
        {
            return PreviewDtoModel;
        }
    }
}
