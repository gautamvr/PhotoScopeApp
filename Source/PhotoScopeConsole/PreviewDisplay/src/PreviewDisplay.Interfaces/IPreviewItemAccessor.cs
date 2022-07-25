using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhotoScope.Core.DTOModels;

namespace PreviewDisplay.Interfaces
{
    /// <summary>
    /// Gets the preview items from the service
    /// </summary>
    public interface IPreviewItemAccessor : IDisposable
    {
        /// <summary>
        /// Gets the preview item
        /// </summary>
        /// <param name="imageId"></param>
        /// <returns></returns>
        Task<PreviewItem> GetPreviewItem(string imageId);

        /// <summary>
        /// Gets the Comment Section
        /// </summary>
        /// <param name="imageId"></param>
        /// <returns></returns>
        Task<IEnumerable<CommentItem>> GetCommentSection(string imageId);
    }
}