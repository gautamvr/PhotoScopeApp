using System;
using System.Threading.Tasks;

namespace PhotoScope.Core.Interfaces
{
    /// <summary>
    /// Interface to control any activity that is on the preview display
    /// </summary>
    public interface IPreviewController : IDisposable
    {
        /// <summary>
        /// Load Preview
        /// </summary>
        /// <param name="imageId"></param>
        /// <returns></returns>
        Task LoadPreview(string imageId);

        /// <summary>
        /// Close Preview
        /// </summary>
        void ClosePreview();

        /// <summary>
        /// Load the comments
        /// </summary>
        /// <returns></returns>
        Task LoadComments();

        /// <summary>
        /// Post the comments
        /// </summary>
        /// <param name="comment"></param>
        void PostComment(string comment);

        event EventHandler PreviewClosed ;

        event EventHandler PreviewLoading ;

        event EventHandler PreviewLoaded ;
    }
}