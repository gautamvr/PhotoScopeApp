namespace PhotoScope.Core.DTOModels
{
    public class PreviewModel : BaseModel
    {
        private PreviewItem _previewItem;
        private bool _isPreviewOpen;

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
    }
}
