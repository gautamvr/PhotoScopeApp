using System;
using System.Threading.Tasks;

namespace PhotoScope.Core.Interfaces
{
    public interface IPreviewController
    {
        Task<bool> LoadPreview(string imageId);

        void ClosePreview();

        Task LoadComments();

        void PostComment(string comment);

        event EventHandler PreviewClosed ;
    }
}