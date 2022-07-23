using System.Collections.Generic;
using PhotoScope.Core.DTOModels;

namespace PhotoScope.PreviewDisplay.Interfaces
{
    public interface IPreviewPopulator
    {
        void ClearPreviewItem();

        void UpdatePreviewItem(PreviewItem item);

        void UpdatePreviewImageUrl(string url);

        void UpdateComments(IEnumerable<CommentItem> comments);

        PreviewModel GetPreviewModel();
    }
}