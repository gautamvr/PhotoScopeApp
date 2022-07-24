namespace PhotoScope.Core.DTOModels
{
    public class SearchTagItem : BaseModel
    {
        private string _tag;

        public string Tag
        {
            get { return _tag; }
            set { SetField(ref _tag, value); }
        }

    }
}
