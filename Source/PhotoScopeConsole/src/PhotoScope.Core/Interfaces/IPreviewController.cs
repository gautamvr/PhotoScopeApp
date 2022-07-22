using System;
using System.Threading.Tasks;

namespace PhotoScope.Core.Interfaces
{
    public interface IPreviewController
    {
        Task LoadPreview(string imageId,string imageUrl);

        void ClosePreview();

        Task LoadComments();

        void PostComment(string comment);

        event EventHandler PreviewClosed ;
    }
}