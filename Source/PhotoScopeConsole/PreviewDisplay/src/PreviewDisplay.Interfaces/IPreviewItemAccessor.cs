using System.Collections.Generic;
using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;

namespace PreviewDisplay.Interfaces
{
    public interface IPreviewItemAccessor
    {
        Task<PreviewItem> GetPreviewItem(string imageId);

        Task<IEnumerable<CommentItem>> GetCommentSection(string imageId);
    }
}