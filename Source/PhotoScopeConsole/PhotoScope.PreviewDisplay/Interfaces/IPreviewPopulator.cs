using System.Collections.Generic;
using PhotoScope.Core.DTOModels;

namespace PhotoScope.PreviewDisplay.Interfaces
{
    public interface IPreviewPopulator
    {
        void UpdatePreviewItem(PreviewModel item);

        void UpdatePreviewImageUrl(string url);

        void UpdateComments(IList<CommentItem> comments);

        PreviewModel GetPreviewModel();
    }
}