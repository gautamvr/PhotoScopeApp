namespace PhotoScope.Core.DTOModels
{
    /// <summary>
    /// The tag item for the word that is searched by the user (To support multiple tags)
    /// </summary>
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
