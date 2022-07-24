using System.Collections.Generic;
using PhotoScope.Core.DTOModels;

namespace PreviewDisplay.Interfaces
{
    public interface IPreviewPopulator
    {
        void ClearPreviewItem();

        void OpenPreviewDisplay();

        void ClosePreviewDisplay();

        void UpdatePreviewItem(PreviewItem item);

        void UpdatePreviewImageUrl(string url);

        void UpdateComments(IEnumerable<CommentItem> comments);

        PreviewModel GetPreviewModel();
    }
}