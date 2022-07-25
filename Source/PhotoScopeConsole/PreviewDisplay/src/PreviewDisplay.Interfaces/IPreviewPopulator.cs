using System;
using System.Collections.Generic;
using PhotoScope.Core.DTOModels;

namespace PreviewDisplay.Interfaces
{
    /// <summary>
    /// Preview Display Populator
    /// </summary>
    public interface IPreviewPopulator : IDisposable
    {
        /// <summary>
        /// Clears the preview item
        /// </summary>
        void ClearPreviewItem();

        /// <summary>
        /// Opens the preview item
        /// </summary>
        void OpenPreviewDisplay();

        /// <summary>
        /// Closes the preview Display
        /// </summary>
        void ClosePreviewDisplay();

        /// <summary>
        /// Updates the preview item
        /// </summary>
        /// <param name="item"></param>
        void UpdatePreviewItem(PreviewItem item);

        /// <summary>
        /// Updates the preview Image
        /// </summary>
        /// <param name="url"></param>
        void UpdatePreviewImageUrl(string url);

        /// <summary>
        /// Updates the comments
        /// </summary>
        /// <param name="comments"></param>
        void UpdateComments(IEnumerable<CommentItem> comments);

        /// <summary>
        /// Gets the preview model
        /// </summary>
        /// <returns></returns>
        PreviewModel GetPreviewModel();
    }
}