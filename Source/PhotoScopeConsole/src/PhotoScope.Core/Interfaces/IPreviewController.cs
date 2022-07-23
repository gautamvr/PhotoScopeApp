using System;
using System.Threading.Tasks;

namespace PhotoScope.Core.Interfaces
{
    public interface IPreviewController
    {
        Task LoadPreview(string imageId);

        void ClosePreview();

        Task LoadComments();

        void PostComment(string comment);

        event EventHandler PreviewClosed ;

        event EventHandler PreviewLoading ;

        event EventHandler PreviewLoaded ;
    }
}