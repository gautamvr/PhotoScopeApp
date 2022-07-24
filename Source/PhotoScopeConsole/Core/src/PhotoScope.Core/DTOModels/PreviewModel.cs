namespace PhotoScope.Core.DTOModels
{
    public class PreviewModel : BaseModel
    {
        private PreviewItem _previewItem;

        public PreviewItem PreviewItem
        {
            get => _previewItem;
            set => SetField(ref _previewItem,value);
        }
    }
}
