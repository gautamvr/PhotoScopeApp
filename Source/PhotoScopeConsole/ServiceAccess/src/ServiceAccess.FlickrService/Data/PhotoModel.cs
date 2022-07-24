namespace ServiceAccess.FlickrService.Data
{
    public class PhotoModel
    {
        public string Url_s { get; set; }
        public string Url_m { get; set; }
        public string Url_l { get; set; }
        public string Url_t { get; set; }

        public string ID { get; set; }

        public string Owner { get; set; }

        public string Secret { get; set; }

        public string Server { get; set; }
        public string Farm { get; set; }

        public string Title { get; set; }
    }
}
