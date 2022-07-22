using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;

namespace PhotoScope.PreviewDisplay.Interfaces
{
    public interface IPreviewItemAccessor
    {
        Task<PreviewModel> GetPreviewItem(string imageId);

        Task<IEnumerable<CommentItem>> GetCommentSection(string imageId);
    }
}