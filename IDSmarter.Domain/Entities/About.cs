namespace IDSmarter.Domain.Entities
{
    public class About
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
