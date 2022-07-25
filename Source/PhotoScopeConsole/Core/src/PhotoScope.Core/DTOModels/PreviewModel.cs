namespace PhotoScope.Core.DTOModels
{
    /// <summary>
    /// Preview DTO Model that is to be used by UI
    /// </summary>
    public class PreviewModel : BaseModel
    {
        #region Private Properties

        private PreviewItem _previewItem;
        private bool _isPreviewOpen;

        #endregion

        #region Public properties

        public PreviewItem PreviewItem
        {
            get => _previewItem;
            set => SetField(ref _previewItem,value);
        }

        public bool IsPreviewOpen
        {
            get => _isPreviewOpen;
            set => SetField(ref _isPreviewOpen,value);
        }

        #endregion
    }
}
