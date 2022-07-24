namespace ServiceAccess.FlickrService.Data
{
    public class Comment
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public bool Author_Is_Deleted { get; set; }
        public string AuthorName { get; set; }
        public string IconServer { get; set; }
        public int IconFarm { get; set; }
        public string DateCreate { get; set; }
        public string _content { get; set; }

    }
}